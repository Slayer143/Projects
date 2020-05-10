using CybersportApp.Core.CybersportEntities;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace CybersportApp
{
    public static class CybersportAppNavigation
    {
        public static StackPanel MessageStack { get; set; }

        public static Page CurrentGreetingPage { get; set; }

        public static Page CurrentAuthorizationPage { get; set; }

        public static Page CurrentRegistrationPage { get; set; }

        public static Page CurrentProfileMenuPage { get; set; }

        public static Page CurrentUsersPage { get; set; }

        public static Page CurrentTeamsPage { get; set; }

        public static Page CurrentTournamentsPage { get; set; }

        public static Page CurrentDetailsPage { get; set; }

        public static Page CurrentMessagesPage { get; set; }

        public static MainWindow CurrentWindow {get;set;}

        public static DialogueStartWindow CurrentDialogueWindow { get; set; }

        public static Users CurrentUser { get; set; }

        public static PlayersInformation CurrentUserInfo { get; set; }

        public static NavigationService Service { get; set; }
    }
}
