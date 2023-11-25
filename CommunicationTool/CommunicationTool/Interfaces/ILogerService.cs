using System;
namespace CommunicationTool.Interfaces
{
	public interface ILogerService
    {
        void Init();
        void Init(string key);

        void LogError(System.Exception e);
        void LogError(System.Exception e, Dictionary<string, string> args);

        void LogEvent(string s, LogEventType logEventType);
        void LogEvent(string s, Dictionary<string, string> args, LogEventType logEventType);
        void LogEvent(string s, Dictionary<string, object> args, LogEventType logEventType);

        string PrintHistoryAsHTML();
    }

    public enum LogEventType
    {
        Private, Public
    }
}

