using System;
using System.ComponentModel;

namespace Bot.Common.Base.Enums
{
    /// <summary>
    /// enum BotEventTypeEnum
    /// </summary>
    public enum BotEventTypeEnum
    {
        [Description("text")]
        Text = 1,
        [Description("image")]
        Image = 2,
        [Description("video")]
        Video = 3,
        [Description("audio")]
        Audio = 4,
        [Description("location")]
        Location = 5
    }
}
