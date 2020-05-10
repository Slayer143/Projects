using CybersportApp.Core;
using CybersportApp.Core.ModelsForList;
using System.Collections.ObjectModel;
using System.ComponentModel;

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
            UsersList = CybersportCore.GetUsers(CybersportAppNavigation.CurrentUser.Login);
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
