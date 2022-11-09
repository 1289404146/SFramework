/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DCET.Hotfix
{
    public partial class TitleButton : GButton
    {
        public GImage bg;
        public const string URL = "ui://2w4fpdl4hbe5a";

        public static TitleButton CreateInstance()
        {
            return (TitleButton)UIPackage.CreateObject("Hotfix", "TitleButton");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GImage)GetChild("bg");
        }
    }
}