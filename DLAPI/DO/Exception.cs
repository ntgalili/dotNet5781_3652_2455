using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO                         //************העתקתי מהמורה לבדוק אם זה טוב ***************
{
    [Serializable]
    public class BadStationCodeException : Exception
    {
        public int Code;
        public BadStationCodeException(int c) : base() => Code = c;
        public BadStationCodeException(int c, string message) :
            base(message) => Code = c;
        public BadStationCodeException(int c, string message, Exception innerException) :
            base(message, innerException) => Code = c;
        public override string ToString() => base.ToString() + $", Bad Station Code: {Code}";
    }
    public class BadLineCodeException : Exception
    {
        public int Code;
        public BadLineCodeException(int c) : base() => Code = c;
        public BadLineCodeException(int c, string message) :
            base(message) => Code = c;
        public BadLineCodeException(int c, string message, Exception innerException) :
            base(message, innerException) => Code = c;
        public override string ToString() => base.ToString() + $", Bad Line Code: {Code}";
    }
}

