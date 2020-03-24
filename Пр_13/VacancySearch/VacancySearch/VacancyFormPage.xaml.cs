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
    /// Interaction logic for VacancyForm.xaml
    /// </summary>
    public partial class VacancyFormPage : Page
    {
        private VacancyFormVM _vacancyVM { get; set; }

        private NewDbRepository _newDbRepository = new NewDbRepository();

        public VacancyFormPage(string subName, string posName)
        {
            InitializeComponent();

            _vacancyVM = new VacancyFormVM(subName, posName);

            this.DataContext = _vacancyVM;
        }

        private void BackButtonPressed(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void CheckEmpty()
        {
            if (_vacancyVM.LastName != string.Empty
                || _vacancyVM.LastName != null)
            {
                lName.Background = Brushes.White;
            }
            else
                lName.Background = Brushes.Red;

            if (_vacancyVM.Name != string.Empty
                    || _vacancyVM.Name != null)
            {
                name.Background = Brushes.White;
            }
            else
                name.Background = Brushes.Red;

            if (_vacancyVM.SecondName != string.Empty
                    || _vacancyVM.SecondName != null)
            {
                sName.Background = Brushes.White;
            }
            else
                sName.Background = Brushes.Red;

            if (_vacancyVM.Gender.ToString() != string.Empty
                    || _vacancyVM.Gender.ToString() != null)
            {
                gender.Background = Brushes.White;
            }
            else
                gender.Background = Brushes.Red;

            if (_vacancyVM.BirthDate != string.Empty
                    || _vacancyVM.BirthDate != null)
            {
                birthDate.Background = Brushes.White;
            }
            else
                birthDate.Background = Brushes.Red;

            if (_vacancyVM.EducationLevel != string.Empty
                    || _vacancyVM.EducationLevel != null)
            {
                educatuion.Background = Brushes.White;
            }
            else
                educatuion.Background = Brushes.Red;

            if (_vacancyVM.PhoneNumber != string.Empty
                    || _vacancyVM.PhoneNumber != null)
            {
                phoneNum.Background = Brushes.White;
            }
            else
                phoneNum.Background = Brushes.Red;
        }

        private void DateChanged(object sender, RoutedEventArgs e)
        {
            _vacancyVM.BirthDate = (sender as Calendar).SelectedDate.ToString();
        }

        private void EnterButtonPressed(object sender, RoutedEventArgs e)
        {
            CheckEmpty();

            if (_vacancyVM.PhoneNumber != string.Empty
                && _vacancyVM.EducationLevel != string.Empty
                && _vacancyVM.BirthDate != string.Empty
                && _vacancyVM.Gender.ToString() != string.Empty
                && _vacancyVM.LastName != string.Empty
                && _vacancyVM.Name != string.Empty
                && _vacancyVM.SecondName != string.Empty)
            {
                _newDbRepository.AddCandidate(
                    new Staff(
                        _vacancyVM.Name,
                        _vacancyVM.LastName,
                        _vacancyVM.SecondName,
                        _vacancyVM.Gender,
                        _vacancyVM.BirthDate,
                        _vacancyVM.EducationLevel,
                        _vacancyVM.PhoneNumber,
                        _vacancyVM.SubName,
                        _vacancyVM.PosName));

                NavigationService.GoBack();
            }
        }
    }
}
