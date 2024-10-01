using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public class Grade
    {
        public Student Student { get; set; }
        public string Subject { get; set; }
        public int Score { get; set; }
        public DateTime Date { get; set; }
    }
}
