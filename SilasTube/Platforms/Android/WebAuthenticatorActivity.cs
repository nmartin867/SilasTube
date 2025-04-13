using Android.App;
using Android.Content.PM;
using Android.OS;

namespace SilasTube;

    [Activity(NoHistory = true, LaunchMode = LaunchMode.SingleTop, Exported = true)]
    [IntentFilter([Android.Content.Intent.ActionView], 
    Categories = [Android.Content.Intent.CategoryDefault, Android.Content.Intent.CategoryBrowsable],
    DataScheme = CALLBACK_SCHEME)]
    public class WebAuthenticatorActivity : WebAuthenticatorCallbackActivity
    {
         const string CALLBACK_SCHEME = "com.nmartindev.silastube.login";

         protected override void OnCreate(Bundle savedInstanceState)
         {
             base.OnCreate(savedInstanceState);
         }
}


