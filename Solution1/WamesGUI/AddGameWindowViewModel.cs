using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using WamesRepository;

namespace WamesGUI.ViewModel
{
    public class AddGameWindowViewModel : ViewModelBase
    {
        private ObservableCollection<genre> genres;
        private ObservableCollection<Team> teams;
        private ObservableCollection<string> genresText;
        private ObservableCollection<string> teamsText;
        private UnitOfWork unitOfWork;
        private ICommand _submitGameCommand;

        public AddGameWindowViewModel()
        {
            genres = new ObservableCollection<genre>();
            teams = new ObservableCollection<Team>();
            genresText = new ObservableCollection<string>();
            teamsText = new ObservableCollection<string>();
            unitOfWork = new UnitOfWork(new WamesModel());
            

            RefreshGenresList();
            RefreshTeamsList();
        }

        public ICommand SubmitCommand
        {
            get
            {
                if (_submitGameCommand == null)
                {
                    _submitGameCommand = new RelayCommand(
                        param => this.AddNewGame(),
                        param => CanAddNewGame()
                    );
                }
                return _submitGameCommand;
            }
        }

        private bool CanAddNewGame()
        {
            return Title != null;
        }

        private void AddNewGame()
        {
            games newGame = new games();
            newGame.id = 3;
            newGame.title = Title.ToString();
            newGame.price = Decimal.Parse(Price.ToString());
            for(int i=0; i<genres.Count(); i++)
            {
                if(SelectedGenre == i)
                {
                    newGame.genre = genres[i];
                }
            }
            
            for(int i=0; i<teams.Count(); i++)
            {
                if(SelectedTeam == i)
                {
                    newGame.Team = teams[i];
                }
            }
            
            unitOfWork.Games.AddEntityToDatabase(newGame);
        }

        public ObservableCollection<string> Genres
        {
            get
            {
                return genresText;
            }
        }

        public int SelectedGenre { get; set; }

        public ObservableCollection<string> Teams
        {
            get
            {
                return teamsText;
            }
        }

        public int SelectedTeam { get; set; }

        public string Title { get; set; }

        public string Price { get; set; }

        public void RefreshGenresList()
        {
            foreach(var item in unitOfWork.Genres.GetAllEtitiesFromDataBase())
            {
                genres.Add(item);
                genresText.Add(item.ToString());
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
    }
}
