using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommunicationTool.Interfaces;
using CommunicationTool.Views;

namespace CommunicationTool.Implementations;

// All the code in this file is only included on Mac Catalyst.
public class UnbluService : ICommunicationToolService
{
    public IComToolView GetView(float width = 400, float height = 600)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Initialize(ILogerService logerService, Dictionary<string, string> cookies, string urlServer, string apiKey)
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

    public Task<Boolean> IsInitialized()
    {
        throw new NotImplementedException();
    }

    public Task<bool> Stop()
    {
        throw new NotImplementedException();
    }

    public int GetUnreadMessagesCount()
    {
        throw new NotImplementedException();
    }
}

