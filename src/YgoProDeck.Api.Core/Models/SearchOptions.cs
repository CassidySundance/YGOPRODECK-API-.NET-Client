namespace YgoProDeck.Api.Core.Models
{
    public class SearchOptions
    {
        /// <summary>
        /// The exact name of the card. You can also pass a card ID to this.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// A fuzzy search using a string.
        /// </summary>
        public string FName { get; set; }
        
        /// <summary>
        /// The type of card you want to filter by.
        /// </summary>
        public string Type { get; set; }
        
        /// <summary>
        /// Filter by ATK value.
        /// </summary>
        public short Atk { get; set; }
        
        /// <summary>
        /// Filter by DEF value.
        /// </summary>
        public short Def { get; set; }
        
        /// <summary>
        /// Filter by card level/RANK.
        /// </summary>
        public byte Level { get; set; }
        
        /// <summary>
        /// Filter by the card race, which is officially called type. This is also used for Spell/Trap cards.
        /// </summary>
        public string Race { get; set; }
        
        /// <summary>
        /// Filter by the card attribute.
        /// </summary>
        public string Attribute { get; set; }
        
        /// <summary>
        /// Filter the cards by Link value.
        /// </summary>
        public string Link { get; set; }
        
        /// <summary>
        /// Filter the cards by Link Marker value.
        /// </summary>
        public string LinkMarker { get; set; }
        
        /// <summary>
        /// Filter the cards by Pendulum Scale value.
        /// </summary>
        public string Scale { get; set; }
        
        /// <summary>
        /// Filter the cards by card set.
        /// </summary>
        public string Set { get; set; }
        
        /// <summary>
        /// Filter the cards by archetype.
        /// </summary>
        public string ArcheType { get; set; }
        
        /// <summary>
        /// Filter the cards by ban list.
        /// </summary>
        public string BanList { get; set; }
        
        /// <summary>
        /// Sort the order of the cards.
        /// </summary>
        public string Sort { get; set; }
        
        /// <summary>
        /// Filter the cards by Language.
        /// </summary>
        public string La { get; set; }
    }
}