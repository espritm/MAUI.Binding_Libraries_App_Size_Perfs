using System;
using System.Collections.Generic;
using Com.Unblu.Sdk.Core;
using Com.Unblu.Sdk.Core.Configuration;

namespace CommunicationTool.Unblu.Platforms.Android.Internals
{
    public class PreferenceStorage : Java.Lang.Object, IUnbluPreferencesStorage
    {
        Dictionary<string, string> dictionnary = new Dictionary<string, string>();

        public string Get(string key)
        {
            string res = "";
            dictionnary.TryGetValue(key, out res);
            return res;
        }

        public void Put(string key, string value)
        {
            dictionnary.TryAdd(key, value);
        }
    }
}