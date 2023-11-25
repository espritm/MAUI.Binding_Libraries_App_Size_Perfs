using CommunicationTool.Implementations;
using CommunicationTool.Interfaces;
using System;

namespace CommunicationTool;

// All the code in this file is included in all platforms.
public static class CommunicationToolUnbluModule
{
    static Lazy<ICommunicationToolService> _comToolModule = new Lazy<ICommunicationToolService>(() => CreateUnbluModule(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

    public static ICommunicationToolService Current
    {
        get
        {
            ICommunicationToolService result = _comToolModule.Value;
            if (result == null)
                throw new NotImplementedException("This functionality is not implemented in the portable version of this assembly. You should reference the CommunicationToolModule NuGet package from you main application project in order to reference the platform-specific implementation.");
            return result;
        }
    }

    static ICommunicationToolService CreateUnbluModule()
    {
        ICommunicationToolService result = new UnbluService();
        return result;
    }
}