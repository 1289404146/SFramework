using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class BaseRequest
{
    protected RequestCode requestCode = RequestCode.None;
    protected ActionCode actionCode = ActionCode.None;
    protected Action<string> Action = null;
    protected Action<byte[]> ActionProtal = null;
    public void OnResponse(string data)
    {
        if (this.Action != null)
        {
            Action(data);
        }
    }
    public void OnResponseProtal(byte[] data)
    {
        if (this.ActionProtal != null)
        {
            ActionProtal(data);
        }
    }
}
