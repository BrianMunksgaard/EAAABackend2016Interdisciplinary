using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace bgs.Models
{
    /// <summary>
    /// This class hold information about the different games that 
    /// the sleeves fit to.
    /// </summary>
    public class Game : BgsEntity
    {
        #region Private variables

        private int gameId;
        private string gameName;
        private string gameCode;

        private ICollection<ProductFitGame> productsFit;

        #endregion

        #region Public properties

        /// <summary>
        /// A unique game id. This is primarily used for internal/db purposes.
        /// </summary>
        [Key]
        public int GameId
        {
            get
            {
                return gameId;
            }
            set
            {
                gameId = value;
            }
        }

        /// <summary>
        /// The name of the game.
        /// </summary>
        public string GameName
        {
            get
            {
                return gameName;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    gameName = value;
                }
            }
        }

        /// <summary>
        /// A unique game code to identify the game. This is the game code used by the business.
        /// </summary>
        public string GameCode
        {
            get
            {
                return gameCode;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    gameCode = value;
                }
            }
        }

        /// <summary>
        /// A collection of products/sleeves where the game fits inside.
        /// </summary>
        public virtual ICollection<ProductFitGame> ProductsFit
        {
            get
            {
                return productsFit;
            }
        }

        #endregion

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Game()
        {
            productsFit = new List<ProductFitGame>();
        }
    }
}