using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace ContactBook.ViewModel
{
    public class MainWindowViewModel : BindableBase
    {
        private AddContactViewModel _addContactViewModel = new AddContactViewModel();
        private ContactListViewModel _contactListViewModel = new ContactListViewModel();
        private DetailEditContactViewModel _detailEditContactViewModel = new DetailEditContactViewModel();
        //public object CurrentViewModel { get; set; }

        private BindableBase _CurrentViewModel;

        public MainWindowViewModel()
        {
            NavCommand = new RelayCommand<string>(OnNav);
        }
        public BindableBase CurrentViewModel
        {
            get { return _CurrentViewModel; }
            set { SetProperty(ref _CurrentViewModel, value); }
        }

        public RelayCommand<string> NavCommand { get; set; }

        private void OnNav(string destination)
        {
            switch (destination)
            {
                case "add":
                    CurrentViewModel = _addContactViewModel;
                    break;
                case "edit":
                    CurrentViewModel = _detailEditContactViewModel;
                    break;
                default:
                    CurrentViewModel = _contactListViewModel;
                    break;
            }
        }
    }
}
