using CybersportApp.Core;
using CybersportApp.Core.ModelsForList;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CybersportApp.Pages
{
    public class TeamsViewVM : INotifyPropertyChanged
    {
        private string _addRowHeight { get; set; }

        public string AddRowHeight
        {
            get { return _addRowHeight; }
            set
            {
                _addRowHeight = value;
                OnPropertyChanged("AddRowHeight");
            }
        }

        private string _lastRowHeight { get; set; }

        public string LastRowHeight
        {
            get { return _lastRowHeight; }
            set
            {
                _lastRowHeight = value;
                OnPropertyChanged("LastRowHeight");
            }
        }

        private bool _addIsEnableControl { get; set; }

        public bool AddIsEnableControl
        {
            get { return _addIsEnableControl; }
            set
            {
                _addIsEnableControl = value;
                OnPropertyChanged("AddIsEnableControl");
            }
        }

        private bool _addVisibilityControl { get; set; }

        public bool AddVisibilityControl
        {
            get { return _addVisibilityControl; }
            set
            {
                _addVisibilityControl = value;
                OnPropertyChanged("AddVisibilityControl");
            }
        }

        private ObservableCollection<TeamsForList> _teamsList { get; set; }

        public ObservableCollection<TeamsForList> TeamsList
        {
            get { return _teamsList; }
            set
            {
                _teamsList = value;
                OnPropertyChanged("TeamsList");
            }
        }

        public TeamsViewVM()
        {
            TeamsList = CybersportCore.GetTeams();

            if (CybersportAppNavigation.CurrentUser.RoleId != 1)
            {
                AddRowHeight = "0";
                LastRowHeight = "1*";
                AddVisibilityControl = false;
                AddIsEnableControl = false;
            }
            else
            {
                AddRowHeight = "9*";
                LastRowHeight = "91*";
                AddVisibilityControl = true;
                AddIsEnableControl = true;
            }
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
