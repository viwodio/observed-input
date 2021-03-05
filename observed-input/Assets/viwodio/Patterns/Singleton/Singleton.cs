using UnityEngine;
using System.Collections;

namespace viwodio.Patterns.Singleton
{
    public abstract class Singleton<T> : MonoBehaviour
    where T : MonoBehaviour
    {
        public static T Instance { get; private set; }

        protected abstract bool DontDestroy { get; }

        protected virtual void Awake()
        {
            RegisterInstance(this as T);
        }

        protected void RegisterInstance(T instance)
        {
            if (IsInstanceCreated)
            {
                Destroy(instance.gameObject);
                Debug.LogWarning(instance.GetType().FullName + " class is already registered as singleton");
            }
            else
            {
                Instance = instance;

                if (DontDestroy)
                {
                    DontDestroyOnLoad(instance.gameObject);
                }
            }
        }

        protected static void UnregisterInstance()
        {
            if (IsInstanceCreated)
            {
                Destroy(Instance.gameObject);
                Instance = null;
            }
        }

        public static bool IsInstanceCreated
        {
            get { return Instance != null; }
        }
    }
}
