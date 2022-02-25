using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    public class SingleAppointment : ICalendarEntry
    {
        

        DateTime _start;
        int _length;
        string _subject;
        string _location;
        string _displayText;
        string _savedData;
        bool _occursOnDate;

        public SingleAppointment()
        {
            _start = DateTime.Today;
            _length = 0;
            _subject = "";
            _location = "";
            _occursOnDate = false;


        }
        public SingleAppointment(DateTime start, int length, string subject, string location)
        {
            _start = start;
            _length = length;
            _subject = subject;
            _location = location;
            _displayText = subject + " " + location;
            _savedData = subject + "|" + location + "|" + start.Year.ToString() + "|" + start.Month.ToString() +
                                 "|" + start.Day.ToString() + "|" + start.Hour.ToString() + "|" + start.Minute.ToString() +
                                 "|" + start.Second.ToString() + "|" + length.ToString();

        }


        DateTime ICalendarEntry.Start
        {
            
            get
            {
                return _start;
            }
        }

        int ICalendarEntry.Length
        {
           
            get 
            {

                return _length;
            }

        }

        string ICalendarEntry.DisplayText
        {
            get
            {
                return _displayText;

            }
            
        }

        string ICalendarEntry.SavedData
        {
            get
            { 
                return _savedData;
            }
        }

        bool ICalendarEntry.OccursOnDate(DateTime date)
        {
            
            if (date.Date == _start.Date)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
    }
}
