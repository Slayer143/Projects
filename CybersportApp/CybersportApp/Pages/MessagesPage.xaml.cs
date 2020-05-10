using CybersportApp.Core;
using CybersportApp.Core.CybersportEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CybersportApp.Pages
{
    /// <summary>
    /// Interaction logic for MessagesPage.xaml
    /// </summary>
    public partial class MessagesPage : Page
    {
        private List<Messages> _messages { get; set; }

        private List<Guid> _usersId { get; set; }

        private int _buttonNamePart = 0;

        private int _stackPanelNamePart = 0;

        private int _textBlockNamePart = 0;

        private int _stackPanelForTextBlocksNamePart = 0;

        private MessagesPageVM messagesVM { get; set; }

        public MessagesPage()
        {
            InitializeComponent();

            CybersportAppNavigation.MessageStack = firstStack;

            messagesVM = new MessagesPageVM();
            DataContext = messagesVM;

            _usersId = CybersportCore.GetUsersId(CybersportAppNavigation.CurrentUser.UserId);

            CreateDialoguesButtons();
        }

        private void CreateDialoguesButtons()
        {
            foreach (var userId in _usersId)
            {
                _buttonNamePart++;

                var button = new Button
                {
                    Name = "button" + _buttonNamePart.ToString(),
                    Content = CybersportCore.GetFullName(userId),
                    Width = 381,
                    Height = 50,
                    FontSize = 30,
                    Foreground = Brushes.Orchid,
                    Background = Brushes.Transparent,
                    BorderThickness = new Thickness(2),
                    BorderBrush = Brushes.DarkOrchid
                };
                button.Click += DialogueClick;

                _stackPanelNamePart++;

                var stackPanel = new StackPanel
                {
                    Name = "stackPanel" + _stackPanelNamePart.ToString(),
                    Orientation = Orientation.Horizontal
                };

                stackPanel.Children.Add(button);
                firstStack.Children.Add(stackPanel);
            }
        }

        private void DialogueClick(object sender, RoutedEventArgs e)
        {
            messagesVM.VisibilityControl = Visibility.Visible;
            messagesVM.IsEnabledControl = true;

            secondStack.Children.Clear();

            var id = CybersportCore.GetUserId((sender as Button).Content.ToString());
            messagesVM.RecipientId = id;
            messagesVM.RecipientName = (sender as Button).Content.ToString();

            _messages = CybersportCore.GetMessages(CybersportAppNavigation.CurrentUser.UserId, id);
            _messages = _messages.OrderBy(x => x.MessageTime).ToList();

            foreach (var message in _messages)
            {
                _textBlockNamePart++;

                var block = new TextBlock
                {
                    Name = "block" + _textBlockNamePart.ToString(),
                    Text = message.MessageText,
                    Foreground = Brushes.Orchid,
                    Background = Brushes.Transparent,
                    FontSize = 20,
                    Height = 50,
                    Width = 725
                };

                if (message.SenderId == CybersportAppNavigation.CurrentUser.UserId)
                    block.TextAlignment = TextAlignment.Right;

                _stackPanelForTextBlocksNamePart++;

                var stackPanel = new StackPanel
                {
                    Name = "stackPanel" + _stackPanelForTextBlocksNamePart.ToString(),
                    Orientation = Orientation.Horizontal
                };

                stackPanel.Children.Add(block);
                secondStack.Children.Add(stackPanel);
            }

            _textBlockNamePart = 0;
            _stackPanelForTextBlocksNamePart = 0;
        }
    }
}
