using System;
using System.Collections.Generic;
using System.Windows;
using WpfApp2;

namespace WpfApp2
{
    public partial class GradeEditWindow : Window
    {
        public Grade Grade { get; set; }

        public GradeEditWindow(List<Student> students, Grade grade = null)
        {
            InitializeComponent();
            Grade = grade ?? new Grade();

            
            StudentComboBox.ItemsSource = students;
            StudentComboBox.DisplayMemberPath = "FirstName";

            if (Grade.Student != null)
                StudentComboBox.SelectedItem = Grade.Student;

            SubjectTextBox.Text = Grade.Subject;
            ScoreTextBox.Text = Grade.Score.ToString();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Grade.Student = (Student)StudentComboBox.SelectedItem;
            Grade.Subject = SubjectTextBox.Text;
            Grade.Score = int.Parse(ScoreTextBox.Text);
            Grade.Date = DateTime.Now;

            DialogResult = true;
            Close();
        }
    }
}
