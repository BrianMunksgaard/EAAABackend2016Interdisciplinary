using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bgs.Models
{
    public class ProductGame
    {
        [Key, Column(Order = 0)]
        public int ProductId { get; set; }

        [Key, Column(Order = 1)]
        public int GameId { get; set; }

        public virtual Product Product { get; set; }

        public virtual Game Game { get; set; }

        public string Comment { get; set; }

    }
}