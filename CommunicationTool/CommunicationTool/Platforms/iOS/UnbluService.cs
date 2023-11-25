using System;
using System.Threading.Tasks;
using Foundation;
using CommunicationTool.Views;
using UIKit;
using UnbluProxy_FatFramework_to_DOTNET;
using System.Collections.Generic;
using CommunicationTool.Interfaces;

namespace CommunicationTool.Implementations
{
    public class UnbluService : ICommunicationToolService
    {
        private UnbluProxy UnbluProxyInstance;
        private ILogerService LogerService;

        public event EventHandler<EventArgs> UnreadMessageCountChanged;

        public async Task<Boolean> Initialize(ILogerService logerService, Dictionary<string, string> cookies, string urlServer, string apiKey)
        {
            this.LogerService = logerService;

            TaskCompletionSource<Boolean> taskCompletionSource = new TaskCompletionSource<Boolean>();

            try
            {
                NSDictionary<NSString, NSString> unbluCookies = new NSDictionary<NSString, NSString>();
                if (cookies != null)
                {
                    NSString[] keys = new NSString[cookies.Count];
                    NSString[] values = new NSString[cookies.Count];

                    int i = 0;
                    foreach (KeyValuePair<String, String> pair in cookies)
                    {
                        keys[i] = new NSString(pair.Key);
                        values[i] = new NSString(pair.Value);
                        i++;
                    }

                    unbluCookies = new NSDictionary<NSString, NSString>(keys, values);
                }

                //Instanciate Unblu Proxy
                UnbluProxyInstance = new UnbluProxy();

                //Configure Unblu
                bool isConfigured = UnbluProxyInstance.ConfigureApiWithCookiesInString(unbluCookies, urlServer, apiKey, true);

                //Start Unblu
                UnbluProxyInstance.StartWithCompletion(
                    (isSuccess, errMsg) =>
                    {
                        if (isSuccess)
                        {
                            //onSuccess
                            logerService?.LogEvent($"CommunicationToolModule - Unblu started successfuly.", LogEventType.Private);
                            taskCompletionSource.SetResult(true);
                        }
                        else
                        {
                            //onFailure
                            logerService?.LogEvent($"CommunicationToolModule - Could not Start unblu. isConfigured is {isConfigured}. ErrMsg is {errMsg}.", LogEventType.Private);
                            taskCompletionSource.SetResult(false);
                        }
                    });

                RegisterNativeNotification_UnreadMessageCountChanged();
            }
            catch (Exception e)
            {
                logerService?.LogError(e);
                taskCompletionSource.SetResult(false);
            }

            return await taskCompletionSource.Task;
        }

        public IComToolView GetView(float width = 400, float height = 600)
        {
            try
            {
                UIView unbluNativeView = UnbluProxyInstance.GetView();

                ComToolViewHandler mauiHandler = new ComToolViewHandler(width, height);
                mauiHandler.SetUnbluNativeView(unbluNativeView);

                ComToolView mauiView = new ComToolView();
                mauiView.Handler = mauiHandler;

                return mauiView;
            }
            catch (Exception e)
            {
                LogerService?.LogError(e);
                return null;
            }
        }

        public async Task<Boolean> OpenConversation(string conversationID)
        {
            TaskCompletionSource<Boolean> taskCompletionSource = new TaskCompletionSource<Boolean>();

            try
            {
                UnbluProxyInstance.OpenConversation(conversationID,
                (isSuccess, errMsg) =>
                {
                    if (isSuccess)
                        //onSuccess
                        taskCompletionSource.SetResult(true);
                    else
                    {
                        //onFailure
                        LogerService?.LogEvent($"CommunicationToolModule - Could not open conversation. ErrMsg is {errMsg}.", LogEventType.Private);
                        taskCompletionSource.SetResult(false);
                    }
                });
            }
            catch (Exception e)
            {
                LogerService?.LogError(e);
                taskCompletionSource.SetResult(false);
            }

            return await taskCompletionSource.Task;
        }

        public async Task<Boolean> OpenConversationOverview()
        {
            TaskCompletionSource<Boolean> taskCompletionSource = new TaskCompletionSource<Boolean>();

            try
            {
                UnbluProxyInstance.OpenConversationOverviewWithCompletion(
                    (isSuccess, errMsg) =>
                    {
                        if (isSuccess)
                            //onSuccess
                            taskCompletionSource.SetResult(true);
                        else
                        {
                            //onFailure
                            LogerService?.LogEvent($"CommunicationToolModule - Could not open conversations overview. ErrMsg is {errMsg}.", LogEventType.Private);
                            taskCompletionSource.SetResult(false);
                        }
                    });
            }
            catch (Exception e)
            {
                LogerService?.LogError(e);
                taskCompletionSource.SetResult(false);
            }

            return await taskCompletionSource.Task;
        }

        public async Task<Boolean> StartAudioCall(string conversationID)
        {
            TaskCompletionSource<Boolean> taskCompletionSource = new TaskCompletionSource<Boolean>();

            try
            {
                UnbluProxyInstance.StartAudioCall(conversationID,
                (isSuccess, errMsg) =>
                {
                    if (isSuccess)
                        //onSuccess
                        taskCompletionSource.SetResult(true);
                    else
                    {
                        //onFailure
                        LogerService?.LogEvent($"CommunicationToolModule - Could not start audio call. ErrMsg is {errMsg}.", LogEventType.Private);
                        taskCompletionSource.SetResult(false);
                    }
                });
            }
            catch (Exception e)
            {
                LogerService?.LogError(e);
                taskCompletionSource.SetResult(false);
            }

            return await taskCompletionSource.Task;
        }

        public async Task<Boolean> StartVideoCall(string conversationID)
        {
            TaskCompletionSource<Boolean> taskCompletionSource = new TaskCompletionSource<Boolean>();

            try
            {
                UnbluProxyInstance.StartVideoCall(conversationID,
                (isSuccess, errMsg) =>
                {
                    if (isSuccess)
                        //onSuccess
                        taskCompletionSource.SetResult(true);
                    else
                    {
                        //onFailure
                        LogerService?.LogEvent($"CommunicationToolModule - Could not start video call. ErrMsg is {errMsg}." , LogEventType.Private);
                        taskCompletionSource.SetResult(false);
                    }
                });
            }
            catch (Exception e)
            {
                LogerService?.LogError(e);
                taskCompletionSource.SetResult(false);
            }

            return await taskCompletionSource.Task;
        }

        public async Task<Boolean> IsInitialized()
        {
            if (UnbluProxyInstance == null)
                return false;

            TaskCompletionSource<Boolean> taskCompletionSource = new TaskCompletionSource<Boolean>();

            try
            {
                UnbluProxyInstance.IsInitializedWithCompletion(
                (isInit) =>
                {
                    taskCompletionSource.SetResult(isInit);
                });
            }
            catch (Exception e)
            {
                LogerService?.LogError(e);
                taskCompletionSource.SetResult(false);
            }

            return await taskCompletionSource.Task;
        }

        public async Task<Boolean> Stop()
        {
            TaskCompletionSource<Boolean> taskCompletionSource = new TaskCompletionSource<Boolean>();

            try
            {
                UnbluProxyInstance.StopWithCompletion(
                (isSuccess, errMsg) =>
                {
                    if (isSuccess)
                        //onSuccess
                        taskCompletionSource.SetResult(true);
                    else
                    {
                        //onFailure
                        LogerService?.LogEvent($"CommunicationToolModule - Could not stop Unblu. ErrMsg is {errMsg}.", LogEventType.Private);
                        taskCompletionSource.SetResult(false);
                    }
                });
            }
            catch (Exception e)
            {
                LogerService?.LogError(e);
                taskCompletionSource.SetResult(false);
            }

            return await taskCompletionSource.Task;
        }

        public int GetUnreadMessagesCount()
        {
            try
            {
                if (UnbluProxyInstance == null)
                    return 0;
                else
                    return UnbluProxyInstance.UnreadMessageCount;
            }
            catch (Exception e)
            {
                LogerService?.LogError(e);
                return 0;
            }
        }




        //public static let VALUE_UNREAD_MESSAGES_COUNT: String on Unblu old version, a internal notif was fired and code below was used.

        private void RegisterNativeNotification_UnreadMessageCountChanged()
        {
            NSString notificationName = new NSString(UnbluProxy.NOTIFICATION_NAME_UNREAD_MESSAGE_COUNT_CHANGED); // ou "ubp.unbluproxy.unread.message.count.changed"

            NSNotificationCenter.DefaultCenter.AddObserver(notificationName, (n) => ProcessNativeNotificationReceived_UnreadMessageCountChanged(n));
        }

        private void ProcessNativeNotificationReceived_UnreadMessageCountChanged(NSNotification nativeNotificationReceived)
        {
            NSDictionary notificationPayload = nativeNotificationReceived.UserInfo;

            NSString countKey = new NSString("count");

            NSObject countObject = notificationPayload.ValueForKey(countKey);

            NSNumber countNumber = countObject as NSNumber;

            int count = countNumber.Int32Value;

            UnreadMessageCountChanged?.Invoke(this, new UnreadMessageCountChangedEventArgs(count));
        }

        public class UnreadMessageCountChangedEventArgs : EventArgs
        {
            public int Count { get; set; }
            public UnreadMessageCountChangedEventArgs(int count)
            {
                Count = count;
            }
        }
    }
}

