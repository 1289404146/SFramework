/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DCET.Hotfix
{
    public partial class FUILobby : GComponent
    {
        public GImage bg;
        public TitleButton enterButton;
        public const string URL = "ui://2w4fpdl4hbe5e";

        public static FUILobby CreateInstance()
        {
            return (FUILobby)UIPackage.CreateObject("Hotfix", "FUILobby");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GImage)GetChild("bg");
            enterButton = (TitleButton)GetChild("enterButton");
        }
    }
}