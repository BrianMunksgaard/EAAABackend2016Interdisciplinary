using System.ComponentModel.DataAnnotations;

namespace bgs.Models
{
    public class Credential : BgsEntity
    {
        #region Private variables

        private int credentialId;
        private string userName;
        private string userPass;

        #endregion

        #region Public properties

        [Key]
        public int CredentialsId
        {
            get { return credentialId; }
            set { credentialId = value; }
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