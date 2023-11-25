using System;
namespace Com.Unblu.Sdk.Core.Internal.Visitor
{
    public partial interface ICoreApiModuleVisitor
    {
        public void IsAgentAvailable(global::Com.Unblu.Sdk.Core.Callback.ISuccessCallback p0);
        public void JoinConversation(string p0, global::Com.Unblu.Sdk.Core.Callback.ISuccessCallback p1, global::Com.Unblu.Sdk.Core.Internal.IUnbluApiErrorCallback p2);
        public void StartConversation(global::Com.Unblu.Sdk.Core.Internal.Visitor.Model.EInitialEngagementType p0, string? p1, global::Com.Unblu.Sdk.Core.Callback.ISuccessCallback p2, global::Com.Unblu.Sdk.Core.Internal.IUnbluApiErrorCallback p3);
        public void StartConversation(global::Com.Unblu.Sdk.Core.Internal.Visitor.Model.EInitialEngagementType p0, string? p1, global::Com.Unblu.Sdk.Core.Internal.Model.NewConversationRecipientStub? p2, global::Com.Unblu.Sdk.Core.Callback.ISuccessCallback p3, global::Com.Unblu.Sdk.Core.Internal.IUnbluApiErrorCallback p4);
    }
}