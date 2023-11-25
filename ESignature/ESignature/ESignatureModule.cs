using ESignature.Interfaces;
using ESignature.Implementations;

namespace ESignature;

// All the code in this file is included in all platforms.
public static class ESignatureModule
{
    static Lazy<IESignatureServices> _eSignatureModule = new Lazy<IESignatureServices>(() => CreateESignatureModule(), LazyThreadSafetyMode.PublicationOnly);

    public static IESignatureServices Current
    {
        get
        {
            IESignatureServices result = _eSignatureModule.Value;
            if (result == null)
                throw new NotImplementedException("This functionality is not implemented in the portable version of this assembly. You should reference the ESignatureModule NuGet package from you main application project in order to reference the platform-specific implementation.");
            return result;
        }
    }

    static IESignatureServices CreateESignatureModule()
    {
        ESignatureServices result = new ESignatureServices();
        return result;
    }
}