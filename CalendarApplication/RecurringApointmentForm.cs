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
    public partial class RecurringApointmentForm : Form
    {
        RecurringAppointment _appointment = null;
        public MainForm mainForm = new MainForm();
        public DateTime _date;
        




        public ICalendarEntry Appointment
        {
            get
            {
                return _appointment;
                
            }

        }
        public RecurringApointmentForm()
        {

            InitializeComponent();
            
            LengthBox.SelectedItem = "30";
            StartBox.SelectedItem = "12:00";
            FrequencyBox.SelectedItem = "Daily";

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            int frequency = 0;
            if (FrequencyBox.Text == "Daily")
            {
                frequency = 0;
            }
            else if (FrequencyBox.Text == "Weekly")
            {
                frequency = 1;
            }
            else if (FrequencyBox.Text == "Monthly")
            {
                frequency = 2;
            }
            else if (FrequencyBox.Text == "Yearly")
            {
                frequency = 3;
            }




            string repeat = RepeatBox.Text;
            string subject = SubjectBox.Text;
            string location = LocationBox.Text;
            int length = int.Parse(LengthBox.Text);
            if (repeat == "")
            {
                Warning.Text = "Enter a positive number less than 999";
                
            }
            else
            {
                int repeatInt = int.Parse(RepeatBox.Text);
                string timeString = StartBox.Text + ":00";
                string dateString = _date.ToShortDateString();
                string fullDateTImeString = dateString + " " + timeString;
                DateTime fullDateTime = Convert.ToDateTime(fullDateTImeString);
                if (repeatInt <= 0 || repeatInt > 999)
                {
                    Warning.Text = "Enter a positive number less than 999";
                    
                }
                else
                {
                    _appointment = new RecurringAppointment(fullDateTime, length, subject, location, frequency, repeatInt);
                    DialogResult = DialogResult.OK;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void LengthBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void Update()
        {
            DateLabel.Text = _date.ToShortDateString();

        }
    }
}
