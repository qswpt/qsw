using System;

namespace Framework.Common.Functions
{
    public class Singleton<T> where T : class, new()
    {
        private static T _instance = new T();

        public static T Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}
