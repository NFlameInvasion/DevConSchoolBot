using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;
using RouteBot.Extensions;
using RouteBot.Data;
using RouteBot.Services;

namespace RouteBot.Dialogs
{
    [Serializable]
    public class RouteDialog : IDialog<RouteData>
    {
        RouteData routeData;
        IDataService dataService = new DataService();

        public async Task StartAsync(IDialogContext context)
        {
            if (routeData == null)
            {
                routeData = new RouteData();
            }

            context.Wait(MessageReceivedAsync);
        }

        public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            var message = await argument;

            if (message.Contains("help"))
            {
                await ReplyWrapper(context, "help");
            }
            else if (message.Contains("bye"))
            {
                await ReplyWrapper(context, "bye");
            }
            else if (message.Contains("hello"))
            {
                await ReplyWrapper(context, "hello");
            }
            //else if (message.Contains("from"))
            //{
            //    ReplyWrapper(context, "from");
            //}
            else if (message.Contains("route"))
            {
                await ReplyWrapper(context, "route");
            }
            else
            {
                await ReplyWrapper(context, message.Text);
            }
        }

        private async Task ReplyWrapper(IDialogContext context, string message)
        {
            var repl = await Reply(message);
            await context.PostAsync(repl);
            context.Wait(MessageReceivedAsync);
        }

        async Task<string> Reply(string msg)
        {
            if (msg.Contains("help"))
            {
                return @"This is a simple Route Bot
                         
                        Example of commands include:   
                            - route";
            }

            if (msg.Contains("bye"))
            {
                return @"Good bye";
            }

            //if (msg.Contains("from"))
            //{
            //    return @"What is your current location?";
            //}

            if (msg.Contains("route"))
            {
                return @"What is your destination?";
            }

            if (msg.Contains("hello"))
            {
                return @"Hello, you could ask me about best route";
            }

            //Enough for the demo :))
            routeData.FromLocation = "Алабяна 3к1";
            routeData.ToLocation = msg;

            var response = await dataService.Get(routeData);

            return response.Result;
        }
    }
}