using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VacancySearch.Connection;

namespace VacancySearch
{
    /// <summary>
    /// Interaction logic for VacancySearch.xaml
    /// </summary>
    public partial class VacancySearchPage : Page
    {
        private VacancySearchVM _vacancyVM = new VacancySearchVM();

        private NewDbRepository _newDbRepository = new NewDbRepository();

        public VacancySearchPage()
        {
            InitializeComponent();

            _vacancyVM.Vacancies = _newDbRepository.GetVacancies();
            _vacancyVM.Header = "Свободные вакансии";

            this.DataContext = _vacancyVM;
            myView.ItemsSource = _vacancyVM.Vacancies;
        }

        private void VacancySelected(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(
                new VacancyFormPage(
                    (myView.SelectedItem as Vacancy).SubdivisionName, 
                    (myView.SelectedItem as Vacancy).PositionName));
        }
    }
}
