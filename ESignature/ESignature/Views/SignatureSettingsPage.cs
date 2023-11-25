using System;
using ESignature.Interfaces;

namespace ESignature
{
    public class SignatureSettingsPage : ContentPage, ISignaturesSettingsPage
    {
#if IOS
        public UIKit.UITableViewController NativeViewController {get; set;}
#endif

        public SignatureSettingsPage()
        {
        }
    }
}