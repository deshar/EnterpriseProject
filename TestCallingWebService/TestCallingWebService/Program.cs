using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCallingWebService.TestWeb;

namespace TestCallingWebService
{
    class Program
    {
        static void Main(string[] args)
        {
            Service1 webservice = new Service1();
            string srt = webservice.simpleMethod("This could be a BLOB Storage Service");
            Console.WriteLine(srt);
            Console.WriteLine(webservice.anotherSimpleMethod(5,25));
            Console.ReadLine();
        }
    }
}
