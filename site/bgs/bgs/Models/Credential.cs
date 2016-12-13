using System.ComponentModel.DataAnnotations;

namespace bgs.Models
{
    /// <summary>
    /// This class hold the login credentials for
    /// a user in the system.
    /// At the moment it is not necessary for a user 
    /// to have a credentials, only administrators
    /// are required to have a credential.
    /// </summary>
    public class Credential : BgsEntity
    {
        #region Private variables

        private int credentialId;
        private string userName;
        private string userPass;

        #endregion

        #region Public properties

        /// <summary>
        /// A unique credentials id.
        /// </summary>
        [Key]
        public int CredentialsId
        {
            get { return credentialId; }
            set { credentialId = value; }
        }

        /// <summary>
        /// The username for this specific credential.
        /// </summary>
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

        /// <summary>
        /// The password for this specific credential.
        /// </summary>
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