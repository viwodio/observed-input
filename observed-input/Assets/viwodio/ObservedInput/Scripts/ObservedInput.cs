using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using viwodio.Patterns.Singleton;

namespace viwodio.InputSystem
{
    public class ObservedInput<TInput>
        where TInput : BaseInput
    {
        private static Dictionary<string, TInput> inputs = new Dictionary<string, TInput>();

        public static TInput GetInput(string inputKey)
        {
            return GetOrCreateInput(inputKey);
        }

        public static int GetInputCount() => inputs.Count;

        private static bool HasInput(string inputKey)
        {
            return inputs.ContainsKey(inputKey);
        }

        private static TInput GetOrCreateInput(string inputKey)
        {
            return HasInput(inputKey) ? inputs[inputKey] : CreateInput(inputKey);
        }

        private static TInput CreateInput(string inputKey)
        {
            var instance = Activator.CreateInstance<TInput>();
            instance.InputKey = inputKey;

            inputs.Add(inputKey, instance);
            return instance;
        }
    }
}
