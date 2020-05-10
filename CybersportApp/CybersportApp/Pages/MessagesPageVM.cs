using CybersportApp.Core;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace CybersportApp.Pages
{
    public class MessagesPageVM : INotifyPropertyChanged
    {
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

        private string _recipientName { get; set; }

        public string RecipientName
        {
            get { return _recipientName; }
            set
            {
                _recipientName = value;
                OnPropertyChanged("RecipientName");
            }
        }

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

        private RelayCommand _goBack;
        public RelayCommand GoBack
        {
            get
            {
                return _goBack ??
                    (_goBack = new RelayCommand(x =>
                    {
                        if (CybersportAppNavigation.Service.CanGoBack)
                            CybersportAppNavigation.Service.GoBack();
                    }));
            }
        }

        private RelayCommand _sendMessage;
        public RelayCommand SendMessage
        {
            get
            {
                return _sendMessage ??
                    (_sendMessage = new RelayCommand(x =>
                    {
                        CybersportCore.SendMessage(CybersportAppNavigation.CurrentUser.UserId, Message, RecipientId);

                        foreach (var child in CybersportAppNavigation.MessageStack.Children)
                        {
                            foreach (var button in (child as StackPanel).Children)
                            {
                                if ((button as Button).Content.ToString() == RecipientName)
                                {
                                    (button as Button).RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                                }
                            }
                        }

                        Message = string.Empty;
                    }));
            }
        }

        public MessagesPageVM()
        {
            VisibilityControl = Visibility.Hidden;
            IsEnabledControl = false;
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
