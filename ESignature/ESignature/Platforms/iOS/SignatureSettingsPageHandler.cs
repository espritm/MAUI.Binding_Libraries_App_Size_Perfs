using System;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using UIKit;

namespace ESignature
{
    public partial class SignatureSettingsPageHandler : PageHandler
    {
        UITableViewController NativeSignatureSettingsUITableViewController;

        public void SetNativeSignatureSettingsUITableViewController(UITableViewController controller)
        {
            this.NativeSignatureSettingsUITableViewController = controller;
        }
    }
}

