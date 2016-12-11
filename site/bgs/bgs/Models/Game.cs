namespace bgs.Models
{
    public class Game
    {
        #region Private variables

        private int gameId;
        private string gameName;
        private string gameCode;

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

        #endregion

        public Game()
        {

        }
    }
}