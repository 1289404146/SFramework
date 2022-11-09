/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DCET.Runtime
{
    public partial class LoadingProgressBar : GProgressBar
    {
        public GImage bg;
        public const string URL = "ui://1n4czledxzq96";

        public static LoadingProgressBar CreateInstance()
        {
            return (LoadingProgressBar)UIPackage.CreateObject("Runtime", "LoadingProgressBar");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GImage)GetChild("bg");
        }
    }
}