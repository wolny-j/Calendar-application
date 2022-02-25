using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    public class RecurringAppointment : SingleAppointment, ICalendarEntry
    {
        
        string _repeat;
        int _repeatNum;
        int _numberOfRepetitions;
        string _savedData;
        string _displayText;
        DateTime _start;
        

        public RecurringAppointment()
        {
            
        }

        public RecurringAppointment(DateTime start, int length, string subject, string location,
                                    int repeat, int numberOfRepetitions)
                                    : base(start, length, subject, location)
        {
            _repeatNum = repeat;
            _start = start; 
            _numberOfRepetitions = numberOfRepetitions;
            _savedData = subject + "|" + location + "|" + start.Year.ToString() + "|" + start.Month.ToString() +
                                "|" + start.Day.ToString() + "|" + start.Hour.ToString() + "|" + start.Minute.ToString() +
                                "|" + start.Second.ToString() + "|" + length.ToString() + "|" + repeat.ToString() + "|" + numberOfRepetitions.ToString();
            if (repeat == 0)
            {
                _repeat = "(Daily)";
            }
            else if (repeat == 1)
            {
                _repeat = "(Weekly)";
            }
            else if (repeat == 2)
            {
                _repeat = "(Monthly)";
            }
            else if (repeat == 3)
            {
                _repeat = "(Yearly)";
            }
            _displayText = subject +" " + location + " " +_repeat;
        }

        //When I'm using ICalendarEntry There is a problem in Save method in CalendarEntries Class
        public string SavedData
        {
            get
            {
                return _savedData;
            }
        }
         string ICalendarEntry.DisplayText
        {
            get
            {
                return _displayText;

            }

        }

        bool ICalendarEntry.OccursOnDate(DateTime date)
        {
            if (_repeatNum == 0)
            {
                for (double i = 0; i <= _numberOfRepetitions; i++)
                {
                    if (date.Date == _start.Date)
                    {
                        return true;
                    }
                    else if (date.Date == _start.AddDays(i).Date)
                    {
                        return true;
                    }

                }
                return false;

            }
            else if (_repeatNum == 1)
            {
                for (double i = 7; i <= (_numberOfRepetitions * 7); i = i + 7)
                {
                    if (date.Date == _start.Date)
                    {
                        return true;
                    }
                    else if (date.Date == _start.AddDays(i).Date)
                    {
                        return true;
                    }

                }
                return false;
            }

            else if (_repeatNum == 2)
            {
                for (int i = 1; i <= (_numberOfRepetitions); i = i + 1)
                {
                    if (date.Date == _start.Date)
                    {
                        return true;
                    }
                    else if (date.Date == _start.AddMonths(i).Date)
                    {
                        return true;
                    }

                }
                return false;

            }
            else if (_repeatNum == 3)
            {
                for (int i = 1; i <= (_numberOfRepetitions); i = i + 1)
                {
                    if (date.Date == _start.Date)
                    {
                        return true;
                    }
                    else if (date.Date == _start.AddYears(i).Date)
                    {
                        return true;
                    }

                }
                return false;

            }
            return false;




        }
    }
}
