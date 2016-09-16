using RouteBot.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using RouteBot.Extensions;
using YandexAPI;
using YandexAPI.Maps;

namespace RouteBot.Services
{
    public class DataService : IDataService
    {
        private GeoCode _geoCoder = new GeoCode();

        public async Task<RouteDescription> Get(RouteData routeData)
        {
            if (string.IsNullOrEmpty(routeData.FromLocation))
            {
                return new RouteDescription {Result = "Please enter your origin address."};
            }

            if (string.IsNullOrEmpty(routeData.ToLocation))
            {
                return new RouteDescription { Result = "Please enter your destination address." };
            }

            string objectFrom = _geoCoder.SearchObject(routeData.FromLocation);
            if (string.IsNullOrEmpty(objectFrom))
            {
                return new RouteDescription {Result = $"Couldn't find your origin address: {routeData.FromLocation}"};
            }

            var pointFrom = _geoCoder.GetPointD(objectFrom);
            if (!pointFrom.IsValid())
            {
                return new RouteDescription { Result = $"Couldn't find your origin address: {routeData.FromLocation}" };
            }

            string objectTo = _geoCoder.SearchObject(routeData.ToLocation);
            if (string.IsNullOrEmpty(objectTo))
            {
                return new RouteDescription { Result = $"Couldn't find your destination address: {routeData.ToLocation}" };
            }

            var pointTo = _geoCoder.GetPointD(objectTo);
            if (!pointTo.IsValid())
            {
                return new RouteDescription { Result = $"Couldn't find your destination address: {routeData.ToLocation}" };
            }

            var route = await GetRoute(pointFrom, pointTo);

            return new RouteDescription
            {
                Route = route,
                Result = route == null 
                ? "Sorry, we couldn't build your route :("
                : $"Your trip is {route.RouteHumanLength} long, and will take {route.RouteHumanJamsTime} ({route.RouteHumanTime} if you are Batman)."
            };
        }

        private Task<Route> GetRoute(PointD from, PointD to)
        {
            return Task.Run(() =>
            {
                var result = new Route();
                var thread = new Thread(() =>
                             {
                                 // Lots of shitty closures in here, better not think about it.
                                 result = result.Load(from, to);
                             });
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                thread.Join();

                return result;
            });
        }
    }
}