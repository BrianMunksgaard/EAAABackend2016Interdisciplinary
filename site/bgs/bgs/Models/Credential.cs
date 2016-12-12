using System.ComponentModel.DataAnnotations;

namespace bgs.Models
{
    public class Credential
    {
        #region Private variables

        private int credentialsId;
        private string userName;
        private string userPass;

        #endregion

        #region Public properties

        [Key]
        public int CredentialsId
        {
            get { return credentialsId; }
            set { credentialsId = value; }
        }

        [Required]
        public string UserName
        {
            get { return userName ?? string.Empty; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    userName = value;
                }
            }
        }

        [Required]
        public string UserPass
        {
            get { return userPass ?? string.Empty; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    userPass = value;
                }
            }
        }

        #endregion

    }
}