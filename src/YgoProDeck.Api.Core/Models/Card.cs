using Newtonsoft.Json;

namespace YgoProDeck.Api.Core.Models
{
    public class Card
    {
        /// <summary>
        /// ID or Passcode of the card.
        /// </summary>
        [JsonProperty("id")] 
        public string Id { get; set; }
        
        /// <summary>
        /// Name of the card.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Card description/effect.
        /// </summary>
        [JsonProperty("desc")]
        public string Desc { get; set; }

        /// <summary>
        /// The ATK value of the card.
        /// </summary>
        [JsonProperty("atk")]
        public short Atk { get; set; }

        /// <summary>
        /// The DEF value of the card.
        /// </summary>
        [JsonProperty("def")]
        public short Def { get; set; }

        /// <summary>
        /// The type of card you are viewing.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// The Level/RANK of the card.
        /// </summary>
        [JsonProperty("level")]
        public byte Level { get; set; }

        /// <summary>
        /// The card race which is officially called type.
        /// </summary>
        [JsonProperty("race")]
        public string Race { get; set; }

        /// <summary>
        /// The attribute of the card.
        /// </summary>
        [JsonProperty("attribute")]
        public string Attribute { get; set; }

        /// <summary>
        /// The Pendulum Scale Value (only Pendulum monsters will have a scale value, otherwise NULL).
        /// </summary>
        [JsonProperty("scale")]
        public string Scale { get; set; }

        /// <summary>
        /// The Link Value of the card if it's of type "Link Monster".
        /// </summary>
        [JsonProperty("linkval")]
        public string LinkVal { get; set; }

        /// <summary>
        /// The Link Markers of the card if it's of type "Link Monster".
        /// </summary>
        [JsonProperty("linkmarkers")]
        public string LinkMarkers { get; set; }

        /// <summary>
        /// The Archetype that the card belongs to.
        /// </summary>
        [JsonProperty("archetype")]
        public string ArcheType { get; set; }

        /// <summary>
        /// Every Card Set code number this card belongs to.
        /// </summary>
        [JsonProperty("set_tag")]
        public string Set_Tag { get; set; }

        /// <summary>
        /// Every Card Set this card belongs to.
        /// </summary>
        [JsonProperty("setcode")]
        public string SetCode { get; set; }

        /// <summary>
        /// The status of the card on the TCG Ban List.
        /// </summary>
        [JsonProperty("ban_tcg")]
        public string Ban_Tcg { get; set; }

        /// <summary>
        /// The status of the card on the OCG Ban List.
        /// </summary>
        [JsonProperty("ban_ocg")]
        public string Ban_Ocg { get; set; }
        
        /// <summary>
        /// The status of the card on the GOAT Format Ban List.
        /// </summary>
        [JsonProperty("ban_goat")]
        public string Ban_Goat { get; set; }

        /// <summary>
        /// The URL for the image.
        /// </summary>
        [JsonProperty("image_url")]
        public string Image_Url { get; set; }

        /// <summary>
        /// The URL for a smaller sized version of the image.
        /// </summary>
        [JsonProperty("image_url_small")]
        public string Image_Url_Small { get; set; }
    }
}