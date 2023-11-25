using System;
namespace ESignature.Implementations
{
	public interface ISettings
    {
        void Set(string key, string value);
        void Set(string key, int value);
        void Set(string key, bool value);
        string GetString(string key);
        string GetString(string key, string ShardedName);
        int GetInt(string key);
        bool GetBool(string key);
        void Remove(string key);
        void Remove(string key, string ShardedName);
        void RemoveAll(string key);
        Task SetSecure(string key, string value);
        Task<string> GetSecure(string key);
        void RemoveSecure(string key);
        void RemoveAllSecure();
    }
}

