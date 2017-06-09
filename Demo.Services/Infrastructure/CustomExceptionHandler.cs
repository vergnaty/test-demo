using Demo.Repository.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Web;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Filters;

namespace Demo.Services.Infrastructure
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public static IDictionary<Type, Action<HttpActionExecutedContext>> container;

        /// <summary>
        /// Create new instance <see cref="CustomExceptionFilterAttribute"/>
        /// </summary>
        public CustomExceptionFilterAttribute()
        {
            this.Register();
        }

        public override void OnException(HttpActionExecutedContext context)
        {
            Action<HttpActionExecutedContext> action = null;
            if (container.TryGetValue(context.Exception.GetType(), out action))
            {
                action.Invoke(context);
            }
            else
            {
                this.UnknownError(context);
            }
            base.OnException(context);
        }
        
        /// <summary>
        /// Register all type of exception 
        /// </summary>
        private void Register()
        {
            if (container == null)
            {
                container = new Dictionary<Type, Action<HttpActionExecutedContext>>();
                container.Add(typeof(ArgumentNullException), this.CommonExceptions);
                container.Add(typeof(DataNotFoundException), this.CommonExceptions);
            }
        }

        private void UnknownError(HttpActionExecutedContext context)
        {
            //LOGGING
            context.Response = new HttpResponseMessage(HttpStatusCode.NotAcceptable);
            JsonErrorResponseModel response = new JsonErrorResponseModel()
            {
                ErrorCode = (int)context.Response.StatusCode,
                Message = "Oooops,something is wrong with your request! please dont do something we dont expect :-)"
            };
            context.Response.Content = new ObjectContent<JsonErrorResponseModel>(response, new JsonMediaTypeFormatter());
        }

        private void CommonExceptions(HttpActionExecutedContext context)
        {
            //LOGGING
            context.Response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            JsonErrorResponseModel response = new JsonErrorResponseModel()
            {
                ErrorCode = (int)HttpStatusCode.BadRequest,
                Message = context.Exception.Message
            };
            context.Response.Content = new ObjectContent<JsonErrorResponseModel>(response,new JsonMediaTypeFormatter());
        }
    }
}