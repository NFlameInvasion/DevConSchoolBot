using RouteBot.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteBot.Services
{
    public interface IDataService
    {
        Task<RouteDescription> Get(RouteData routeData);
    }
}
