using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.Services.Models
{
    public class ResponseModel
    {
        public int Total { get; set; }
        public object Data { get; set; }

        public ResponseModel(object data)
        {
            this.Data = data;
        }
    }
}