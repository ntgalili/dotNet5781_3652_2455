using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
        public class BadLineCodeException : Exception                  
        {
            public int Code;
            public BadLineCodeException(string message, Exception innerException) :
            base(message, innerException) => Code = ((DO.BadLineCodeException)innerException).Code;
            public override string ToString() => base.ToString() + $", bad Line code: {Code}";
        }
    
}

