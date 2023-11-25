using System;
using Android.Content;
using Com.Unblu.Sdk.Core.Internal.Notification;
using Com.Unblu.Sdk.Core.Notification;

namespace CommunicationTool.Unblu.Platforms.Android.Internals
{
    internal class UBPUnbluNotificationApi : Java.Lang.Object, IUnbluNotificationApi
    {
        internal UBPUnbluNotificationApi()
        {
        }

        public string DeviceToken { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string IncomingCallsNotificationChannelId => throw new NotImplementedException();

        public string MissedCallsNotificationChannelId => throw new NotImplementedException();

        public string NewMessagesNotificationChannelId => throw new NotImplementedException();

	//newly added ?
        public bool OnMessageReceived(IUnbluNotification p0, Context p1)
        {
            throw new NotImplementedException();
        }

        public void SetIncomingCallsNotificationChannelId(Context p0, string p1)
        {
            throw new NotImplementedException();
        }

        public void SetMissedCallsNotificationChannelId(Context p0, string p1)
        {
            throw new NotImplementedException();
        }

        public void SetNewMessagesNotificationChannelId(Context p0, string p1)
        {
            throw new NotImplementedException();
        }
    }
}

