using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WamesRepository;


namespace WamesGUI.ViewModel
{
    
    public class MainWindowViewModel : ViewModelBase
    {
        private ObservableCollection<headquarters> headQuarters;
        private ObservableCollection<string> test;
        private UnitOfWork unitOfWork;
        public MainWindowViewModel()
        {
            headQuarters = new ObservableCollection<headquarters>();
            unitOfWork = new UnitOfWork(new WamesModel());
            test = new ObservableCollection<string>();
          //  FillTEstData();
            RefreshEmployeeList();
        }

        public ObservableCollection<string> HeadQuarters
        {
            get
            {
                return test;
            }

        }
        public headquarters SelectedHeadQuarters { get; set; }
        public void RefreshEmployeeList()
        {
            foreach (var item in unitOfWork.HeadQuarters.GetAllEtitiesFromDataBase())
            {
                headQuarters.Add(item);
                test.Add(item.ToString());
            }
        }
        public void FillTEstData()
        {
           
            headquarters head = new headquarters();
            head.headquarters_id = 1;
            head.headquarters_name = "testHeadquarters";
            head.city = "Lodz";
           
            unitOfWork.HeadQuarters.AddEntityToDatabase(head);
            unitOfWork.ProcesChanges();
        }   
    }
   
}
