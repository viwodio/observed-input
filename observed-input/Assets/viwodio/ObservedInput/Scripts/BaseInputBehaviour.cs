using UnityEngine;
using System.Collections;

namespace viwodio.InputSystem
{
    public abstract class BaseInputBehaviour : MonoBehaviour
    {
        [SerializeField] protected string inputKey;

        private BaseInput inputInstance;

        protected T GetInput<T>() where T : BaseInput
        {
            if (inputInstance != null && inputInstance.InputKey == inputKey)
                return inputInstance as T;

            inputInstance = ObservedInput<T>.GetInput(inputKey);
            return inputInstance as T;
        }
    }

    public abstract class BaseInputBehaviour<T> : BaseInputBehaviour
        where T : BaseInput
    {
        protected T GetInput()
        {
            return GetInput<T>();
        }
    }
}
