using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendar
{
    public partial class AppointmentForm : Form
    {
        SingleAppointment _appointment = null;
        public MainForm mainForm = new MainForm();
        public DateTime _date;
        
        
        public DateTime Date
        {
            set
            {
                _date = value;
            }
        }

           
        
        public ICalendarEntry Appointment
        {
            get
            {
                return _appointment;
                
            }
            
        }
        

            public AppointmentForm()
            {
            InitializeComponent();

            
                LengthBox.SelectedItem = "30";
                StartBox.SelectedItem = "12:00";



            }
        
        
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string subject = SubjectBox.Text;
            string location = LocationBox.Text;
            int length = int.Parse(LengthBox.Text);
            string timeString = StartBox.Text + ":00";
            string dateString = _date.ToShortDateString();
            string fullDateTimeString = dateString + " " + timeString;
            DateTime fullDateTime = Convert.ToDateTime(fullDateTimeString);
            
           
                _appointment = new SingleAppointment(fullDateTime, length, subject, location);
                DialogResult = DialogResult.OK;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void Update()
        {
            DateLabel.Text = _date.ToShortDateString();
            
        }
    }
}
