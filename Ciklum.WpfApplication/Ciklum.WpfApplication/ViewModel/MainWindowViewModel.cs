using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Data;
using Ciklum.WpfApplication.DataAccess;
using Ciklum.WpfApplication.Model;
using Ciklum.WpfApplication.Properties;

namespace Ciklum.WpfApplication.ViewModel
{
    public class MainWindowViewModel : WorkspaceViewModel
    {
        ReadOnlyCollection<CommandViewModel> _commands;
        readonly ContactRepository _contactRepository;
        ObservableCollection<WorkspaceViewModel> _workspaces;

        public MainWindowViewModel(string contactDataFile)
        {
            base.DisplayName = Resources.MainWindowViewModel_DisplayName;

            _contactRepository = new ContactRepository(contactDataFile);
        }

        public ReadOnlyCollection<CommandViewModel> Commands
        {
            get
            {
                if (_commands == null)
                {
                    List<CommandViewModel> cmds = this.CreateCommands();
                    _commands = new ReadOnlyCollection<CommandViewModel>(cmds);
                }
                return _commands;
            }
        }

        List<CommandViewModel> CreateCommands()
        {
            return new List<CommandViewModel>
            {
                new CommandViewModel(
                    Resources.MainWindowViewModel_Command_ViewAllContacts,
                    new RelayCommand(param => this.ShowAllContacts())),

                new CommandViewModel(
                    Resources.MainWindowViewModel_Command_CreateNewContact,
                    new RelayCommand(param => this.CreateNewContact()))
            };
        }

        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if (_workspaces == null)
                {
                    _workspaces = new ObservableCollection<WorkspaceViewModel>();
                    _workspaces.CollectionChanged += this.OnWorkspacesChanged;
                }
                return _workspaces;
            }
        }

        void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.OnWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.OnWorkspaceRequestClose;
        }

        void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            var workspace = sender as WorkspaceViewModel;
            workspace.Dispose();
            this.Workspaces.Remove(workspace);
        }

        void CreateNewContact()
        {
            var newContact = Contact.CreateNewContact();
            var workspace = new ContactViewModel(newContact, _contactRepository);
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }

        void ShowAllContacts()
        {
            var workspace =this.Workspaces.FirstOrDefault(vm => vm is AllContactsViewModel) as AllContactsViewModel;

            if (workspace == null)
            {
                workspace = new AllContactsViewModel(_contactRepository);
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }

        void SetActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }
    }
}