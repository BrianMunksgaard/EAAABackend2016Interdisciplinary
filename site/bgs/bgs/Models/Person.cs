using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bgs.Models
{
    /// <summary>
    /// MbmStore customer information.
    /// </summary>
    public class Person
    {

        #region PrivateFields

        private int personId;
        private string firstName;
        private string lastName;
        private string address;
        private string zip;
        private string city;
        private DateTime birthDay;
        private List<string> phoneNumbers;
        private List<Role> roles;

        #endregion

        #region Properties

        /// <summary>
        /// Unique id.
        /// </summary>
        [Key]
        public int PersonId
        {
            get { return personId; }
            set { personId = value; }
        }

        /// <summary>
        /// Person first name.
        /// </summary>
        public string FirstName
        {
            get { return firstName == null ? firstName = string.Empty : firstName; }
            set { firstName = value; }
        }

        /// <summary>
        /// Person last name.
        /// </summary>
        public string LastName
        {
            get { return lastName == null ? lastName = string.Empty : lastName; }
            set { lastName = value; }
        }

        /// <summary>
        /// Person address.
        /// </summary>
        public string Address
        {
            get { return address == null ? address = string.Empty : address; }
            set { address = value; }
        }

        /// <summary>
        /// Person zip code.
        /// </summary>
        public string Zip
        {
            get { return zip == null ? zip = string.Empty : zip; }
            set { zip = value; }
        }

        /// <summary>
        /// Person city.
        /// </summary>
        public string City
        {
            get { return city == null ? city = string.Empty : city; }
            set { city = value; }
        }

        /// <summary>
        /// Person birthday. Birthday has to be
        /// between 0 and 120 years, both included.
        /// </summary>
        [Column(TypeName = "datetime2")]
        public DateTime BirthDay
        {
            get { return birthDay; }
            set
            {
                DateTime now = DateTime.Now;
                if (value >= now.AddYears(-120) && value <= now)
                {
                    birthDay = value;
                }
                else
                {
                    throw new Exception("Birthday not accepted");
                }
            }
        }

        /// <summary>
        /// Returns the person age in a string.
        /// </summary>
        public string Age
        {
            get
            {
                if (BirthDay == DateTime.MinValue)
                {
                    return "Unknown";
                }
                else
                {
                    DateTime now = DateTime.Now;
                    int age = now.Year - BirthDay.Year;
                    // calculate to see if the customer hasn’t had birthday yet
                    // subtract one year if that is so.
                    if (now.Month < BirthDay.Month || (now.Month == BirthDay.Month && now.Day < BirthDay.Day))
                    {
                        age--;
                    }

                    return age.ToString();
                }
            }
        }

        /// <summary>
        /// The list of phone numbers.
        /// </summary>
        public List<string> PhoneNumbers
        {
            get
            {
                if (phoneNumbers == null)
                {
                    phoneNumbers = new List<string>();
                }
                return phoneNumbers;
            }
        }

        /// <summary>
        /// Return all phone numbers in a concatinated string.
        /// Numbers are seperated by comma.
        /// </summary>
        public string AllPhoneNumbers
        {
            get
            {
                if (PhoneNumbers.Count > 0)
                {
                    return string.Join(", ", PhoneNumbers);
                }
                else
                {
                    return "No phone";
                }
            }
        }

        /// <summary>
        /// Roles assigned to this person.
        /// </summary>
        public List<Role> Roles
        {
            get { return roles == null ? roles = new List<Role>() : roles; }
            set { roles = value; }
        }

        #endregion

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Person() { }

        /// <summary>
        /// Initialization constructor.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="address"></param>
        /// <param name="zip"></param>
        /// <param name="city"></param>
        public Person(string firstName, string lastName, string address, string zip, string city)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.zip = zip;
            this.city = city;
        }

        /// <summary>
        /// Initialization constructor.
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="address"></param>
        /// <param name="zip"></param>
        /// <param name="city"></param>
        public Person(int personId, string firstName, string lastName, string address, string zip, string city) : this(firstName, lastName, address, zip, city)
        {
            this.personId = personId;
        }


        /// <summary>
        /// Add customer phone number.
        /// </summary>
        /// <param name="phoneNumber"></param>
        public void AddPhoneNumber(string phoneNumber)
        {
            if (!string.IsNullOrEmpty(phoneNumber))
            {
                PhoneNumbers.Add(phoneNumber);
            }
        }
    }
}