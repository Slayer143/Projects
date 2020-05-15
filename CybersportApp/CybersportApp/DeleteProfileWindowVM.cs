using CybersportApp.Core;
using CybersportApp.Pages;
using System.ComponentModel;

namespace CybersportApp
{
    public class DeleteProfileWindowVM : INotifyPropertyChanged
    {
        private RelayCommand _delete { get; set; }

        public RelayCommand Delete
        {
            get
            {
                return _delete ??
                    (_delete = new RelayCommand(x =>
                    {
                        CybersportCore.DeleteUser(CybersportAppNavigation.CurrentUser.UserId);

                        CybersportAppNavigation.CurrentDeleteProfileWindow.Close();

                        if (CybersportAppNavigation.CurrentDialogueWindow != null)
                            CybersportAppNavigation.CurrentDialogueWindow.Close();

                        CybersportAppNavigation.CurrentWindow.Close();
                    }));
            }
        }

        private RelayCommand _abort { get; set; }

        public RelayCommand Abort
        {
            get
            {
                return _abort ??
                    (_abort = new RelayCommand(x =>
                    {
                        CybersportAppNavigation.CurrentDeleteProfileWindow.Close();
                    }));
            }
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
