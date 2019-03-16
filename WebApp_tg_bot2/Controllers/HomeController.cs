using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PorterOfChat;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using Npgsql;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;
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
          TelegramBotClient  _TgClient = new TelegramBotClient("879891589:AAGsYqXLm0opnM2MedrMBl97XBdXmN5OOXQ");

            //switch (update.Type)
            //{
            //    case UpdateType.Message:

            //        PorterOfChat.Porter.OnMessage(update.Message);
            //        break;
            //    case UpdateType.CallbackQuery:


            //        PorterOfChat.Porter.OnCallbackQuery(update.CallbackQuery);

            //        break;
            //}
           // string ur2 = @"https://r2---sn-4g5e6nez.googlevideo.com/videoplayback?itag=22&mime=video%2Fmp4&dur=0.580&ei=W8GMXPifGteOgQfZ753wBQ&id=o-AI7WgvJ8XmosGLeJAP8K1co84gsrfB-oyBOGFClTG6kA&pl=20&fvip=2&ratebypass=yes&ip=195.170.15.66&source=youtube&requiressl=yes&sparams=dur,ei,expire,id,ip,ipbits,ipbypass,itag,lmt,mime,mip,mm,mn,ms,mv,pl,ratebypass,requiressl,source&expire=1552750011&lmt=1472890478810065&key=cms1&c=WEB&signature=250C762874121FC3D28C089726CD4C6289B90BA1.6DD08EC2C1917471A73CB466E8A50B216ADF27D9&ipbits=0&video_id=5pTi3Ei81x8&title=%D0%92%D0%B8%D0%B4%D0%B5%D0%BE+1+%D1%81%D0%B5%D0%BA%D1%83%D0%BD%D0%B4%D0%B0+%21&rm=sn-vuxbavcx-5uil7z,sn-4g5ele7l&req_id=78861c0b24b1a3ee&ipbypass=yes&mip=46.211.53.226&cm2rm=sn-3tp8nu5g-3c2z7l,sn-3c2edek&redirect_counter=4&cms_redirect=yes&mm=34&mn=sn-4g5e6nez&ms=ltu&mt=1552728342&mv=m";
            // string ur2 = "https://i-msdn.sec.s-msft.com/dynimg/IC834692.png";
            //string link = ur2; //ссылка
            //WebClient webClient = new WebClient();
            //webClient.DownloadFileAsync(new Uri(link), "sPCK.png"); //на
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(update.Message.Text);
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                Stream stream = resp.GetResponseStream();
                //FileStream file = new FileStream(@"test.mp4", FileMode.Create, FileAccess.Write);
                //// BinaryWriter write =(new FileInfo(file)).get;
                ////file.Write();
                //int b;
                //for (int i = 0; ; i++)
                //{
                //    b = stream.ReadByte();
                //    if (b == -1) break;
                //    file.WriteByte((byte)b);
                //}
                //// write.Close();
                //file.Close();

                // file = new FileStream(@"test.mp4", FileMode.Create, FileAccess.Write);
                _TgClient.SendVideoAsync(new ChatId(227950395), new InputOnlineFile(stream, "name.mp4"));
            }
            catch (Exception e)
            {
                _TgClient.SendTextMessageAsync(new ChatId(227950395), "error");
            }
          
            return Ok();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
