using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _19T1021292.Web.Controllers
{
    [RoutePrefix("thu-nghiem")]
    public class testController : Controller
    {
       
        [Route("xin-chao/{name?}/{age?}")]
        public string Sayhello( string name, int age=22)
        {
            return $"hello{name}. {age} year old";
        }
    }
}
