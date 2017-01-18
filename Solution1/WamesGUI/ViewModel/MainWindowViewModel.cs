using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WamesRepository;


namespace WamesGUI.ViewModel
{
    
    public class MainWindowViewModel : ViewModelBase
    {
        private ObservableCollection<games> games;
        private ObservableCollection<headquarters> headquarters;
        private ObservableCollection<string> test;
        private UnitOfWork unitOfWork;
        private ObservableCollection<string> tables;
        private ObservableCollection<string> availableFilters;
        private ICommand _closeCommand;
        private ICommand _addGameCommand;
        private ICommand _addEmployeeCommand;
        private ICommand _applyFilterCommand;

        public MainWindowViewModel()
        {
            games = new ObservableCollection<games>();
            unitOfWork = new UnitOfWork(new wamesEntities());
            test = new ObservableCollection<string>();
            tables = new ObservableCollection<string>();
            availableFilters = new ObservableCollection<string>();
            headquarters = new ObservableCollection<headquarters>();
            
            FillTEstData();
            RefreshEmployeeList();
            //foreach (var item in headQuarters)
            //    unitOfWork.BeginTransaction(() => unitOfWork.HeadQuarters.RemoveEntityFromDataBase(item));
            //test.Clear();

            //tables from DB
            tables.Add("Games");
            tables.Add("Available platforms");
            tables.Add("Departments");
            tables.Add("Employees");
            tables.Add("Genre");
            tables.Add("Headquarters");
            tables.Add("Positions");
            tables.Add("Teams");

            //available filters
            availableFilters.Add("GetGamesByGenre");
            availableFilters.Add("GetGamesMadeByTeam");
            availableFilters.Add("GetGamesWithPriceBelowGivenPrice");
            availableFilters.Add("GetGamesForSpecifiedPlatform");
            availableFilters.Add("GetDepartmentsFromHeadQuarters");
            availableFilters.Add("GetEmployeesByPositionName");
            availableFilters.Add("GetEmployeesFromDepartment");
            availableFilters.Add("GetEmployeesFromTheDepartmentWithSalaryHigherThanAverage");
            availableFilters.Add("GetEmployeesFromTeam");
            availableFilters.Add("GetTeamByGameTitle");
            availableFilters.Add("GetTopEarningEmployeeByPosition");
            availableFilters.Add("GetEmployeesFromHeadQuarters");
        }

        public ICommand CloseCommand
        {
            get
            {
                if (_closeCommand == null)
                {
                    _closeCommand = new RelayCommand(
                        param => this.CloseApplication()
                    );
                }
                return _closeCommand;
            }
        }

        private void CloseApplication()
        {
            Application.Current.Shutdown();
        }

        public ICommand AddGameCommand
        {
            get
            {
                if (_addGameCommand == null)
                {
                    _addGameCommand = new RelayCommand(
                        param => this.AddGame()
                    );
                }
                return _addGameCommand;
            }
        }

        private void AddGame()
        {
            Window addGameView = new AddGameWindow();
            addGameView.Show();
        }

        public ICommand AddEmployeeCommand
        {
            get
            {
                if (_addEmployeeCommand == null)
                {
                    _addEmployeeCommand = new RelayCommand(
                        param => this.AddEmployee()
                    );
                }
                return _addEmployeeCommand;
            }
        }

        private void AddEmployee()
        {
            Window addEmployeeView = new AddEmployeeWindow();
            addEmployeeView.Show();
        }

        public ICommand ApplyFilterCommand
        {
            get
            {
                if (_applyFilterCommand == null)
                {
                    _applyFilterCommand = new RelayCommand(
                        param => this.ApplyFilter()
                    );
                }
                return _applyFilterCommand;
            }
        }

        private void ApplyFilter()
        {
            test.Clear();

            if (SelectedFilter == "GetGamesByGenre")
            {
                foreach (var item in unitOfWork.Games.GetGamesByGenre(SelectedFilterValue.ToString()))
                {
                    games.Add(item);
                    test.Add(item.ToString());
                }
            }
            else if(SelectedFilter == "GetGamesMadeByTeam")
            {
                foreach (var item in unitOfWork.Games.GetGamesMadeByTeam(SelectedFilterValue.ToString()))
                {
                    games.Add(item);
                    test.Add(item.ToString());
                }
            }
            else if (SelectedFilter == "GetGamesWithPriceBelowGivenPrice")
            {
                foreach (var item in unitOfWork.Games.GetGamesWithPriceBelowGivenPrice(Decimal.Parse(SelectedFilterValue.ToString())))
                {
                    games.Add(item);
                    test.Add(item.ToString());
                }
            }
            else if (SelectedFilter == "GetGamesForSpecifiedPlatform")
            {
                foreach (var item in unitOfWork.Games.GetGamesForSpecifiedPlatform(SelectedFilterValue.ToString()))
                {
                    games.Add(item);
                    test.Add(item.ToString());
                }
            }
            else if (SelectedFilter == "GetDepartmentsFromHeadQuarters")
            {
                foreach (var item in unitOfWork.Departments.GetDepartmentsFormHeadQuarters(SelectedFilterValue.ToString()))
                {
                    test.Add(item.ToString());
                }
            }
            else if (SelectedFilter == "GetEmployeesByPositionName")
            {
                foreach (var item in unitOfWork.Employees.GetEmployeesByPositionName(SelectedFilterValue.ToString()))
                {
                    test.Add(item.ToString());
                }
            }
            else if (SelectedFilter == "GetEmployeesFromDepartment")
            {
                /*foreach (var item in unitOfWork.Employees.GetEmployeesFromDepartment(SelectedFilterValue.ToString(), "test"))
                {
                    test.Add(item.ToString());
                }*/
            }
            else if (SelectedFilter == "GetEmployeesFromTheDepartmentWithSalaryHigherThanAverage")
            {
                foreach (var item in unitOfWork.Employees.GetEmployeesFromTheDepartmentWithSalaryHigherThanAverage(SelectedFilterValue.ToString()))
                {
                    test.Add(item.ToString());
                }
            }
            else if (SelectedFilter == "GetEmployeesFromTeam")
            {
                foreach (var item in unitOfWork.Employees.GetEmployeesFromTeam(int.Parse(SelectedFilterValue.ToString())))
                {
                    test.Add(item.ToString());
                }
            }
            else if (SelectedFilter == "GetTeamByGameTitle")
            {
                foreach (var item in unitOfWork.Teams.GetTeamByGameTitle(SelectedFilterValue.ToString()))
                {
                    test.Add(item.ToString());
                }
            }
            else if (SelectedFilter == "GetTopEarningEmployeeByPosition")
            {
                foreach (var item in unitOfWork.Employees.GetTopEarningEmployeeByPosition(SelectedFilterValue.ToString()))
                {
                    test.Add(item.ToString());
                }
            }
            else if (SelectedFilter == "GetEmployeesFromHeadQuarters")
            {
                foreach (var item in unitOfWork.Employees.GetEmployeesFromHeadQuarters(SelectedFilterValue.ToString()))
                {
                    test.Add(item.ToString());
                }
            }

        }

        public ICommand ChangeAvailableTables
        {
            get
            {
                return new RelayCommand(p => RefreshEmployeeList());
            }
        }



        public ObservableCollection<string> HeadQuarters
        {
            get
            {
                return test;
            }

        }

        public ObservableCollection<string> DBTables
        {
            get
            {
                return tables;
            }
        }

        

        public ObservableCollection<string> Filters
        {
            get
            {
                return availableFilters;
            }
        }

        public string SelectedDBTable { get; set; }
        public string SelectedFilter { get; set; }
        public departments SelectedHeadQuarters { get; set; }
        public string SelectedFilterValue { get; set; }

        public void RefreshEmployeeList()
        {
            if(SelectedDBTable != null)
            {
                test.Clear();

                if (SelectedDBTable == "Games")
                {
                    foreach (var item in unitOfWork.Games.GetAllEtitiesFromDataBase())
                    {
                        games.Add(item);
                        test.Add(item.ToString());
                    }
                }
                else if (SelectedDBTable == "Headquarters")
                {
                    foreach (var item in unitOfWork.HeadQuarters.GetAllEtitiesFromDataBase())
                    {
                        //games.Add(item);
                        headquarters.Add(item);
                        test.Add(item.ToString());
                    }
                }
                else if (SelectedDBTable == "Departments")
                {
                    foreach (var item in unitOfWork.Departments.GetAllEtitiesFromDataBase())
                    {
                        //games.Add(item);
                        //headquarters.Add(item);
                        test.Add(item.ToString());
                    }
                }
                else if (SelectedDBTable == "Employees")
                {
                    foreach (var item in unitOfWork.Employees.GetAllEtitiesFromDataBase())
                    {
                        //games.Add(item);
                        //headquarters.Add(item);
                        test.Add(item.ToString());
                    }
                }
                else if (SelectedDBTable == "Genre")
                {
                    foreach (var item in unitOfWork.Genres.GetAllEtitiesFromDataBase())
                    {
                        //games.Add(item);
                        //headquarters.Add(item);
                        test.Add(item.ToString());
                    }
                }
                else if (SelectedDBTable == "Positions")
                {
                    foreach (var item in unitOfWork.Positions.GetAllEtitiesFromDataBase())
                    {
                        //games.Add(item);
                        //headquarters.Add(item);
                        test.Add(item.ToString());
                    }
                }
                else if (SelectedDBTable == "Teams")
                {
                    foreach (var item in unitOfWork.Teams.GetAllEtitiesFromDataBase())
                    {
                        //games.Add(item);
                        //headquarters.Add(item);
                        test.Add(item.ToString());
                    }
                }
                else if (SelectedDBTable == "Available platforms")
                {
                    foreach (var item in unitOfWork.AvailablePlatforms.GetAllEtitiesFromDataBase())
                    {
                        //games.Add(item);
                        //headquarters.Add(item);
                        test.Add(item.ToString());
                    }
                }
            }
           
            
        }
        public void FillTEstData()
        {

            unitOfWork.Games.GetGamesForSpecifiedPlatform("WIN");
            //unitOfWork.Games.GetGamesByGenre("Action");
        }
    }
   
}
