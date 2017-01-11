using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WamesRepository;

namespace WamesGUI.ViewModel
{
    public class AddEmployeeWindowViewModel : ViewModelBase
    {
        private UnitOfWork unitOfWork;
        private ObservableCollection<departments> departments;
        private ObservableCollection<string> departmentsText;
        private ObservableCollection<Team> teams;
        private ObservableCollection<string> teamsText;
        private ObservableCollection<positions> positions;
        private ObservableCollection<string> positionsText;
        private ICommand _submitEmployeeCommand;

        public AddEmployeeWindowViewModel()
        {
            unitOfWork = new UnitOfWork(new WamesModel());
            departments = new ObservableCollection<departments>();
            departmentsText = new ObservableCollection<string>();
            teams = new ObservableCollection<Team>();
            teamsText = new ObservableCollection<string>();
            positions = new ObservableCollection<positions>();
            positionsText = new ObservableCollection<string>();

            RefreshDepartmentsList();
            RefreshTeamsList();
            RefreshPositionsList();
        }

        public ICommand SubmitCommand
        {
            get
            {
                if (_submitEmployeeCommand == null)
                {
                    _submitEmployeeCommand = new RelayCommand(
                        param => this.AddNewEmployee(),
                        param => CanAddNewEmployee()
                    );
                }
                return _submitEmployeeCommand;
            }
        }

        private bool CanAddNewEmployee()
        {
            return FirstName != null;
        }

        private void AddNewEmployee()
        {
            employees employee = new employees();
            employee.employee_id = 1;
            employee.first_name = FirstName.ToString();
            employee.last_name = LastName.ToString();
            employee.email = Email.ToString();
            employee.salary = Decimal.Parse(Salary.ToString());
            departments department = new departments();
            department.department_id = 1;
            department.department_name = SelectedDepartment.ToString();
            employee.departments = department;
            employee.department_id = 1;
            positions position = new positions();
            position.position_id = 2;
            position.position_name = SelectedPosition.ToString();
            employee.positions = position;
            employee.position_id = 2;
            Team team = new Team();
            team.team_id = 2;
            team.team_name = SelectedTeam.ToString();
            employee.Team = team;
            employee.team_id = 2;

            unitOfWork.Employees.AddEntityToDatabase(employee);
        }

        public ObservableCollection<string> Departments
        {
            get
            {
                return departmentsText;
            }
        }

        public string SelectedDepartment { get; set; }

        public ObservableCollection<string> Teams
        {
            get
            {
                return teamsText;
            }
        }

        public string SelectedTeam { get; set; }

        public ObservableCollection<string> Positions
        {
            get
            {
                return positionsText;
            }
        }

        public string SelectedPosition { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Salary { get; set; }

        public void RefreshDepartmentsList()
        {
            foreach (var item in unitOfWork.Departments.GetAllEtitiesFromDataBase())
            {
                departments.Add(item);
                departmentsText.Add(item.ToString());
            }
        }

        public void RefreshTeamsList()
        {
            foreach (var item in unitOfWork.Teams.GetAllEtitiesFromDataBase())
            {
                teams.Add(item);
                teamsText.Add(item.ToString());
            }
        }

        public void RefreshPositionsList()
        {
            foreach (var item in unitOfWork.Positions.GetAllEtitiesFromDataBase())
            {
                positions.Add(item);
                positionsText.Add(item.ToString());
            }
        }
    }
}
