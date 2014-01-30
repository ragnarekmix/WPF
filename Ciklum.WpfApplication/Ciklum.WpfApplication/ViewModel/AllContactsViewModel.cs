using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Ciklum.WpfApplication.DataAccess;
using Ciklum.WpfApplication.Properties;

namespace Ciklum.WpfApplication.ViewModel
{
    public class AllContactsViewModel : WorkspaceViewModel
    {
        readonly ContactRepository _contactRepository;

        public AllContactsViewModel(ContactRepository contactRepository)
        {
            if (contactRepository == null)
                throw new ArgumentNullException("contactRepository");

            base.DisplayName = Resources.AllContactsViewModel_DisplayName;            

            _contactRepository = contactRepository;

            _contactRepository.ContactAdded += this.OnContactAddedToRepository;

            this.CreateAllContacts();
        }

        void CreateAllContacts()
        {
            List<ContactViewModel> all =
                (from cust in _contactRepository.GetContacts()
                 select new ContactViewModel(cust, _contactRepository)).ToList();

            foreach (ContactViewModel cvm in all)
                cvm.PropertyChanged += this.OnContactViewModelPropertyChanged;

            this.AllContacts = new ObservableCollection<ContactViewModel>(all);
            this.AllContacts.CollectionChanged += this.OnCollectionChanged;
        }

        public ObservableCollection<ContactViewModel> AllContacts { get; private set; }

        protected override void OnDispose()
        {
            foreach (ContactViewModel custVM in this.AllContacts)
                custVM.Dispose();

            this.AllContacts.Clear();
            this.AllContacts.CollectionChanged -= this.OnCollectionChanged;

            _contactRepository.ContactAdded -= this.OnContactAddedToRepository;
        }

        void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (ContactViewModel custVM in e.NewItems)
                    custVM.PropertyChanged += this.OnContactViewModelPropertyChanged;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (ContactViewModel custVM in e.OldItems)
                    custVM.PropertyChanged -= this.OnContactViewModelPropertyChanged;
        }

        void OnContactViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            string IsSelected = "IsSelected";

            (sender as ContactViewModel).VerifyPropertyName(IsSelected);
        }

        void OnContactAddedToRepository(object sender, ContactAddedEventArgs e)
        {
            var viewModel = new ContactViewModel(e.NewContact, _contactRepository);
            this.AllContacts.Add(viewModel);
        }
    }
}