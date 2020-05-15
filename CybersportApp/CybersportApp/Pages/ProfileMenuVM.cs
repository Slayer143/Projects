using CybersportApp.Core;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;

namespace CybersportApp.Pages
{
    public class ProfileMenuVM : INotifyPropertyChanged
    {
        private Visibility _deleteVisibilityControl { get; set; }

        public Visibility DeleteVisibilityControl
        {
            get { return _deleteVisibilityControl; }
            set
            {
                _deleteVisibilityControl = value;
                OnPropertyChanged("DeleteVisibilityControl");
            }
        }

        private bool _deleteIsEnabledControl { get; set; }

        public bool DeleteIsEnabledControl
        {
            get { return _deleteIsEnabledControl; }
            set
            {
                _deleteIsEnabledControl = value;
                OnPropertyChanged("DeleteIsEnabledControl");
            }
        }

        private Visibility _adminVisibilityControl { get; set; }

        public Visibility AdminVisibilityControl
        {
            get { return _adminVisibilityControl; }
            set
            {
                _adminVisibilityControl = value;
                OnPropertyChanged("AdminVisibilityControl");
            }
        }

        private bool _adminIsEnabledControl { get; set; }

        public bool AdminIsEnabledControl
        {
            get { return _adminIsEnabledControl; }
            set
            {
                _adminIsEnabledControl = value;
                OnPropertyChanged("AdminIsEnabledControl");
            }
        }

        private Visibility _leaveTeamVisibilityControl { get; set; }

        public Visibility LeaveTeamVisibilityControl
        {
            get { return _leaveTeamVisibilityControl; }
            set
            {
                _leaveTeamVisibilityControl = value;
                OnPropertyChanged("InviteVisibilityControl");
            }
        }

        private bool _leaveTeamIsEnabledControl { get; set; }

        public bool LeaveTeamIsEnabledControl
        {
            get { return _leaveTeamIsEnabledControl; }
            set
            {
                _leaveTeamIsEnabledControl = value;
                OnPropertyChanged("LeaveTeamIsEnabledControl");
            }
        }

        private Visibility _inviteVisibilityControl { get; set; }

        public Visibility InviteVisibilityControl
        {
            get { return _inviteVisibilityControl; }
            set
            {
                _inviteVisibilityControl = value;
                OnPropertyChanged("InviteVisibilityControl");
            }
        }

        private bool _inviteIsEnabledControl { get; set; }

        public bool InviteIsEnabledControl
        {
            get { return _inviteIsEnabledControl; }
            set
            {
                _inviteIsEnabledControl = value;
                OnPropertyChanged("InviteIsEnabledControl");
            }
        }

        private ObservableCollection<string> _teamsCollection { get; set; }

        public ObservableCollection<string> TeamsCollection
        {
            get { return _teamsCollection; }
            set
            {
                _teamsCollection = value;
                OnPropertyChanged("TeamsCollection");
            }
        }

        private Visibility _saveOtherVisibilityControl { get; set; }

        public Visibility SaveOtherVisibilityControl
        {
            get { return _saveOtherVisibilityControl; }
            set
            {
                _saveOtherVisibilityControl = value;
                OnPropertyChanged("SaveOtherVisibilityControl");
            }
        }

        private bool _saveOtherIsEnabledControl { get; set; }

        public bool SaveOtherIsEnabledControl
        {
            get { return _saveOtherIsEnabledControl; }
            set
            {
                _saveOtherIsEnabledControl = value;
                OnPropertyChanged("SaveOtherIsEnabledControl");
            }
        }

        private Visibility _saveVisibilityControl { get; set; }

        public Visibility SaveVisibilityControl
        {
            get { return _saveVisibilityControl; }
            set
            {
                _saveVisibilityControl = value;
                OnPropertyChanged("SaveVisibilityControl");
            }
        }

        private bool _saveIsEnabledControl { get; set; }

        public bool SaveIsEnabledControl
        {
            get { return _saveIsEnabledControl; }
            set
            {
                _saveIsEnabledControl = value;
                OnPropertyChanged("SaveIsEnabledControl");
            }
        }

        private Visibility _teamChangeVisibilityControl { get; set; }

        public Visibility TeamChangeVisibilityControl
        {
            get { return _teamChangeVisibilityControl; }
            set
            {
                _teamChangeVisibilityControl = value;
                OnPropertyChanged("TeamChangeVisibilityControl");
            }
        }

        private bool _teamChangeIsEnabledControl { get; set; }

        public bool TeamChangeIsEnabledControl
        {
            get { return _teamChangeIsEnabledControl; }
            set
            {
                _teamChangeIsEnabledControl = value;
                OnPropertyChanged("TeamChangeIsEnabledControl");
            }
        }

        private Visibility _managerCreateVisibilityControl { get; set; }

        public Visibility ManagerCreateVisibilityControl
        {
            get { return _managerCreateVisibilityControl; }
            set
            {
                _managerCreateVisibilityControl = value;
                OnPropertyChanged("ManagerCreateVisibilityControl");
            }
        }

        private bool _managerCreateIsEnabledControl { get; set; }

        public bool ManagerCreateIsEnabledControl
        {
            get { return _managerCreateIsEnabledControl; }
            set
            {
                _managerCreateIsEnabledControl = value;
                OnPropertyChanged("ManagerCreateIsEnabledControl");
            }
        }

        private Visibility _managerVisibilityControl { get; set; }

        public Visibility ManagerVisibilityControl
        {
            get { return _managerVisibilityControl; }
            set
            {
                _managerVisibilityControl = value;
                OnPropertyChanged("ManagerVisibilityControl");
            }
        }

        private bool _managerIsEnabledControl { get; set; }

        public bool ManagerIsEnabledControl
        {
            get { return _managerIsEnabledControl; }
            set
            {
                _managerIsEnabledControl = value;
                OnPropertyChanged("ManagerIsEnabledControl");
            }
        }

        private Guid _userId { get; set; }

        public Guid UserId
        {
            get { return _userId; }
            set
            {
                _userId = value;
                OnPropertyChanged("UserId");
            }
        }

        private Visibility _anotherUserVisibilityControl { get; set; }

        public Visibility AnotherUserVisibilityControl
        {
            get { return _anotherUserVisibilityControl; }
            set
            {
                _anotherUserVisibilityControl = value;
                OnPropertyChanged("AnotherUserVisibilityControl");
            }
        }

        private bool _anotherUserIsEnabledControl { get; set; }

        public bool AnotherUserIsEnabledControl
        {
            get { return _anotherUserIsEnabledControl; }
            set
            {
                _anotherUserIsEnabledControl = value;
                OnPropertyChanged("AnotherUserIsEnabledControl");
            }
        }

        private Visibility _anotherUserDetailsVisibilityControl { get; set; }

        public Visibility AnotherUserDetailsVisibilityControl
        {
            get { return _anotherUserDetailsVisibilityControl; }
            set
            {
                _anotherUserDetailsVisibilityControl = value;
                OnPropertyChanged("AnotherUserDetailsVisibilityControl");
            }
        }

        private bool _anotherUserDetailsIsEnabledControl { get; set; }

        public bool AnotherUserDetailsIsEnabledControl
        {
            get { return _anotherUserDetailsIsEnabledControl; }
            set
            {
                _anotherUserDetailsIsEnabledControl = value;
                OnPropertyChanged("AnotherUserDetailsIsEnabledControl");
            }
        }

        private Visibility _visibilityControl { get; set; }

        public Visibility VisibilityControl
        {
            get { return _visibilityControl; }
            set
            {
                _visibilityControl = value;
                OnPropertyChanged("VisibilityControl");
            }
        }

        private bool _isEnabledControl { get; set; }

        public bool IsEnabledControl
        {
            get { return _isEnabledControl; }
            set
            {
                _isEnabledControl = value;
                OnPropertyChanged("IsEnabledControl");
            }
        }

        private string _login { get; set; }

        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged("Login");
            }
        }

        private string _fullName { get; set; }

        public string FullName
        {
            get { return _fullName; }
            set
            {
                _fullName = value;
                OnPropertyChanged("FullName");
            }
        }

        private string _birthDate { get; set; }

        public string BirthDate
        {
            get { return _birthDate; }
            set
            {
                _birthDate = value;
                OnPropertyChanged("BirthDate");
            }
        }

        private string _country { get; set; }

        public string Country
        {
            get { return _country; }
            set
            {
                _country = value;
                OnPropertyChanged("Country");
            }
        }

        private string _team { get; set; }

        public string Team
        {
            get { return _team; }
            set
            {
                _team = value;
                OnPropertyChanged("Team");
            }
        }

        private byte[] _photo { get; set; }

        public byte[] Photo
        {
            get { return _photo; }
            set
            {
                _photo = value;
                OnPropertyChanged("Photo");
            }
        }

        private RelayCommand _changePhoto { get; set; }

        public RelayCommand ChangePhoto
        {
            get
            {
                return _changePhoto ??
                    (_changePhoto = new RelayCommand(x =>
                    {
                        var fileDialog = new OpenFileDialog();
                        fileDialog.Filter = "Image Files | *.BMP;*.JPG;*.PNG";

                        if (fileDialog.ShowDialog() == true)
                        {
                            using (FileStream stream = new FileStream(fileDialog.FileName, FileMode.Open))
                            {
                                byte[] imageData = new byte[stream.Length];
                                stream.Read(imageData, 0, imageData.Length);
                                CybersportAppNavigation.CurrentUser.Photo = imageData;
                            }
                        }

                        CybersportCore.UpdatePhoto(
                            CybersportAppNavigation.CurrentUser.UserId,
                            CybersportAppNavigation.CurrentUser.Photo);

                        CybersportAppNavigation.CurrentProfileMenuPage.DataContext = new ProfileMenuVM();
                    }));
            }
        }

        private RelayCommand _back { get; set; }

        public RelayCommand Back
        {
            get
            {
                return _back ??
                    (_back = new RelayCommand(x =>
                    {
                        if (CybersportAppNavigation.Service.CanGoBack)
                            CybersportAppNavigation.Service.GoBack();
                    }));
            }
        }

        private RelayCommand _showDetails { get; set; }

        public RelayCommand ShowDetails
        {
            get
            {
                return _showDetails ??
                    (_showDetails = new RelayCommand(x =>
                    {
                        CybersportAppNavigation.Service.Navigate(new DetailsPage(Login));
                    }));
            }
        }

        private RelayCommand _writeMessage { get; set; }

        public RelayCommand WriteMessage
        {
            get
            {
                return _writeMessage ??
                    (_writeMessage = new RelayCommand(x =>
                    {
                        CybersportAppNavigation.CurrentDialogueWindow = new DialogueStartWindow(UserId);
                        CybersportAppNavigation.CurrentDialogueWindow.Show();
                    }));
            }
        }

        private RelayCommand _сreateTeam { get; set; }

        public RelayCommand CreateTeam
        {
            get
            {
                return _сreateTeam ??
                    (_сreateTeam = new RelayCommand(x =>
                    {
                        CybersportAppNavigation.Service.Navigate(new TeamAddingPage());
                    }));
            }
        }

        private RelayCommand _leaveTeam { get; set; }

        public RelayCommand LeaveTeam
        {
            get
            {
                return _leaveTeam ??
                    (_leaveTeam = new RelayCommand(x =>
                    {
                        CybersportCore.LeaveTeam(CybersportAppNavigation.CurrentUser.UserId);
                        CybersportAppNavigation.CurrentProfileMenuPage = new ProfileMenu();
                    }));
            }
        }

        private RelayCommand _invite { get; set; }

        public RelayCommand Invite
        {
            get
            {
                return _invite ??
                    (_invite = new RelayCommand(x =>
                    {
                        CybersportCore.InviteToTheTeam(CybersportAppNavigation.CurrentUser.UserId, Login, CybersportAppNavigation.CurrentUser.TeamId);
                        InviteIsEnabledControl = false;
                        InviteVisibilityControl = Visibility.Hidden;
                    }));
            }
        }

        private RelayCommand _adminOptions { get; set; }

        public RelayCommand AdminOptions
        {
            get
            {
                return _adminOptions ??
                    (_adminOptions = new RelayCommand(x =>
                    {
                        CybersportAppNavigation.Service.Navigate(new AdminOptionsPage());
                    }));
            }
        }

        private RelayCommand _save { get; set; }

        public RelayCommand Save
        {
            get
            {
                return _save ??
                    (_save = new RelayCommand(x =>
                    {
                        CybersportCore.SaveTeamChange(Team, CybersportAppNavigation.CurrentUser.UserId);

                        SaveIsEnabledControl = false;
                        SaveVisibilityControl = Visibility.Hidden;
                        TeamChangeIsEnabledControl = false;
                        TeamChangeVisibilityControl = Visibility.Hidden;
                    }));
            }
        }

        private RelayCommand _saveOther { get; set; }

        public RelayCommand SaveOther
        {
            get
            {
                return _saveOther ??
                    (_saveOther = new RelayCommand(x =>
                    {
                        CybersportCore.SaveOtherTeamChange(Team, Login);

                        SaveOtherIsEnabledControl = false;
                        SaveOtherVisibilityControl = Visibility.Hidden;
                        SaveIsEnabledControl = false;
                        SaveVisibilityControl = Visibility.Hidden;
                        TeamChangeIsEnabledControl = false;
                        TeamChangeVisibilityControl = Visibility.Hidden;

                        ManagerCreateIsEnabledControl = true;
                        ManagerCreateVisibilityControl = Visibility.Visible;
                    }));
            }
        }

        private RelayCommand _delete { get; set; }

        public RelayCommand Delete
        {
            get
            {
                return _delete ??
                    (_delete = new RelayCommand(x =>
                    {
                        CybersportAppNavigation.CurrentDeleteProfileWindow = new DeleteProfileWindow();
                        CybersportAppNavigation.CurrentDeleteProfileWindow.Show();
                    }));
            }
        }

        private RelayCommand _changeTeam { get; set; }

        public RelayCommand ChangeTeam
        {
            get
            {
                return _changeTeam ??
                    (_changeTeam = new RelayCommand(x =>
                    {
                        if (CybersportAppNavigation.CurrentUser.RoleId == 3)
                        {
                            SaveOtherIsEnabledControl = true;
                            SaveOtherVisibilityControl = Visibility.Visible;
                        }
                        else
                        {
                            SaveIsEnabledControl = true;
                            SaveVisibilityControl = Visibility.Visible;
                        }

                        ManagerCreateIsEnabledControl = false;
                        ManagerCreateVisibilityControl = Visibility.Hidden;

                        TeamChangeIsEnabledControl = true;
                        TeamChangeVisibilityControl = Visibility.Visible;

                        TeamsCollection = CybersportCore.GetTeamsCollection();
                    }));
            }
        }

        public ProfileMenuVM()
        {
            Login = CybersportAppNavigation.CurrentUser.Login;
            FullName = $"{CybersportAppNavigation.CurrentUser.LastName} " +
                $"{CybersportAppNavigation.CurrentUser.Name} " +
                $"{CybersportAppNavigation.CurrentUser.SecondName}";
            BirthDate = CybersportAppNavigation.CurrentUser.BirthDate.ToString().Substring(0, 10);

            Country = GetCountry(CybersportAppNavigation.CurrentUser.CountryId);
            Team = CybersportCore.GetTeam(CybersportAppNavigation.CurrentUser.TeamId);
            Photo = CybersportAppNavigation.CurrentUser.Photo;

            DeleteIsEnabledControl = true;
            DeleteVisibilityControl = Visibility.Visible;
            AnotherUserDetailsIsEnabledControl = false;
            AnotherUserDetailsVisibilityControl = Visibility.Hidden;
            VisibilityControl = Visibility.Visible;
            IsEnabledControl = true;
            AnotherUserIsEnabledControl = false;
            AnotherUserVisibilityControl = Visibility.Hidden;
            ManagerIsEnabledControl = false;
            ManagerVisibilityControl = Visibility.Hidden;
            TeamChangeIsEnabledControl = false;
            TeamChangeVisibilityControl = Visibility.Hidden;
            SaveIsEnabledControl = false;
            SaveVisibilityControl = Visibility.Hidden;
            SaveOtherIsEnabledControl = false;
            SaveOtherVisibilityControl = Visibility.Hidden;
            InviteIsEnabledControl = false;
            InviteVisibilityControl = Visibility.Hidden;
            ManagerCreateIsEnabledControl = false;
            ManagerCreateVisibilityControl = Visibility.Hidden;
            AdminIsEnabledControl = false;
            AdminVisibilityControl = Visibility.Hidden;

            if (CybersportAppNavigation.CurrentUser.RoleId == 1)
            {
                AdminIsEnabledControl = true;
                AdminVisibilityControl = Visibility.Visible;
            }
            
            if(Team == "No Team")
            {
                LeaveTeamIsEnabledControl = false;
                LeaveTeamVisibilityControl = Visibility.Hidden;
            }
            else
            {
                LeaveTeamIsEnabledControl = true;
                LeaveTeamVisibilityControl = Visibility.Visible;
            }

            if (CybersportAppNavigation.CurrentUser.RoleId == 3)
            {
                ManagerIsEnabledControl = true;
                ManagerVisibilityControl = Visibility.Visible;
                ManagerCreateIsEnabledControl = true;
                ManagerCreateVisibilityControl = Visibility.Visible;
                LeaveTeamIsEnabledControl = false;
                LeaveTeamVisibilityControl = Visibility.Hidden;
            }           
        }

        public ProfileMenuVM(string login)
        {
            var user = CybersportCore.GetUser(login);

            Login = user.Login;
            FullName = $"{user.LastName} " +
                $"{user.Name} " +
                $"{user.SecondName}";
            BirthDate = user.BirthDate.ToString().Substring(0, 10);

            Country = GetCountry(user.CountryId);
            Team = CybersportCore.GetTeam(user.TeamId);
            Photo = user.Photo;

            DeleteIsEnabledControl = false;
            DeleteVisibilityControl = Visibility.Hidden;
            VisibilityControl = Visibility.Hidden;
            IsEnabledControl = false;
            AnotherUserIsEnabledControl = true;
            AnotherUserVisibilityControl = Visibility.Visible;
            ManagerIsEnabledControl = false;
            ManagerVisibilityControl = Visibility.Hidden;
            TeamChangeIsEnabledControl = false;
            TeamChangeVisibilityControl = Visibility.Hidden;
            SaveIsEnabledControl = false;
            SaveVisibilityControl = Visibility.Hidden;
            SaveOtherIsEnabledControl = false;
            SaveOtherVisibilityControl = Visibility.Hidden;
            ManagerCreateIsEnabledControl = false;
            ManagerCreateVisibilityControl = Visibility.Hidden;
            LeaveTeamIsEnabledControl = false;
            LeaveTeamVisibilityControl = Visibility.Hidden;
            AdminIsEnabledControl = false;
            AdminVisibilityControl = Visibility.Hidden;

            if (user.RoleId != 2)
            {
                AnotherUserDetailsIsEnabledControl = false;
                AnotherUserDetailsVisibilityControl = Visibility.Hidden;
            }
            else
            {
                AnotherUserDetailsIsEnabledControl = true;
                AnotherUserDetailsVisibilityControl = Visibility.Visible;
            }

            if (CybersportAppNavigation.CurrentUser.RoleId == 3)
            {
                InviteVisibilityControl = Visibility.Visible;
                InviteIsEnabledControl = true;
                ManagerIsEnabledControl = true;
                ManagerVisibilityControl = Visibility.Visible;
                
            }
            else
            {
                InviteVisibilityControl = Visibility.Hidden;
                InviteIsEnabledControl = false;
            }

            UserId = user.UserId;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName));
        }

        private string GetCountry(int countryId)
        {
            if (CybersportCore.CountriesCollection == null)
                CybersportCore.GetCountries();

            return CybersportCore
                    .CountriesCollection
                    .Where(x =>
                    x.CountryId == countryId)
                    .FirstOrDefault()
                    .Name;
        }
    }
}
