using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bgs.Models
{
    /// <summary>
    /// This class holds the relations between
    /// games and products/sleeves.
    /// </summary>
    public class ProductFitGame
    {

        /// <summary>
        /// The product id of the product side of the relation.
        /// This is one part of the combined primary key.
        /// </summary>
        [Key, Column(Order = 0)]
        public int ProductId { get; set; }

        /// <summary>
        /// The game id of the game side of the relation.
        /// This is one part of the combined primary key.
        /// </summary>
        [Key, Column(Order = 1)]
        public int GameId { get; set; }

        /// <summary>
        /// A navigational property for the product.
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        /// A navigational property for the game.
        /// </summary>
        public virtual Game Game { get; set; }

        /// <summary>
        /// A possible comment for any relevant notes
        /// about the relation.
        /// </summary>
        public string Comment { get; set; }

    }
}