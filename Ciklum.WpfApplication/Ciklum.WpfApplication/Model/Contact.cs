using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Ciklum.WpfApplication.Properties;

namespace Ciklum.WpfApplication.Model
{
    public class Contact : IDataErrorInfo
    {
        public static Contact CreateNewContact()
        {
            return new Contact();
        }

        public static Contact CreateContact(
            string firstName,
            string lastName,
            string phoneNumber,
            string email)
        {
            return new Contact
            {
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                Email = email
            };
        }

        protected Contact()
        {
        }

        public string Email { get; set; }
        public string FirstName { get; set; }
        public string PhoneNumber { get; set; }
        public string LastName { get; set; }

        string IDataErrorInfo.Error { get { return null; } }

        string IDataErrorInfo.this[string propertyName]
        {
            get { return this.GetValidationError(propertyName); }
        }

        public bool IsValid
        {
            get
            {
                foreach (string property in ValidatedProperties)
                    if (GetValidationError(property) != null)
                        return false;

                return true;
            }
        }

        static readonly string[] ValidatedProperties = 
        { 
            "Email", 
            "FirstName", 
            "LastName",
            "PhoneNumber"
        };

        string GetValidationError(string propertyName)
        {
            if (Array.IndexOf(ValidatedProperties, propertyName) < 0)
                return null;

            string error = null;

            switch (propertyName)
            {
                case "Email":
                    error = this.ValidateEmail();
                    break;

                case "FirstName":
                    error = this.ValidateFirstName();
                    break;

                case "LastName":
                    error = this.ValidateLastName();
                    break;

                case "PhoneNumber":
                    error = this.ValidatePhoneNumber();
                    break;
                default:
                    Debug.Fail("Unexpected property being validated on Contact: " + propertyName);
                    break;
            }

            return error;
        }

        string ValidateEmail()
        {
            if (IsStringMissing(this.Email))
            {
                return Resources.Contact_Error_MissingEmail;
            }
            else if (!IsValidEmailAddress(this.Email))
            {
                return Resources.Contact_Error_InvalidEmail;
            }
            return null;
        }

        string ValidateFirstName()
        {
            if (IsStringMissing(this.FirstName))
            {
                return Resources.Contact_Error_MissingFirstName;
            }
            return null;
        }

        string ValidatePhoneNumber()
        {
            if (IsStringMissing(this.PhoneNumber))
            {
                return Resources.Contact_Error_MissingPhoneNumber;
            }
            return null;
        }

        string ValidateLastName()
        {
            if (IsStringMissing(this.LastName))
            {
                    return Resources.Contact_Error_MissingLastName;
            }
            return null;
        }

        static bool IsStringMissing(string value)
        {
            return
                String.IsNullOrEmpty(value) ||
                value.Trim() == String.Empty;
        }

        static bool IsValidEmailAddress(string email)
        {
            if (IsStringMissing(email))
                return false;

            string emailRegx = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return Regex.IsMatch(email, emailRegx, RegexOptions.IgnoreCase);
        }
    }
}