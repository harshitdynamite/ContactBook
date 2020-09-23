using ContactBook.Commons.Wrapper;
using ContactBook.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ContactBook.ViewModel
{
    public class ContactListViewModel : BindableBase, INotifyPropertyChanged
    {
        private HttpClientWrapper _client = new HttpClientWrapper();

        public ObservableCollection<Contact> _contacts;
        public ObservableCollection<Contact> Contacts 
        {
            get
            {
                return _contacts;
            }
            set
            {
                if (_contacts != value)
                {
                    _contacts = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Contacts"));
                }
            }
        }

        public ContactListViewModel()
        {
            DeleteCommand = new RelayCommand(OnDelete, CanDelete);
        }

        Contact _selectedContact;

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public Contact SelectedContact 
        {
            get
            {
                return _selectedContact;
            }
            set
            {
                _selectedContact = value;
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        public RelayCommand DeleteCommand { get; set; }
        private void OnDelete()
        {
            _client.Delete(SelectedContact.Key);
            LoadContacts();
            //Contacts.Remove(SelectedContact);
        }
        private bool CanDelete()
        {
            return SelectedContact != null;
        }

        public void LoadContacts()
        {
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject())) return;
            var contactsList = _client.Get().Content;
            var contactsAll = JsonConvert.DeserializeObject<IEnumerable<Contact>>(contactsList);
            Contacts = new ObservableCollection<Contact>(contactsAll);
        }
    }
}
