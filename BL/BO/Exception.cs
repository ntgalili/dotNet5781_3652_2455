﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    namespace BO
    {
        [Serializable]
        public class BadStationCodeException : Exception                                    //************העתקתי מהמורה לבדוק אם זה טוב ***************  
        {
            public int Code;
            public BadStationCodeException(string message, Exception innerException) :
                base(message, innerException) => Code = ((DO.BadStationCodeException)innerException).Code;
            public override string ToString() => base.ToString() + $", bad station code: {Code}";
        }

        [Serializable]
        public class BadLecturerIdException : Exception
        {
            public int ID;
            public BadLecturerIdException(string message, Exception innerException) :
                base(message, innerException) => ID = ((DO.BadPersonIdException)innerException).ID;
            public override string ToString() => base.ToString() + $", bad student id: {ID}";
        }
    }
}
