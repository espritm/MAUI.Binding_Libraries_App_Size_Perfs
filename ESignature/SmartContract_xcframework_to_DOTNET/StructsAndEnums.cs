using ObjCRuntime;

namespace SmartContract_xcframework_to_DOTNET
{
	public enum Status : uint
	{
		Cancel,
		Error,
		Pending,
		Success,
		Timeout
	}

	public enum StatusError : uint
	{
		NotAllowed,
		ServiceFailure,
		UnrecoverableFailure
	}

	[Native]
	public enum SSCSignatureType : long
	{
		Text = 0,
		Draw,
		Image
	}
}
