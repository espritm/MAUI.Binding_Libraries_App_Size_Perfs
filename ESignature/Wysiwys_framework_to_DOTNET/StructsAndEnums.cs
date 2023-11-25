using ObjCRuntime;

namespace Wysiwys_framework_to_DOTNET
{
	[Native]
	public enum WYSDocumentState : long
	{
		NotExist = 0,
		Stored,
		Prepared,
		Signed
	}

	[Native]
	public enum WYSSignatureMode : long
	{
		Draw = 0,
		Image
	}

	[Native]
	public enum WYSResponseType : long
	{
		Accepted = 0,
		Refused
	}

	[Native]
	public enum WYSPDFSignatureControllerType : long
	{
		Default,
		Manage,
		Select
	}

	[Native]
	public enum WYSPDFControllerState : long
	{
		Initialized,
		ReadOnly,
		WillPrepare,
		IsPreparing,
		ConfirmationRequired
	}
}
