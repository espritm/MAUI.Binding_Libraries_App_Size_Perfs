using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommunicationTool.Interfaces
{
	public interface ICommunicationToolService
    {
        Task<Boolean> Initialize(ILogerService logerService, Dictionary<String, String> cookies, string urlServer, string apiKey);

        int GetUnreadMessagesCount();

        IComToolView GetView(float width = 400, float height = 600);

        Task<Boolean> OpenConversationOverview();

        Task<Boolean> OpenConversation(String conversationID);

        Task<Boolean> StartAudioCall(String conversationID);

        Task<Boolean> StartVideoCall(String conversationID);

        Task<Boolean> IsInitialized();

        Task<Boolean> Stop();
    }
}

