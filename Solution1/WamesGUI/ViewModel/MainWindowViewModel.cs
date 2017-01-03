using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
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

        public MainWindowViewModel()
        {
            games = new ObservableCollection<games>();
            unitOfWork = new UnitOfWork(new WamesModel());
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
        public void RefreshEmployeeList()
        {
            if(SelectedDBTable != null)
            {
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
            }
           
            
        }
        public void FillTEstData()
        {

            unitOfWork.Games.GetGamesForSpecifiedPlatform("WIN");
            //unitOfWork.Games.GetGamesByGenre("Action");
        }
    }
   
}
