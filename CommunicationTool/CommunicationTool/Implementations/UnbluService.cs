using System;
using CommunicationTool.Interfaces;

namespace CommunicationTool.Implementations
{
#if ANDROID || IOS || MACCATALYST
#else
    public class UnbluService : ICommunicationToolService
    {
        public UnbluService()
        {
        }

        public int GetUnreadMessagesCount()
        {
            throw new NotImplementedException();
        }

        public IComToolView GetView(float width = 400, float height = 600)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Initialize(ILogerService logerService, Dictionary<string, string> cookies, string urlServer, string apiKey)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsInitialized()
        {
            throw new NotImplementedException();
        }

        public Task<bool> OpenConversation(string conversationID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> OpenConversationOverview()
        {
            throw new NotImplementedException();
        }

        public Task<bool> StartAudioCall(string conversationID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> StartVideoCall(string conversationID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Stop()
        {
            throw new NotImplementedException();
        }
    }
#endif
}

