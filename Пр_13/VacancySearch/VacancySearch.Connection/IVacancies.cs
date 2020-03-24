using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacancySearch.Connection
{
    public interface IVacancies
    {
        ObservableCollection<Vacancy> GetVacancies();

        void AddCandidate(Staff candidate);
    }
}
