using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


[AttributeUsage(AttributeTargets.Class)]
public class ControllerAttribute : BaseAttribute
{
    RequestCode requestCode;
    public ControllerAttribute(RequestCode code )
    {
        this.requestCode = code;
    }
}
