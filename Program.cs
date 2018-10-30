using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace ZenonMaster
{
    public class Program
    {
        readonly string msg = "Hello";

        public static void Main(string[] args)
        {
            new Program().MainAsync().GetAwaiter().GetResult();
        }

        public async Task MainAsync()
        {
            var client = new DiscordSocketClient();

            client.Log += Log;

            string token = "NTA2OTE2ODYyNzgxODE2ODMy.DrpSCA.OAWhUEfUD6n68IjeeA9ohIXhdUk";

            await client.LoginAsync(TokenType.Bot, token);

            await client.StartAsync();

            client.MessageReceived += MessageReceived;

            await Task.Delay(-1);
        }

        Task Log(LogMessage arg)
        {
            Console.WriteLine(msg);

            return Task.CompletedTask;
        }

        async Task MessageReceived(SocketMessage message)
        {
            if (message.Content == ">Say")
            {
                await message.Channel.SendMessageAsync
                ("Everyone is here? ");
            }
        }
    }
}