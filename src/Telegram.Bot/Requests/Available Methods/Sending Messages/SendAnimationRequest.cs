using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests
{
    /// <summary>
    /// Send animation files (GIF or H.264/MPEG-4 AVC video without sound)
    /// </summary>
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class SendAnimationRequest : FileRequestBase<Message>,
                                        INotifiableMessage,
                                        IReplyMessage,
                                        IReplyMarkupMessage<IReplyMarkup>,
                                        IFormattableMessage
    {
        /// <summary>
        /// Unique identifier for the target chat or username of the target channel (in the format @channelusername)
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public ChatId ChatId { get; }

        /// <summary>
        /// Animation file to send
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public InputOnlineFile Animation { get; }

        /// <summary>
        /// Duration of the animation in seconds
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Duration { get; set; }

        /// <summary>
        /// Animation width
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Width { get; set; }

        /// <summary>
        /// Animation height
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Height { get; set; }

        /// <summary>
        /// Thumbnail of the file sent. The thumbnail should be in JPEG format and less than 200 kB in size.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public InputOnlineFile Thumb { get; set; }

        /// <summary>
        /// Animation caption (may also be used when resending animations by file_id), 0-200 characters
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Caption { get; set; }

        /// <inheritdoc />
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public ParseMode ParseMode { get; set; }
        
        /// <inheritdoc />
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool DisableNotification { get; set; }

        /// <inheritdoc />
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int ReplyToMessageId { get; set; }

        /// <inheritdoc />
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IReplyMarkup ReplyMarkup { get; set; }

        /// <summary>
        /// Initializes a new request with chatId and animation
        /// </summary>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel</param>
        /// <param name="animation">Animation to send</param>
        public SendAnimationRequest(ChatId chatId, InputOnlineFile animation)
            : base("sendAnimation")
        {
            ChatId = chatId;
            Animation = animation;
        }

        /// <inheritdoc />
        public override HttpContent ToHttpContent() =>
            Animation.FileType == FileType.Stream
                ? ToMultipartFormDataContent("animation", Animation)
                : base.ToHttpContent();
    }
}
