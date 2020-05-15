using CybersportApp.Core;
using CybersportApp.Core.ModelsForList;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CybersportApp.Pages
{
    public class UsersViewPageVM : INotifyPropertyChanged
    {
        private string _finder { get; set; }

        public string Finder
        {
            get { return _finder; }
            set
            {
                _finder = value;
                OnPropertyChanged("Finder");
            }
        }

        private ObservableCollection<UsersForList> _usersList { get; set; }

        public ObservableCollection<UsersForList> UsersList
        {
            get { return _usersList; }
            set
            {
                _usersList = value;
                OnPropertyChanged("UsersList");
            }
        }

        private RelayCommand _useFinder { get; set; }

        public RelayCommand UseFinder
        {
            get
            {
                return _useFinder ??
                    (_useFinder = new RelayCommand(x =>
                    {
                        if (Finder == null
                          || Finder == string.Empty)
                            UsersList = CybersportCore.GetUsers(CybersportAppNavigation.CurrentUser.Login);
                        else
                        {
                            UsersList.Clear();

                            foreach (var user in CybersportCore.GetUsers(CybersportAppNavigation.CurrentUser.Login))
                            {
                                if (user.Login.Contains(Finder))
                                    UsersList.Add(user);
                            }
                        }
                    }));
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
