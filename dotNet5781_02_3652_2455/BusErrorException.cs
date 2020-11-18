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
    internal class BusErrorException : Exception
    {
        private int lineBus;
        public int LineBus { get => lineBus; private  set => lineBus = value; }
        public BusErrorException() : base() { }
        public BusErrorException(string message , int num) : base(message) { LineBus = num; }
        public BusErrorException(string message, Exception inner) : base(message, inner) { }
        override public string ToString() { return "Bus line number:" + LineBus + "\n"  + "BusErrorException:" + Message + "\n"; }
    }
    public class CodeErrorException : Exception
    {
        public CodeErrorException() : base() { }
        public CodeErrorException(string message) : base(message) {}
        public CodeErrorException(string message, Exception inner) : base(message, inner) { }
        //protected CodeErrorException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        // special constructor for our custom exception
        override public string ToString() { return "CodeErrorException:" + Message + "\n"; }
    }
    public class AddressErrorException : Exception
    {
        public AddressErrorException() : base() { }
        public AddressErrorException(string message) : base(message) { }
        public AddressErrorException(string message, Exception inner) : base(message, inner) { }
       // protected AddressErrorException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        // special constructor for our custom exception
        override public string ToString() { return "AddressErrorException:" + Message + "\n"; }
    }
    public class LineNumErrorException : Exception
    {
        public LineNumErrorException() : base() { }
        public LineNumErrorException(string message) : base(message) { }
        public LineNumErrorException(string message, Exception inner) : base(message, inner) { }
       // protected LineNumErrorException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        // special constructor for our custom exception
        override public string ToString() { return "LineNumErrorException:" + Message + "\n"; }
    }
    public class IndexErrorException : Exception
    {
        public IndexErrorException() : base() { }
        public IndexErrorException(string message) : base(message) { }
        public IndexErrorException(string message, Exception inner) : base(message, inner) { }
       // protected IndexErrorException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        // special constructor for our custom exception
        override public string ToString() { return "Index error exception" +"\n"; }
    }
    public class FindErrorException : Exception
    {
        string message;
        public FindErrorException() : base() { }
        public FindErrorException(string message) : base(message) { }
        public FindErrorException(string message, Exception inner) : base(message, inner) { }
     //   protected FindErrorException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        // special constructor for our custom exception
        override public string ToString() { return "Error find exception:" + message + "\n"; }
    }
    public class AddErrorException : Exception
    {
        string message;
        public AddErrorException() : base() { }
        public AddErrorException(string message) : base(message) { }
        public AddErrorException(string message, Exception inner) : base(message, inner) { }
       // protected AddErrorException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        // special constructor for our custom exception
        override public string ToString() { return "Add Error Exception:" + message + "\n"; }
    }
    public class RemoveErrorException:Exception
    {
        string message;
        public RemoveErrorException() : base() { }
        public RemoveErrorException(string message) : base(message) { }
        public RemoveErrorException(string message, Exception inner) : base(message, inner) { }
     //   protected RemoveErrorException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        override public string ToString() { return "Remove Error Exception:" + message + "\n"; }
    }
}
