using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace bgs.Models
{
    public class Game
    {
        #region Private variables

        private int gameId;
        private string gameName;
        private string gameCode;

        private IEnumerable<ProductGame> productsFit;

        #endregion

        #region Public properties

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

        public virtual IEnumerable<ProductGame> ProductsFit
        {
            get
            {
                return productsFit;
            }
        }

        #endregion

        public Game()
        {
            productsFit = new List<ProductGame>();
        }
    }
}