using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calendar.Entity.Calendar
{
    public class PrevNextMonthModel
    {
        private int _prevYear;
        private int _nextYear;
        private int _prevMonth;
        private int _nextMonth;
        private DateTime _date;

        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                NextMonth = _date.Month + 1;
                PrevMonth = _date.Month - 1;               
            }
        }
        public int NextMonth
        {
           get { return _nextMonth; }
           private set
            {
                if (value > 12)
                {
                    value = 1;                    
                }
                _nextYear = value == 1 ? _date.Year + 1 : _date.Year;
                _nextMonth = value; 
            }
        }
        public int PrevMonth
        {
            get { return _prevMonth; }
            private set
            {
                if (value == 0)
                {
                    value = 12;                    
                }
                _prevYear = value == 12 ? _date.Year - 1 : _date.Year;
                _prevMonth = value;
            }
        }
        public int NextYear
        {
            get { return _nextYear; }
            private set
            {
                _nextYear = value; 
            }
        }
        public int PrevYear
        {
            get { return _prevYear; }
            private set
            {
                
                _prevYear = value;
            }
        }

        public PrevNextMonthModel()
        {
            _nextYear = _date.Year;
            _prevYear = _date.Year;
        }

    }
}
