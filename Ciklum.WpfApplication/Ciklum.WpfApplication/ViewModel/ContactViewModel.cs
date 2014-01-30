using System;
using System.ComponentModel;
using System.Windows.Input;
using Ciklum.WpfApplication.DataAccess;
using Ciklum.WpfApplication.Model;
using Ciklum.WpfApplication.Properties;

namespace Ciklum.WpfApplication.ViewModel
{
    public class ContactViewModel : WorkspaceViewModel, IDataErrorInfo
    {
        readonly Contact _contact;
        readonly ContactRepository _contactRepository;
        
        string[] _contactTypeOptions;
        bool _isSelected;
        RelayCommand _saveCommand;

        public ContactViewModel(Contact contact, ContactRepository contactRepository)
        {
            if (contact == null)
                throw new ArgumentNullException("contact");

            if (contactRepository == null)
                throw new ArgumentNullException("contactRepository");

            _contact = contact;
            _contactRepository = contactRepository;
            
        }

        public string Email
        {
            get { return _contact.Email; }
            set
            {
                if (value == _contact.Email)
                    return;

                _contact.Email = value;

                base.OnPropertyChanged("Email");
            }
        }

        public string FirstName
        {
            get { return _contact.FirstName; }
            set
            {
                if (value == _contact.FirstName)
                    return;

                _contact.FirstName = value;

                base.OnPropertyChanged("FirstName");
            }
        }

        public string PhoneNumber
        {
            get { return _contact.PhoneNumber; }
            set
            {
                if (value == _contact.PhoneNumber)
                    return;

                _contact.PhoneNumber = value;

                base.OnPropertyChanged("PhoneNumber");
            }
        }

        public string LastName
        {
            get { return _contact.LastName; }
            set
            {
                if (value == _contact.LastName)
                    return;

                _contact.LastName = value;

                base.OnPropertyChanged("LastName");
            }
        }

        public override string DisplayName
        {
            get
            {
                if (this.IsNewContact)
                {
                    return Resources.ContactViewModel_DisplayName;
                }
                else
                {
                    return String.Format("{0}, {1}", _contact.LastName, _contact.FirstName);
                }
            }
        }

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (value == _isSelected)
                    return;

                _isSelected = value;

                base.OnPropertyChanged("IsSelected");
            }
        }

        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new RelayCommand(param => this.Save(),
                        param => this.CanSave);
                }
                return _saveCommand;
            }
        }

        bool CanSave
        {
            get { return _contact.IsValid; }
        }

        public void Save()
        {
            if (!_contact.IsValid)
                throw new InvalidOperationException(Resources.ContactViewModel_Exception_CannotSave);

            if (this.IsNewContact)
                _contactRepository.AddContact(_contact);

            base.OnPropertyChanged("DisplayName");
        }

        bool IsNewContact
        {
            get { return !_contactRepository.ContainsContact(_contact); }
        }

        string IDataErrorInfo.Error
        {
            get { return (_contact as IDataErrorInfo).Error; }
        }

        string IDataErrorInfo.this[string propertyName]
        {
            get
            {
                string error = (_contact as IDataErrorInfo)[propertyName];

                CommandManager.InvalidateRequerySuggested();

                return error;
            }
        }
    }
}