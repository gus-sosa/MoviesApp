using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoviesApp.Controllers
{
    public interface IInterface
    {
        string GetMessage();
    }

    class MyClass : IInterface
    {
        public string GetMessage()
        {
            return "HOLA MUNDO!!!";
        }
    }

    public class TestController : Controller
    {
        public TestController(IInterface message)
        {
            Message = message;
        }

        internal IInterface Message { get; private set; }

        // GET: Test
        public string Index()
        {
            return Message.GetMessage();
        }
    }
}