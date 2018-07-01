using Bot.Common.Base.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bot.Common.Base.Helper
{
    /// <summary>
    /// class BotEventTypeHelper
    /// </summary>
    public class BotEventTypeHelper
    {
        /// <summary>
        /// 取得Event Type Enum
        /// </summary>
        /// <returns></returns>
        public static BotEventTypeEnum GetEvent(string eventType)
        {
           switch (eventType.ToLower())
            {
                case "text":
                    return BotEventTypeEnum.Text;
                case "image":
                    return BotEventTypeEnum.Image;
                case "video":
                    return BotEventTypeEnum.Video;
                case "audio":
                    return BotEventTypeEnum.Audio;
                case "location":
                    return BotEventTypeEnum.Location;
                default:
                    return BotEventTypeEnum.None;
            }
        }
    }
}
