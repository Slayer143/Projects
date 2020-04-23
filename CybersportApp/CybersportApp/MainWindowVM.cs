using CybersportApp.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CybersportApp
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        private bool _generalIsEnabledControl { get; set; }

        public bool GeneralIsEnabledControl
        {
            get { return _generalIsEnabledControl; }
            set
            {
                _generalIsEnabledControl = value;
                OnPropertyChanged("GeneralIsEnabledControl");
            }
        }

        private Visibility _exitVisibilityControl { get; set; }

        public Visibility ExitVisibilityControl
        {
            get { return _exitVisibilityControl; }
            set
            {
                _exitVisibilityControl = value;
                OnPropertyChanged("ExitVisibilityControl");
            }
        }

        private bool _exitIsEnableControl { get; set; }

        public bool ExitIsEnableControl
        {
            get { return _exitIsEnableControl; }
            set
            {
                _exitIsEnableControl = value;
                OnPropertyChanged("ExitIsEnableControl");
            }
        }

        private string _rowHeight { get; set; }

        public string RowHeight
        {
            get { return _rowHeight; }
            set
            {
                _rowHeight = value;
                OnPropertyChanged("RowHeight");
            }
        }

        private string _lastRowHeight { get; set; }

        public string LastRowHeight
        {
            get { return _lastRowHeight; }
            set
            {
                _lastRowHeight = value;
                OnPropertyChanged("LastRowHeight");
            }
        }

        private BitmapImage _backgroundImage { get; set; }

        public BitmapImage BackgroundImage
        {
            get { return _backgroundImage; }
            set
            {
                _backgroundImage = value;
                OnPropertyChanged("BackgroundImage");
            }
        }

        private int _columnRange { get; set; }

        public int ColumnRange
        {
            get { return _columnRange; }
            set
            {
                _columnRange = value;
                OnPropertyChanged("ColumnRange");
            }
        }

        private int _columnPosition { get; set; }

        public int ColumnPosition
        {
            get { return _columnPosition; }
            set
            {
                _columnPosition = value;
                OnPropertyChanged("ColumnPosition");
            }
        }

        private int _rowPosition { get; set; }

        public int RowPosition
        {
            get { return _rowPosition; }
            set
            {
                _rowPosition = value;
                OnPropertyChanged("RowPosition");
            }
        }

        private string _firstColumnWidth { get; set; }

        public string FirstColumnWidth
        {
            get { return _firstColumnWidth; }
            set
            {
                _firstColumnWidth = value;
                OnPropertyChanged("FirstColumnWidth");
            }
        }

        private RelayCommand _goToProfile { get; set; }

        public RelayCommand GoToProfile
        {
            get
            {
                return _goToProfile ??
                    (_goToProfile = new RelayCommand(x =>
                    {
                        if (CybersportAppNavigation.CurrentProfileMenuPage != null)
                            CybersportAppNavigation.Service.Navigate(CybersportAppNavigation.CurrentProfileMenuPage);
                        else
                        {
                            CybersportAppNavigation.CurrentProfileMenuPage = new ProfileMenu();
                            CybersportAppNavigation.Service.Navigate(CybersportAppNavigation.CurrentProfileMenuPage);
                        }
                    }));
            }
        }

        private RelayCommand _goToUsers { get; set; }

        public RelayCommand GoToUsers
        {
            get
            {
                return _goToUsers ??
                    (_goToUsers = new RelayCommand(x =>
                    {
                        if (CybersportAppNavigation.CurrentUsersPage != null)
                            CybersportAppNavigation.Service.Navigate(CybersportAppNavigation.CurrentUsersPage);
                        else
                        {
                            CybersportAppNavigation.CurrentUsersPage = new UsersViewPage();
                            CybersportAppNavigation.Service.Navigate(CybersportAppNavigation.CurrentUsersPage);
                        }
                    }));
            }
        }

        private RelayCommand _goToTeams { get; set; }

        public RelayCommand GoToTeams
        {
            get
            {
                return _goToTeams ??
                    (_goToTeams = new RelayCommand(x =>
                    {
                        if (CybersportAppNavigation.CurrentTeamsPage != null)
                            CybersportAppNavigation.Service.Navigate(CybersportAppNavigation.CurrentTeamsPage);
                        else
                        {
                            CybersportAppNavigation.CurrentTeamsPage = new TeamsViewPage();
                            CybersportAppNavigation.Service.Navigate(CybersportAppNavigation.CurrentTeamsPage);
                        }
                    }));
            }
        }

        private RelayCommand _goToTournaments { get; set; }

        public RelayCommand GoToTournaments
        {
            get
            {
                return _goToTournaments ??
                    (_goToTournaments = new RelayCommand(x =>
                    {
                        if (CybersportAppNavigation.CurrentTournamentsPage != null)
                            CybersportAppNavigation.Service.Navigate(CybersportAppNavigation.CurrentTournamentsPage);
                        else
                        {
                            CybersportAppNavigation.CurrentTournamentsPage = new TournamentsViewPage();
                            CybersportAppNavigation.Service.Navigate(CybersportAppNavigation.CurrentTournamentsPage);
                        }
                    }));
            }
        }

        private RelayCommand _goToDetails { get; set; }

        public RelayCommand GoToDetails
        {
            get
            {
                return _goToDetails ??
                    (_goToDetails = new RelayCommand(x =>
                    {
                        if (CybersportAppNavigation.CurrentDetailsPage != null)
                            CybersportAppNavigation.Service.Navigate(CybersportAppNavigation.CurrentDetailsPage);
                        else
                        {
                            CybersportAppNavigation.CurrentDetailsPage = new DetailsPage();
                            CybersportAppNavigation.Service.Navigate(CybersportAppNavigation.CurrentDetailsPage);
                        }
                    }));
            }
        }

        private RelayCommand _exitAgreement { get; set; }

        public RelayCommand ExitAgreement
        {
            get
            {
                return _exitAgreement ??
                    (_exitAgreement = new RelayCommand(x =>
                    {
                        ExitIsEnableControl = true;
                        ExitVisibilityControl = Visibility.Visible;

                        GeneralIsEnabledControl = false;
                    }));
            }
        }

        private RelayCommand _denyExit { get; set; }

        public RelayCommand DenyExit
        {
            get
            {
                return _denyExit ??
                    (_denyExit = new RelayCommand(x =>
                    {
                        ExitIsEnableControl = false;
                        ExitVisibilityControl = Visibility.Hidden;

                        GeneralIsEnabledControl = true;
                    }));
            }
        }

        private RelayCommand _exit { get; set; }

        public RelayCommand Exit
        {
            get
            {
                return _exit ??
                    (_exit = new RelayCommand(x =>
                    {
                        CybersportAppNavigation.CurrentUser = null;

                        if (CybersportAppNavigation.CurrentGreetingPage != null)
                            CybersportAppNavigation.Service.Navigate(CybersportAppNavigation.CurrentGreetingPage);
                        else
                        {
                            CybersportAppNavigation.CurrentGreetingPage = new GreetingPage();

                            CybersportAppNavigation.CurrentWindow.DataContext = new MainWindowVM();

                            CybersportAppNavigation.Service.Navigate(CybersportAppNavigation.CurrentGreetingPage);
                        }
                    }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowVM()
        {
            ColumnRange = 2;
            ColumnPosition = 0;
            FirstColumnWidth = "0";

            RowHeight = LastRowHeight = "0";

            ExitIsEnableControl = false;
            ExitVisibilityControl = Visibility.Hidden;

            GeneralIsEnabledControl = true;
        }

        public MainWindowVM(int userCode)
        {
            if (userCode != 2)
            {
                RowHeight = "1*";
                LastRowHeight = "0*";
            }
            else
                RowHeight = LastRowHeight = "1*";

            BackgroundImage = new BitmapImage();

            using (MemoryStream memory = new MemoryStream())
            {
                Properties.Resources.abstract_gradient_pink_purple_stripes_on_purple_background.Save(memory, ImageFormat.Jpeg);
                memory.Position = 0;
                BackgroundImage.BeginInit();
                BackgroundImage.StreamSource = memory;
                BackgroundImage.CacheOption = BitmapCacheOption.OnLoad;
                BackgroundImage.EndInit();
            }

            FirstColumnWidth = "1*";
            ColumnRange = 1;
            ColumnPosition = 3;
            RowPosition = 6;

            ExitIsEnableControl = false;
            ExitVisibilityControl = Visibility.Hidden;

            GeneralIsEnabledControl = true;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}
