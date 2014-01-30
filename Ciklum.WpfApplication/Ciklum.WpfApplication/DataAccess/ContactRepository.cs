using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Resources;
using System.Xml;
using System.Xml.Linq;
using Ciklum.WpfApplication.Model;

namespace Ciklum.WpfApplication.DataAccess
{
    public class ContactRepository
    {
        readonly List<Contact> _contacts;

        public ContactRepository(string contactDataFile)
        {
            _contacts = LoadContacts(contactDataFile);
        }

        public event EventHandler<ContactAddedEventArgs> ContactAdded;

        public void AddContact(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException("contact");

            if (!_contacts.Contains(contact))
            {
                _contacts.Add(contact);

                if (this.ContactAdded != null)
                    this.ContactAdded(this, new ContactAddedEventArgs(contact));
            }
        }

        public bool ContainsContact(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException("contact");

            return _contacts.Contains(contact);
        }

        public List<Contact> GetContacts()
        {
            return new List<Contact>(_contacts);
        }

        static List<Contact> LoadContacts(string contactDataFile)
        {
            using (Stream stream = GetResourceStream(contactDataFile))
            using (XmlReader xmlRdr = new XmlTextReader(stream))
                return
                    (from contactElem in XDocument.Load(xmlRdr).Element("contacts").Elements("contact")
                     select Contact.CreateContact(
                        (string)contactElem.Attribute("firstName"),
                        (string)contactElem.Attribute("lastName"),
                        (string)contactElem.Attribute("phoneNumber"),
                        (string)contactElem.Attribute("email")
                         )).ToList();
        }

        static Stream GetResourceStream(string resourceFile)
        {
            Uri uri = new Uri(resourceFile, UriKind.RelativeOrAbsolute);

            StreamResourceInfo info = Application.GetResourceStream(uri);
            if (info == null || info.Stream == null)
                throw new ApplicationException("Missing resource file: " + resourceFile);

            return info.Stream;
        }
    }
}