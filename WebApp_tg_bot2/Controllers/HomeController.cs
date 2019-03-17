using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PorterOfChat;
using System;
using System.Diagnostics;
using System.IO;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;
using VideoLibrary;
using WebApp_tg_bot2.Models;
namespace WebApp_tg_bot2.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {
            if (_porter == null)
            {

                //                string Token;
                //                string NameBot;
                //                string connectionString = "";
                //                //string Path;
                //                //string ftpContactDll;
                //#if DEBUG
                //                Token = "879891589:AAGsYqXLm0opnM2MedrMBl97XBdXmN5OOXQ"; //debug token
                //                NameBot = "@PorterOfChatBot";

                //#else
                //                Token = "879891589:AAGsYqXLm0opnM2MedrMBl97XBdXmN5OOXQ";
                //                NameBot = "@seadogs4_bot";


                //#endif


                //                connectionString = Environment.GetEnvironmentVariable("connectionString");

                //                if (String.IsNullOrEmpty(connectionString))
                //                {
                //                    throw new Exception("connectionString is empty");
                //                }
                //                _porter = new Porter(Token, NameBot, connectionString);
            }
        }
        static PorterOfChat.Porter _porter;
        public IActionResult Index()
        {
            return RedirectToAction("ChatView", "Home");
        }
        [Authorize]
        public IActionResult ChatView()
        {

            return View(BaseControl.Data.GetMessageLogs().ToArray());
        }

        public OkResult update([FromBody]Update update)
        {
            //  return Ok();

            TelegramBotClient _TgClient = new TelegramBotClient("879891589:AAGsYqXLm0opnM2MedrMBl97XBdXmN5OOXQ");


            //try
            //{
                string id = update.Message.Text;

                using (var service = Client.For(YouTube.Default))
                {
                    var video = service.GetVideo("https://youtube.com/watch?v=" + id);

                    Console.WriteLine("Awesome! Downloading...");





                    string folder = "";

                    //if (char.ToUpper(opt) == 'Y')
                    //    folder = GetDefaultFolder();
                    //else
                    //{
                    //    Console.Write("Please tell us where you'd like to save it: ");
                    //    folder = Console.ReadLine();
                    //}

                    string path = Path.Combine(folder, video.FullName);
                    //   Directory.CreateDirectory(folder);
                    Console.WriteLine("Saving...");

                    System.IO.File.WriteAllBytes(path, video.GetBytes());
                    var stream = new System.IO.FileStream(video.FullName, FileMode.Open);
                    _TgClient.SendDocumentAsync(new ChatId(227950395), new InputOnlineFile(stream, video.FullName));
                    Console.WriteLine("Done.");

                }

          //  }
            //catch (Exception e)
            //{

            //    _TgClient.SendTextMessageAsync(new ChatId(227950395), e.ToString());
            //    _TgClient.SendTextMessageAsync(new ChatId(227950395), "error");
            //}

            return Ok();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
