using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    abstract class BaseController
    {
        protected RequestCode requestCode = RequestCode.None;

        public RequestCode RequestCode {
            get
            {
                return requestCode;
            }
        }

        public virtual string DefaultHandle(string data,Client client,Server server) { return null; }
    }
