using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RouteBot.Data;
using RouteBot.Services;

namespace RouteTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var svc = new DataService();

            var result = svc.Get(new RouteData {FromLocation = "Алабяна 3к1", ToLocation = "Широкая 12а"}).Result;
        }
    }
}
