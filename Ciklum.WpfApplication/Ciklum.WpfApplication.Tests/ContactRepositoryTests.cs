using Ciklum.WpfApplication.DataAccess;
using Ciklum.WpfApplication.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ciklum.WpfApplication.Tests
{
    [TestClass]
    public class ContactRepositoryTests
    {

        [TestMethod]
        public void TestAllCustomersAreLoaded()
        {
            var target = new ContactRepository(Constants.CONTACT_DATA_FILE);
            Assert.AreEqual(4, target.GetContacts().Count, "Invalid number of contacts in repository.");
        }

        [TestMethod]
        public void TestNewCustomerIsAddedProperly()
        {
            var target = new ContactRepository(Constants.CONTACT_DATA_FILE);
            var contact = Contact.CreateNewContact();

            bool eventArgIsValid = false;
            target.ContactAdded += (sender, e) => eventArgIsValid = (e.NewContact == contact);
            target.AddContact(contact);

            Assert.IsTrue(eventArgIsValid, "Invalid NewContact property");
            Assert.IsTrue(target.ContainsContact(contact), "New contact was not added");
        }
    }
}
