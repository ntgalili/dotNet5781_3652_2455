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
    public class BusErrorException : Exception
    {
        private int lineBus;
        public int LineBus { get => lineBus; private  set => lineBus = value; }
        public BusErrorException() : base() { }
        public BusErrorException(string message , int num) : base(message) { LineBus = num; }
        public BusErrorException(string message, Exception inner) : base(message, inner) { }
        protected BusErrorException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        // special constructor for our custom exception
        override public string ToString() { return "Bus line number:" + LineBus + "\n"  + "BusErrorException:" + Message + "\n"; }
    }
    public class CodeErrorException : Exception
    {
        public CodeErrorException() : base() { }
        public CodeErrorException(string message) : base(message) {}
        public CodeErrorException(string message, Exception inner) : base(message, inner) { }
        protected CodeErrorException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        // special constructor for our custom exception
        override public string ToString() { return "CodeErrorException:" + Message + "\n"; }
    }
    public class AddressErrorException : Exception
    {
        public AddressErrorException() : base() { }
        public AddressErrorException(string message) : base(message) { }
        public AddressErrorException(string message, Exception inner) : base(message, inner) { }
        protected AddressErrorException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        // special constructor for our custom exception
        override public string ToString() { return "CodeErrorException:" + Message + "\n"; }
    }
}
