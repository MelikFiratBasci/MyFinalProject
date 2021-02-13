using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Concrete
{
    public class ErorResult :Result
    {
        public ErorResult(string message):base(false,message)
        {
            
        }
        public ErorResult() : base(false)
        {

        }
    }
}
