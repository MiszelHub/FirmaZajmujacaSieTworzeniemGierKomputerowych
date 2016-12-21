using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WamesRepository;


namespace WamesGUI.ViewModel
{
    
    public class MainWindowViewModel : ViewModelBase
    {
        private ObservableCollection<departments> headQuarters;
        private ObservableCollection<string> test;
        private UnitOfWork unitOfWork;
        public MainWindowViewModel()
        {
            headQuarters = new ObservableCollection<departments>();
            unitOfWork = new UnitOfWork(new WamesModel());
            test = new ObservableCollection<string>();
            FillTEstData();
            RefreshEmployeeList();
            //foreach (var item in headQuarters)
            //    unitOfWork.BeginTransaction(() => unitOfWork.HeadQuarters.RemoveEntityFromDataBase(item));
            //test.Clear();
        }

        public ObservableCollection<string> HeadQuarters
        {
            get
            {
                return test;
            }

        }
        public departments SelectedHeadQuarters { get; set; }
        public void RefreshEmployeeList()
        {
            foreach (var item in unitOfWork.Departments.GetAllEtitiesFromDataBase())
            {
                headQuarters.Add(item);
                test.Add(item.ToString());
            }
        }
        public void FillTEstData()
        {

            unitOfWork.Departments.GetDepartmentsFormHeadQuarters("MainHeadQuarters");
        }
    }
   
}
