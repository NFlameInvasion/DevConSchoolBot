using RouteBot.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace RouteBot.Services
{
    public class DataService : IDataService
    {
        public async Task<RouteDescription> Get(RouteData routeData)
        {
            return new RouteDescription
            {
                Length = 5
            };
        }
    }
}