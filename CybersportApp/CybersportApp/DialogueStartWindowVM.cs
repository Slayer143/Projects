using CybersportApp.Core;
using CybersportApp.Pages;
using System;
using System.ComponentModel;

namespace CybersportApp
{
    public class DialogueStartWindowVM : INotifyPropertyChanged
    {
        private Guid _recipientId { get; set; }

        public Guid RecipientId
        {
            get { return _recipientId; }
            set
            {
                _recipientId = value;
                OnPropertyChanged("RecipientId");
            }
        }

        private string _message { get; set; }

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged("Message");
            }
        }

        private RelayCommand _deny { get; set; }

        public RelayCommand Deny
        {
            get
            {
                return _deny ??
                    (_deny = new RelayCommand(x =>
                    {
                        CybersportAppNavigation.CurrentDialogueWindow.Close();
                    }));
            }
        }

        private RelayCommand _send { get; set; }

        public RelayCommand Send
        {
            get
            {
                return _send ??
                    (_send = new RelayCommand(x =>
                    {
                        CybersportCore.SendMessage(CybersportAppNavigation.CurrentUser.UserId, Message, RecipientId);

                        CybersportAppNavigation.CurrentDialogueWindow.Close();
                    }));
            }
        }

        public DialogueStartWindowVM(Guid userId)
        {
            RecipientId = userId;
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
