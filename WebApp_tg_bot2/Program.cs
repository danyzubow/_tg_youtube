using System;
using System.IO;
using System.Net;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace WebApp_tg_bot2
{
    public class Program
    {

        public static void Main(string[] args)
        {

          
            string url_Web_Hook;
            string Token;


            
            Console.WriteLine("***end***");
            //Console.ReadKey();
#if DEBUG

            #region WebHook_debug

            Token = "879891589:AAGsYqXLm0opnM2MedrMBl97XBdXmN5OOXQ"; //debug token
            url_Web_Hook = "https://8567534b.ngrok.io/home/update";
            PorterOfChat.Porter.SetWebhook(Token, url_Web_Hook);
            #endregion

            #region Receiving

            //Token = "521500060:AAH4Cj8XkwG0BpyDPy_a-hFN5LtFC5IC0sM"; //debug token
            //string NameBot = "@PorterOfChatBot";
            //Porter _porter = new Porter(Token, NameBot);
            //_porter.StartReceiving(Token);
            #endregion

#else
            url_Web_Hook = "https://tgyou.herokuapp.com/home/update";
            Token = "879891589:AAGsYqXLm0opnM2MedrMBl97XBdXmN5OOXQ";
            PorterOfChat.Porter.SetWebhook(Token,url_Web_Hook);
#endif
            CreateWebHostBuilder(args).Build().Run();



        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

    }


}
