/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DCET.Hotfix
{
    public partial class FUILogin : GComponent
    {
        public GImage bg;
        public GImage contentBG;
        public GImage accountBg;
        public GTextInput accountInput;
        public GImage passwordBg;
        public GTextInput passwordInput;
        public FUITitleButton loginButton;
        public GGroup content;
        public const string URL = "ui://2w4fpdl4ofor0";

        public static FUILogin CreateInstance()
        {
            return (FUILogin)UIPackage.CreateObject("Hotfix", "Login");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GImage)GetChild("bg");
            contentBG = (GImage)GetChild("contentBG");
            accountBg = (GImage)GetChild("accountBg");
            accountInput = (GTextInput)GetChild("accountInput");
            passwordBg = (GImage)GetChild("passwordBg");
            passwordInput = (GTextInput)GetChild("passwordInput");
            loginButton = (FUITitleButton)GetChild("loginButton");
            content = (GGroup)GetChild("content");
        }
    }
}