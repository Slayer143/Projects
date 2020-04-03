using System.Collections.ObjectModel;

namespace VacancyAppointment.Connection
{
    public interface IVacancies
    {
        ObservableCollection<VacancyToAppoint> GetVacancies();

        void Appoint(int staffId);
    }
}
