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

        public AddGameWindowViewModel()
        {
            genres = new ObservableCollection<genre>();
            teams = new ObservableCollection<Team>();
            genresText = new ObservableCollection<string>();
            teamsText = new ObservableCollection<string>();
            unitOfWork = new UnitOfWork(new WamesModel());

            RefreshGenresList();
        }

        public ObservableCollection<string> Genres
        {
            get
            {
                return genresText;
            }
        }

        public ObservableCollection<string> SelectedGenre { get; set; }

        public void RefreshGenresList()
        {
            foreach(var item in unitOfWork.Genres.GetAllEtitiesFromDataBase())
            {
                genres.Add(item);
                genresText.Add(item.ToString());
            }
        }
    }
}
