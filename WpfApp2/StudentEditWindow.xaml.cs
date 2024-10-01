using System.Windows;
using WpfApp2;

namespace WpfApp2
{
    public partial class StudentEditWindow : Window
    {
        public Student Student { get; set; }

        public StudentEditWindow(Student student = null)
        {
            InitializeComponent();
            Student = student ?? new Student();

            FirstNameTextBox.Text = Student.FirstName;
            LastNameTextBox.Text = Student.LastName;
            GroupTextBox.Text = Student.Group;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Student.FirstName = FirstNameTextBox.Text;
            Student.LastName = LastNameTextBox.Text;
            Student.Group = GroupTextBox.Text;

            DialogResult = true;
            Close();
        }
    }
}
