using System.Collections.Generic;

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

        public int GameId
        {
            get
            {
                return GameId;
            }
            set
            {
                GameId = value;
            }
        }

        public string GameName
        {
            get
            {
                return GameName;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    GameName = value;
                }
            }
        }

        public string GameCode
        {
            get
            {
                return GameCode;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    GameCode = value;
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