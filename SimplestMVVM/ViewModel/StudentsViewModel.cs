using System;
using SimplestMVVM.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using SimplestMVVM.Commands;

namespace SimplestMVVM.ViewModel
{
    public class StudentsViewModel:ViewModelBase
    {
        public ObservableCollection<Student> StudentList { get; set; }
        public string SelectedStudent { get; set; }

        private ICommand _updateStudentNameCommand;
        public ICommand UpdateStudentNameCommand
        {
            get { return _updateStudentNameCommand; }
            set { _updateStudentNameCommand = value; }
        }       

        private string _selectedFirstName;
        public string SelectedFirstName 
        {
            get { return _selectedFirstName; }
            set
            {
                if (_selectedFirstName != value)
                {
                    _selectedFirstName = value;
                    RaisePropertyChanged("SelectedFirstName");                    
                }
            }
        }
        private string _selectedLastName;
        public string SelectedLastName
        {
            get { return _selectedLastName; }
            set
            {
                if (_selectedLastName != value)
                {
                    _selectedLastName = value;
                    RaisePropertyChanged("SelectedLastName");
                }
            }
        }
        private string _selectedCity;
        public string SelectedCity
        {
            get { return _selectedCity; }
            set
            {
                if (_selectedCity != value)
                {
                    _selectedCity = value;
                    RaisePropertyChanged("SelectedCity");
                }
            }
        }
       
        public StudentsViewModel()
        {
            UpdateStudentNameCommand = new DelegateCommand(new Action<object>(SelectedStudentDetails));
            StudentList = new ObservableCollection<Model.Student> 
            { 
                    new Student { FirstName = "Jenny",LastName="Diesel",City="NY"},
                    new Student { FirstName = "Harry",LastName="Potter",City="Hogwarts"},
                    new Student { FirstName = "Stuart",LastName="Little",City="California" },
                    new Student { FirstName = "Robert",LastName="Downey",City="California" }
            };           
          }


        public void SelectedStudentDetails(object parameter)
        {
            if (parameter != null)
            {
                SelectedFirstName = (parameter as SimplestMVVM.Model.Student).FirstName;
                SelectedLastName = (parameter as SimplestMVVM.Model.Student).LastName;
                SelectedCity = (parameter as SimplestMVVM.Model.Student).City;
            }
        }       
      
    }
}
