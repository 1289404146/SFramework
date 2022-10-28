/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;

namespace DCET.Runtime
{
    public class RuntimeBinder
    {
        public static void BindAll()
        {
            UIObjectFactory.SetPackageItemExtension(Loading.URL, typeof(Loading));
            UIObjectFactory.SetPackageItemExtension(LoadingProgressBar.URL, typeof(LoadingProgressBar));
        }
    }
}