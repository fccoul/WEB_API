﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;


namespace ConsoleApp_WebAPI
{
    public class HelloController : ApiController 
    {
        public string[] Get() 
        {
            return new[] { "Wow" ,"this" ,"is" ,"a" ,"real" ,"Web" ,"App"};
        }
    }
}