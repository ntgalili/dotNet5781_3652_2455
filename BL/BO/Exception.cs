using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BO
{
    [Serializable]
    public class BadStationCodeException : Exception
    {
        public int Code;
        public BadStationCodeException(string message, Exception innerException) :
            base(message, innerException) => Code = ((DO.BadStationCodeException)innerException).Code;
        public BadStationCodeException(int code, string message):
             base(message) => Code = code;
        public override string ToString() => base.ToString() + $", bad station code: {Code}";
    }
    public class BadLineCodeException : Exception
    {
        public int Code;
        public BadLineCodeException(string message, Exception innerException) :
        base(message, innerException) => Code = ((DO.BadLineCodeException)innerException).Code;
        public override string ToString() => base.ToString() + $", bad Line code: {Code}";
    }
    public class BadAdjacentStetionsException : Exception
    {
        public int numS1;
        public int numS2;
        public BadAdjacentStetionsException(int num1, int num2) : base()
        {
            numS1 = num1;
            numS2 = num2;
        }
        public BadAdjacentStetionsException(int num1, int num2, string message) :
            base(message)
        {
            numS1 = num1;
            numS2 = num2;
        }
        public BadAdjacentStetionsException(int num1, int num2, string message, Exception innerException) :
            base(message, innerException)
        {
            numS1 = num1;
            numS2 = num2;
        }
        public override string ToString() => base.ToString() + $", Bad BadAdjacentStetionsException: {numS1},{numS2}";
    }
    public class BadLineStationException : Exception
    {
        public int Code;
        public int LineNum;
        public BadLineStationException(int c, string message) :
        base(message) => Code = c;

        public BadLineStationException(int c, int l, string message,Exception ex) : base(message)
        {
            Code = c;
            LineNum = l;
        }
        public override string ToString() => base.ToString() + $", Bad Line Station: Station code: {Code}, Line Code:{LineNum}";

    }

    public class BadLineTripException : Exception
    {
        int code;
        public BadLineTripException(int c, string message) : base(message) { code = c; }
        public BadLineTripException(string message, Exception innerException) :
          base(message, innerException){ }
        public override string ToString() => base.ToString();
    }

    public class BadUserException : Exception
    {
        public string name;
        public BadUserException(string n) : base() => name = n;
        public BadUserException(string n, string message) :
            base(message) => name = n;
        public override string ToString() => base.ToString() + name;
    }
}

