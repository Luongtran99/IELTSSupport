using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Models
{
    public class Result
    {
        private int _code;

        private string _message;

        private object _obj;

        public Result(int code, string message, object obj)
        {
            _code = code;
            _message = message;
            _obj = obj;
        }

        public int Code
        {
            get
            {
                return this._code;
            }
            set
            {
                this._code = value;
            }
        }

        public string Message
        {
            get
            {
                return this._message;
            }
            set
            {
                this._message = value;
            }
        }

        public object Obj
        {
            get
            {
                return this._obj;
            }
            set
            {
                this._obj = value;
            }
        }
        
    }
}
