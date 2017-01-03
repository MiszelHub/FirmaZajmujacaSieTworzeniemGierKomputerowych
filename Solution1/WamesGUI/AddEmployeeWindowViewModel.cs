using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WamesRepository;

namespace WamesGUI.ViewModel
{
    public class AddEmployeeWindowViewModel : ViewModelBase
    {
        private UnitOfWork unitOfWork;
        private ObservableCollection<departments> departments;
        private ObservableCollection<string> departmentsText;

        public AddEmployeeWindowViewModel()
        {
            unitOfWork = new UnitOfWork(new WamesModel());
            departments = new ObservableCollection<departments>();
            departmentsText = new ObservableCollection<string>();

            RefreshDepartmentsList();
        }

        public ObservableCollection<string> Departments
        {
            get
            {
                return departmentsText;
            }
        }

        public ObservableCollection<string> SelectedDepartment { get; set; }

        public void RefreshDepartmentsList()
        {
            foreach (var item in unitOfWork.Departments.GetAllEtitiesFromDataBase())
            {
                departments.Add(item);
                departmentsText.Add(item.ToString());
            }
        }
    }
}
