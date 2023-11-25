using Com.Unblu.Sdk.Core.Configuration;
using Com.Unblu.Sdk.Core.Links;
using CommunicationTool.Unblu.Platforms.Android.Internals;
using Com.Unblu.Sdk.Core.Notification;
using Platform = Microsoft.Maui.ApplicationModel.Platform;
using Com.Unblu.Sdk.Core.Internal.Utils;
using Com.Unblu.Sdk.Core.Visitor;
using CommunicationTool.Views;
using Com.Unblu.Sdk.Module.Call;
using Com.Unblu.Sdk.Module.Mobilecobrowsing;
using CommunicationTool.Interfaces;

namespace CommunicationTool.Implementations;

// All the code in this file is only included on Android.
public class UnbluService : ICommunicationToolService
{
    ILogerService LogerService;
    IUnbluVisitorClient UnbluVisitorInstance;
    ICallModule UnbluCallModuleInstance;
    IMobileCoBrowsingModule UnbluCoBrowsingModuleInstance;

    public IComToolView GetView(float width = 400, float height = 600)
    {
        try
        {
            if (UnbluVisitorInstance == null)
                return null;

            Android.Views.View unbluNativeView = UnbluVisitorInstance.MainView;

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

    public async Task<Boolean> Initialize(ILogerService logerService, Dictionary<string, string> cookies, string urlServer, string apiKey)
    {
        this.LogerService = logerService;
        bool isConfigured = false;

        TaskCompletionSource<Boolean> taskCompletionSource = new TaskCompletionSource<Boolean>();

        try
        {
            ICollection<UnbluCookie> unbluCookies = new List<UnbluCookie>();
            if (cookies != null)
                foreach (KeyValuePair<string, string> pair in cookies)
                    unbluCookies.Add(new UnbluCookie(pair.Key, pair.Value));

            //Instanciate Unblu Native classes needed
            IUnbluPreferencesStorage unbluPreferencesStorage = IUnbluPreferencesStorage.CreateSharedPreferencesStorage(Platform.CurrentActivity.Application);
            IUnbluDownloadHandler unbluDownloadHandler = IUnbluDownloadHandler.CreateExternalStorageDownloadHandler(MauiApplication.Current);
            IUnbluExternalLinkHandler unbluExternalLinkHandler = new UnbluPatternMatchingExternalLinkHandler();
            IUnbluNotificationApi unbluNotificationApi = IUnbluNotificationApi.CreateNotificationApi();                         //do we need UBPUnbluNotificationApi to get the notif for the number of unread message changed

            //Configure Unblu
            UnbluClientConfiguration.Builder configBuilder = new UnbluClientConfiguration.Builder(urlServer, apiKey, unbluPreferencesStorage, unbluDownloadHandler, unbluExternalLinkHandler);
            configBuilder.SetCustomCookies(unbluCookies);

            //Register unblu call module
            UnbluCallModuleInstance = CallModuleProvider.Create();
            configBuilder.RegisterModule(UnbluCallModuleInstance);

            //Register unblu call module
            UnbluCoBrowsingModuleInstance = MobileCoBrowsingModuleProvider.Create();
            configBuilder.RegisterModule(UnbluCoBrowsingModuleInstance);

            //Build the unblu configuration
            UnbluClientConfiguration config = configBuilder.Build();

            if (config != null)
                isConfigured = true;

            //Start Unblu
            Com.Unblu.Sdk.Core.Unblu.CreateVisitorClient(Platform.CurrentActivity.Application, Platform.CurrentActivity, config, unbluNotificationApi,
                new InitializeSuccessCallback((instance) =>
                {
                    //Success
                    LogerService?.LogEvent($"CommunicationToolModule - Unblu started successfuly.", LogEventType.Private);
                    UnbluVisitorInstance = instance;

                    taskCompletionSource.SetResult(true);
                }),
                new InitializeExceptionCallback(() =>
                {
                    //ConfigureNotCalled
                    LogerService?.LogEvent($"CommunicationToolModule - Could not Start unblu. isConfigured is {isConfigured}. ConfigureNotCalled.", LogEventType.Private);
                    taskCompletionSource.SetResult(false);
                },
                () =>
                {
                    //InErrorState
                    LogerService?.LogEvent($"CommunicationToolModule - Could not Start unblu. isConfigured is {isConfigured}. InErrorState.", LogEventType.Private);
                    taskCompletionSource.SetResult(false);
                },
                (errMsg) =>
                {
                    //InitFailed
                    LogerService?.LogEvent($"CommunicationToolModule - Could not Start unblu. isConfigured is {isConfigured}. ErrMsg is {errMsg}.", LogEventType.Private);
                    taskCompletionSource.SetResult(false);
                })
            );
        }
        catch (Exception e)
        {
            LogerService?.LogError(e);
            taskCompletionSource.SetResult(false);
        }

        return await taskCompletionSource.Task;
    }

    public async Task<Boolean> OpenConversation(string conversationID)
    {
        TaskCompletionSource<Boolean> taskCompletionSource = new TaskCompletionSource<Boolean>();

        try
        {
            /*this.UnbluVisitorInstance.OpenConversation(conversationID,
                null,
                //new UBPSuccessVoidCallback((res) =>
                //{
                //    //Success
                //    taskCompletionSource.SetResult(true);
                //}),
                new OpenConversationExceptionCallback(
                    () =>
                    {
                        //Not initialized
                        taskCompletionSource.SetResult(false);
                        LogerService?.LogEvent($"CommunicationToolModule - Could not open conversation. Unblu is not initialized.", LogEventType.Private);
                    },
                    (errMsg) =>
                    {
                        //Faild to open
                        LogerService?.LogEvent($"CommunicationToolModule - Could not open conversation. ErrMsg is {errMsg}.", LogEventType.Private);
                        taskCompletionSource.SetResult(false);
                    }));*/
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
            UnbluVisitorInstance.OpenConversationOverview(null,
                new OpenConversationOverviewExceptionCallback(
                    () =>
                    {
                        //Not initialized
                        taskCompletionSource.SetResult(false);
                        LogerService?.LogEvent($"CommunicationToolModule - Could not open conversation overview. Unblu is not initialized.", LogEventType.Private);
                    },
                    (errMsg) =>
                    {
                        //Faild to open
                        LogerService?.LogEvent($"CommunicationToolModule - Could not open conversation overview. ErrMsg is {errMsg}.", LogEventType.Private);
                        taskCompletionSource.SetResult(false);
                    }));
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
            //TODO : UnbluVisitorInstance.OpenConversation(conversationID), then in the success callback conversation.StartAudioCall()
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
            //TODO : UnbluVisitorInstance.OpenConversation(conversationID), then in the success callback conversation.StartVideoCall()
        }
        catch (Exception e)
        {
            LogerService?.LogError(e);
            taskCompletionSource.SetResult(false);
        }

        return await taskCompletionSource.Task;
    }

    public async Task<bool> Stop()
    {
        TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<Boolean>();

        try
        {
            UnbluVisitorInstance.DeinitClient(null,
                new DeinitializeExceptionCallback((errMsg) =>
                {

                    //OnDeinitFailed
                    LogerService?.LogEvent($"CommunicationToolModule - Could not stop Unblu. ErrMsg is {errMsg}.", LogEventType.Private);
                    taskCompletionSource.SetResult(false);
                }));

            //Waiting for the callback
            await Task.Delay(200);
        }
        catch (Exception e)
        {
            LogerService?.LogError(e);
            taskCompletionSource.SetResult(false);
        }

        taskCompletionSource.SetResult(true);
        return await taskCompletionSource.Task;
    }

    public async Task<Boolean> IsInitialized()
    {
        TaskCompletionSource<Boolean> taskCompletionSource = new TaskCompletionSource<Boolean>();

        try
        {
            bool result = UnbluVisitorInstance != null && UnbluVisitorInstance.IsDeInitialized == false;

            taskCompletionSource.SetResult(result);
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
            return UnbluVisitorInstance.UnreadMessagesCount;
        }
        catch (Exception e)
        {
            LogerService?.LogError(e);
            return 0;
        }
    }
}

