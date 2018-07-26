using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Types
{
    /// <summary>
    /// Represents an animation file (GIF or H.264/MPEG-4 AVC video without sound) to be sent
    /// </summary>
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class InputMediaAnimation : InputMediaBase
    {
        /// <summary>
        /// Optional. Animation width
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Width { get; set; }

        /// <summary>
        /// Optional. Animation height
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Height { get; set; }

        /// <summary>
        /// Optional. Animation duration
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Duration { get; set; }

        /// <summary>
        /// Optional. Thumbnail to send
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public InputMedia Thumb { get; set; }

        /// <summary>
        /// Initializes a new animation media to send
        /// </summary>
        public InputMediaAnimation()
        {
            Type = "animation";
        }

        /// <summary>
        /// Initializes a new animation media to send with an <see cref="InputMedia"/>
        /// </summary>
        public InputMediaAnimation(InputMedia media)
            : this()
        {
            Media = media;
        }
    }
}
