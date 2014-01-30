using Ciklum.WpfApplication.DataAccess;
using Ciklum.WpfApplication.Model;
using Ciklum.WpfApplication.Properties;
using Ciklum.WpfApplication.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ciklum.WpfApplication.Tests
{
    [TestClass]
    public class ContactViewModelTests
    {
        [TestMethod]
        public void CustomerFieldsShouldWorkCorreclty()
        {
            var cust = Contact.CreateNewContact();
            var repos = new ContactRepository(Constants.CONTACT_DATA_FILE);
            var target = new ContactViewModel(cust, repos);

            target.FirstName = Resources.Contact_Error_MissingFirstName;
            Assert.AreEqual(target.FirstName, "First name is missing");

            target.LastName = Resources.Contact_Error_MissingLastName;
            Assert.AreEqual(target.LastName, "Last name is missing");

            target.PhoneNumber = Resources.Contact_Error_MissingPhoneNumber;
            Assert.AreEqual(target.PhoneNumber, "Phone number is missing");

            target.Email = Resources.Contact_Error_InvalidEmail;
            Assert.AreEqual(target.Email, "E-mail address is invalid");

            target.Email = Resources.Contact_Error_MissingEmail;
            Assert.AreEqual(target.Email, "E-mail address is missing");
        }
    }
}
