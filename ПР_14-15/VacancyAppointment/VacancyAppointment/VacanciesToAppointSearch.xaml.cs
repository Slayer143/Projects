using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using VacancyAppointment.Connection;

namespace VacancyAppointment
{
    /// <summary>
    /// Interaction logic for VacanciesToAppointSearch.xaml
    /// </summary>
    public partial class VacanciesToAppointSearch : Page
    {
        private VacanciesToAppointSearchVM _searchVM = new VacanciesToAppointSearchVM();

        private NewDbRepository _repository = new NewDbRepository();

        public VacanciesToAppointSearch()
        {
            InitializeComponent();

            _searchVM.Header = "Candidates Search";

            _searchVM.Vacancies = _repository.GetVacancies();

            this.DataContext = _searchVM;
            myView.ItemsSource = _searchVM.Vacancies;
        }

        private void CandidateSelected(object sender, MouseEventArgs e)
        {
            appointButton.Visibility = System.Windows.Visibility.Visible;
        }

        private void AppointCandidate(object sender, RoutedEventArgs e)
        {
            _repository.Appoint((myView.SelectedItem as VacancyToAppoint).Id);

            _searchVM.Vacancies = _repository.GetVacancies();
            myView.ItemsSource = _searchVM.Vacancies;
        }
    }
}
