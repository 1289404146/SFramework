
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class MessageHelper
{
    public static void  TopMessage(string str)
    {
        Main.UIManager.OpenPanel<UIMessageLogic>(UIType.UIMessage).SetText(str);
    }
}
