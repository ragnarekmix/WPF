using System;
using Ciklum.WpfApplication.Model;

namespace Ciklum.WpfApplication.DataAccess
{
    public class ContactAddedEventArgs : EventArgs
    {
        public ContactAddedEventArgs(Contact newContact)
        {
            this.NewContact = newContact;
        }

        public Contact NewContact { get; private set; }
    }
}