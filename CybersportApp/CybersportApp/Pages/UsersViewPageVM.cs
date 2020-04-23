using CybersportApp.Core;
using CybersportApp.Core.ModelsForList;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CybersportApp.Pages
{
    public class UsersViewPageVM : INotifyPropertyChanged
    {
        private ObservableCollection<UsersForList> _usersList { get; set; }

        public ObservableCollection<UsersForList> UsersList
        {
            get { return _usersList; }
            set
            {
                _usersList = value;
                OnPropertyChanged("TeamsList");
            }
        }

        public UsersViewPageVM()
        {
            UsersList = CybersportCore.GetUsers();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}
