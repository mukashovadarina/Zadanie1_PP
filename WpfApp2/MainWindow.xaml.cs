using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace WpfApp2
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Student> Students { get; set; }
        public ObservableCollection<Grade> Grades { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Students = new ObservableCollection<Student>();
            Grades = new ObservableCollection<Grade>();
            DataContext = this;
        }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            var editWindow = new StudentEditWindow();
            if (editWindow.ShowDialog() == true)
            {
                Students.Add(editWindow.Student);
            }
        }

        private void EditStudent_Click(object sender, RoutedEventArgs e)
        {
            if (StudentsDataGrid.SelectedItem is Student selectedStudent)
            {
                var editWindow = new StudentEditWindow(selectedStudent);
                if (editWindow.ShowDialog() == true)
                {
                    var index = Students.IndexOf(selectedStudent);
                    Students[index] = editWindow.Student;
                    StudentsDataGrid.Items.Refresh();
                }
            }
        }

        private void AddGrade_Click(object sender, RoutedEventArgs e)
        {
            if (Students.Count > 0)
            {              
                var studentsList = new List<Student>(Students);
                var editWindow = new GradeEditWindow(studentsList);
                if (editWindow.ShowDialog() == true)
                {
                    Grades.Add(editWindow.Grade);
                }
            }
        }

        private void EditGrade_Click(object sender, RoutedEventArgs e)
        {
            if (GradesDataGrid.SelectedItem is Grade selectedGrade)
            {   
                var studentsList = new List<Student>(Students);
                var editWindow = new GradeEditWindow(studentsList, selectedGrade);
                if (editWindow.ShowDialog() == true)
                {
                    var index = Grades.IndexOf(selectedGrade);
                    Grades[index] = editWindow.Grade;
                    GradesDataGrid.Items.Refresh();
                }
            }
        }

        private void Deletee_Click(object sender, RoutedEventArgs e)
        {
            if (GradesDataGrid.SelectedItem is Grade selectedGrade)
            {
                Grades.Remove(selectedGrade);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (StudentsDataGrid.SelectedItem is Student selectedStudent)
            {
                Students.Remove(selectedStudent);
            }
        }
    }
}