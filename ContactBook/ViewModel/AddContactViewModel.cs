using ContactBook.Models;
using ContactBook.Wrapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Security.RightsManagement;
using System.Text;

namespace ContactBook.ViewModel
{
    public class AddContactViewModel : BindableBase
    {
        private HttpClientWrapper _client;
        private Contact contact;
        private string firstName;
        public string FirstName
        {
            get => firstName;
            set
            {
                if (firstName != value)
                {
                    firstName = value;
                    SetProperty(ref firstName, value);
                }
            }
        }
        public string lastName;
        public string LastName
        {
            get => lastName;
            set
            {
                if (lastName != value)
                {
                    firstName = value;
                    SetProperty(ref lastName, value);
                    //PropertyChanged(this, new PropertyChangedEventArgs("LastName"));
                }
            }
        }
        public string dOB;

        public string DOB
        {
            get => dOB;
            set
            {
                if (dOB != value)
                {
                    dOB = value;
                }
            }
        }

        public AddContactViewModel()
        {
            _client = new HttpClientWrapper();
            SaveCommand = new RelayCommand(OnSave, CanSave);
        }

        public RelayCommand SaveCommand { get; set; }


        public void OnSave()
        {
            var newContact = new Contact()
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                DOB = Convert.ToDateTime(this.DOB)
            };
            var contacts = JsonConvert.SerializeObject(newContact);

            _client.Post(contacts);
        }

        public bool CanSave()
        { return true; }
    }
}
