/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DCET.Runtime
{
    public partial class Loading : GComponent
    {
        public GImage bg;
        public GTextField loadingText;
        public LoadingProgressBar loadingBar;
        public const string URL = "ui://1n4czledsfv94";

        public static Loading CreateInstance()
        {
            return (Loading)UIPackage.CreateObject("Runtime", "Loading");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GImage)GetChild("bg");
            loadingText = (GTextField)GetChild("loadingText");
            loadingBar = (LoadingProgressBar)GetChild("loadingBar");
        }
    }
}