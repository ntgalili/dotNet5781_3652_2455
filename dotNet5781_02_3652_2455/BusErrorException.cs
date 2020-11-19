using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_3652_2455
{
    using System.CodeDom;
    using System.Runtime.Serialization;

    [Serializable]


    /// <summary>
    /// Exception for bus errors
    /// </summary>
    internal class BusErrorException : Exception
    {
        private int lineBus;
        public int LineBus { get => lineBus; private  set => lineBus = value; }
        public BusErrorException() : base() { }
        public BusErrorException(string message , int num) : base(message) { LineBus = num; }
        public BusErrorException(string message, Exception inner) : base(message, inner) { }
        override public string ToString() { return "Bus line number:" + LineBus + "\n"  + "BusErrorException:" + Message + "\n"; }
    }


    /// <summary>
    /// Exception for code errors
    /// </summary>
    public class CodeErrorException : Exception
    {
        public CodeErrorException() : base() { }
        public CodeErrorException(string message) : base(message) {}
        public CodeErrorException(string message, Exception inner) : base(message, inner) { }
  
        override public string ToString() { return "CodeErrorException:" + Message + "\n"; }
    }


    /// <summary>
    /// Exception for Address errors
    /// </summary>
    public class AddressErrorException : Exception
    {
        public AddressErrorException() : base() { }
        public AddressErrorException(string message) : base(message) { }
        public AddressErrorException(string message, Exception inner) : base(message, inner) { }
      
        override public string ToString() { return "AddressErrorException:" + Message + "\n"; }
    }


    /// <summary>
    /// Exception for Line Number errors
    /// </summary>
    public class LineNumErrorException : Exception
    {
        public LineNumErrorException() : base() { }
        public LineNumErrorException(string message) : base(message) { }
        public LineNumErrorException(string message, Exception inner) : base(message, inner) { }

        override public string ToString() { return "LineNumErrorException:" + Message + "\n"; }
    }



    /// <summary>
    /// Exception index errors
    /// </summary>
    public class IndexErrorException : Exception
    {
        public IndexErrorException() : base() { }
        public IndexErrorException(string message) : base(message) { }
        public IndexErrorException(string message, Exception inner) : base(message, inner) { }

        override public string ToString() { return "Index error exception" +"\n"; }
    }


    /// <summary>
    /// Exception for find errors
    /// </summary>
    public class FindErrorException : Exception
    {
        string message;
        public FindErrorException() : base() { }
        public FindErrorException(string message) : base(message) { }
        public FindErrorException(string message, Exception inner) : base(message, inner) { }

        override public string ToString() { return "Error find exception:" + message + "\n"; }
    }


    /// <summary>
    /// Exception for add errors
    /// </summary>
    public class AddErrorException : Exception
    {
        string message;
        public AddErrorException() : base() { }
        public AddErrorException(string message) : base(message) { }
        public AddErrorException(string message, Exception inner) : base(message, inner) { }

        override public string ToString() { return "Add Error Exception:" + message + "\n"; }
    }

    /// <summary>
    /// Exception for remove errors
    /// </summary>
    public class RemoveErrorException:Exception
    {
        string message;
        public RemoveErrorException() : base() { }
        public RemoveErrorException(string message) : base(message) { }
        public RemoveErrorException(string message, Exception inner) : base(message, inner) { }
 
        override public string ToString() { return "Remove Error Exception:" + message + "\n"; }
    }
}
