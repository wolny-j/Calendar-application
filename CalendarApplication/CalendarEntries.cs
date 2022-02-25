using System;
using System.Collections.Generic;
using System.IO;

namespace Calendar
{
    public class CalendarEntries : List<ICalendarEntry>
     {

        public bool Load(string calendarEntriesFile)
        {
            // TODO.  Add your code to load the data from the file specified in
            //        calendarEntriesFile here.  You can edit the following two 
            //        lines if you wish.
            bool status = false;
            StreamReader inputFile = null;
            string inputLine;
            string[] readValues;
            ICalendarEntry appointment;

            try
            {
                inputFile = new StreamReader(calendarEntriesFile);
                if (inputFile != null)
                {
                    inputLine = inputFile.ReadLine();
                    while (inputLine != null)
                    {
                        readValues = inputLine.Split(new char[] { '|' });
                        if (readValues[0] == "A" || readValues[0] == "R")
                        {
                            if (readValues[0] == "A")
                            {
                                ICalendarEntry calendarEntry = appointment = new SingleAppointment(new DateTime(int.Parse(readValues[3]),
                                                                                int.Parse(readValues[4]),
                                                                                int.Parse(readValues[5]),
                                                                                int.Parse(readValues[6]),
                                                                                int.Parse(readValues[7]),
                                                                                int.Parse(readValues[8])),
                                                                                int.Parse(readValues[9]),
                                                                                readValues[1],
                                                                                readValues[2]);



                                this.Add(appointment);
                                status = true;
                            }
                            else if (readValues[0] == "R")
                            {
                                appointment = new RecurringAppointment(new DateTime(int.Parse(readValues[3]),
                                                                                int.Parse(readValues[4]),
                                                                                int.Parse(readValues[5]),
                                                                                int.Parse(readValues[6]),
                                                                                int.Parse(readValues[7]),
                                                                                int.Parse(readValues[8])),
                                                                                int.Parse(readValues[9]),
                                                                                readValues[1],
                                                                                readValues[2],
                                                                                int.Parse(readValues[10]),
                                                                                int.Parse(readValues[11]));
                                this.Add(appointment);
                                status = true;
                            }
                            else
                            {
                                status = false;
                            }

                        }
                        inputLine = inputFile.ReadLine();
                    }

                }

            }
            

            finally
            {
                if (inputFile != null)
                {
                    inputFile.Close();
                }
            }
            
            return status;
           
        }

        public bool Save(string calendarEntriesFile)
        {
            // TODO.  Add your code to save the collection to the file specified in
            //        calendarEntriesFile here.  You can edit the following two 
            //        lines if you wish.

            StreamWriter outputFile;
            string lineToOutput;
            bool status = false;
            
            try
            {
                outputFile = new StreamWriter(calendarEntriesFile, false);
                if (outputFile != null)
                {
                    foreach (ICalendarEntry appointment in this)
                    {
                        if (appointment is RecurringAppointment)
                        {

                            lineToOutput = "R" + "|" + ((RecurringAppointment)appointment).SavedData;
                        }
                        else
                        {
                            lineToOutput = "A" + "|" + appointment.SavedData;
                        }
                        outputFile.WriteLine(lineToOutput);
                    }
                    outputFile.Close();
                    status = true;
                }

            }
            catch
            { 
            }
            return status;
        }

        

        // Iterate through the collection, returning the calendar entries that
        // occur on the specified date

        public IEnumerable<ICalendarEntry> GetCalendarEntriesOnDate(DateTime date)
        {
            for (int i = 0; i < this.Count; i++ )
            {
                if (this[i].OccursOnDate(date))
                {
                    yield return this[i];                
                }
            }
        }
    }
}