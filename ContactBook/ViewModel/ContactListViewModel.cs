using ContactBook.Models;
using ContactBook.Wrapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Text.Json.Serialization;

namespace ContactBook.ViewModel
{
    public class ContactListViewModel
    {
        private HttpClientWrapper _client = new HttpClientWrapper();

        public ObservableCollection<Contact> Contacts { get; set; }

        public ContactListViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject())) return;
            var contactsList = _client.Get().Content;
            var contactsAll = JsonConvert.DeserializeObject<IEnumerable<Contact>>(contactsList);
            Contacts = new ObservableCollection<Contact>(contactsAll);
        }
    }
}
