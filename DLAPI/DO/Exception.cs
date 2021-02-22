using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
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
    public class BadLineStationException : Exception
    {
        public int Code;
        public int LineNum;
        public BadLineStationException(int c, string message) :
        base(message) => Code = c;

        public BadLineStationException(int c, int l, string message) : base(message)
        { 
            Code = c;
            LineNum = l;
        }
        public override string ToString() => base.ToString() + $", Bad Line Station: Station code: {Code}, Line Num:{LineNum}";
    }
    public class BadAdjacentStetionsException : Exception
    {
        public int numS1;
        public int numS2;
        public BadAdjacentStetionsException(int num1,int num2) : base()
            {
                numS1 = num1;
                numS2 = num2;
            }
        public BadAdjacentStetionsException(int num1,int num2, string message) :
            base(message)
        {
            numS1 = num1;
            numS2 = num2;
        }
        public BadAdjacentStetionsException(int num1,int num2, string message, Exception innerException) :
            base(message, innerException)
        {
            numS1 = num1;
            numS2 = num2;
        }
        public override string ToString() => base.ToString() + $", Bad BadAdjacentStetionsException: {numS1},{numS2}";
    }



    public class XMLFileLoadCreateException : Exception
    {
       
        public XMLFileLoadCreateException(int c, string message) : base(message) { }
        public XMLFileLoadCreateException(string filePath, string message, Exception innerException) :
            base(message, innerException) { }
        public override string ToString() => base.ToString();
    }



    public class BadLineTripException : Exception
    {
        int code;
        public BadLineTripException(int c, string message) : base(message) { code = c; }
        public override string ToString() => base.ToString();
    }
    public class BadUserException : Exception
    {
        public string name;
        public BadUserException(string n) : base() => name = n;
        public BadUserException(string n, string message) :
            base(message) => name = n;
        public override string ToString() => base.ToString()+ name;
    }
}

