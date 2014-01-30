using Ciklum.WpfApplication.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = MbUnit.Framework.Assert;

namespace Ciklum.WpfApplication.Tests
{
    [TestClass]
    public class ContactTests
    {
        [TestMethod]
        public void IsValidShouldReturnTrueWhenContactIsOk()
        {
            var contact = Contact.CreateNewContact();
            contact.FirstName = "Aron";
            contact.LastName = "Bian";
            contact.Email = "aron@zxdcfv.com";
            contact.PhoneNumber = "1233141435";

            Assert.IsTrue(contact.IsValid, "Should be valid");
        }

        [TestMethod]
        public void IsValidShouldReturnFalceWhenContactFirstNameIsEmpty()
        {
            var contact = Contact.CreateNewContact();
            contact.FirstName = "";
            contact.LastName = "Bian";
            contact.Email = "aron@zxdcfv.com";
            contact.PhoneNumber = "1233141435";

            Assert.IsFalse(contact.IsValid, "Should be invalid");
        }

        [TestMethod]
        public void IsValidShouldReturnFalceWhenContactLastNameIsEmpty()
        {
            var contact = Contact.CreateNewContact();
            contact.FirstName = "Aron";
            contact.LastName = "";
            contact.Email = "aron@zxdcfv.com";
            contact.PhoneNumber = "1233141435";

            Assert.IsFalse(contact.IsValid, "Should be invalid");
        }

        [TestMethod]
        public void IsValidShouldReturnFalceWhenContactPhoneNumberIsEmpty()
        {
            var contact = Contact.CreateNewContact();
            contact.FirstName = "Aron";
            contact.LastName = "Bian";
            contact.Email = "aron@zxdcfv.com";
            contact.PhoneNumber = "";

            Assert.IsFalse(contact.IsValid, "Should be invalid");
        }

        [TestMethod]
        public void IsValidShouldReturnFalceWhenContactEmailIsWrong()
        {
            var contact = Contact.CreateNewContact();
            contact.FirstName = "Aron";
            contact.LastName = "Bian";
            contact.Email = "aron@zxdcfv";
            contact.PhoneNumber = "1233141435";

            Assert.IsFalse(contact.IsValid, "Should be invalid");
        }
    }
}
