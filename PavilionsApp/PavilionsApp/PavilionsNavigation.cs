using PavilionsApp.Connection.PavilionsEntities;
using PavilionsApp.Core.EntitiesForList;
using System.Windows.Navigation;

namespace PavilionsApp
{
    public static class PavilionsNavigation
    {
        public static NavigationService Service { get; set; }

        public static Employees CurrentUser { get; set; }

        public static ShoppingCentersForList ShoppingCenter { get; set; }

        public static int CenterCode { get; set; }

        public static PavilionsForList Pavilion { get; set; }

        public static int PavilionCode { get; set; }
    }
}
