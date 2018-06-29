using isRock.LineBot;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SongLineBot.Controllers.Api
{
    public class BotController : ApiController
    {
        Bot _Bot;
        string _LineChannelSecret = string.Empty;
        string _LineChannelAccessToken = string.Empty;

        public BotController()
        {
            _LineChannelSecret = ConfigurationManager.AppSettings["LineChannelSecret"];
            _LineChannelAccessToken = ConfigurationManager.AppSettings["LineChannelAccessToken"];
            _Bot = new Bot(_LineChannelAccessToken);
        }
        [HttpPost]
        [Route("api/bot")]
        public IHttpActionResult Bot()
        {
            try
            {
                //取得原始資料(Json)
                var RawData = Request.Content.ReadAsStringAsync().Result;
                //分析Line結構內容
                var ReceivedData = Utility.Parsing(RawData);
                foreach (var e in ReceivedData.events)
                {
                    var ReplyMessage = e.message.text;

                    Utility.ReplyMessage(ReceivedData.events[0].replyToken, ReplyMessage, _LineChannelSecret);
                }
                //取得 http Post RawData(should be JSON)
                string postData = Request.Content.ReadAsStringAsync().Result;
                //剖析JSON
                var ReceivedMessage = isRock.LineBot.Utility.Parsing(postData);
                //回覆訊息
                string Message;
                Message = "你說了:" + ReceivedMessage.events[0].message.text;
                //回覆用戶
                Utility.ReplyMessage(ReceivedMessage.events[0].replyToken, Message, _LineChannelAccessToken);

            }
            catch (Exception)
            {
                return Ok();

            }
            //回覆API OK
            return Ok();
        }
    }
}