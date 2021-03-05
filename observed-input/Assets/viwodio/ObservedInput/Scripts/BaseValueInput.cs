using UnityEngine;
using System.Collections;
using System;

namespace viwodio.InputSystem
{
    public class BaseValueInput<TValue> : BaseInput
    {
        private TValue value;

        public event Action<TValue> OnValueChanged;

        public TValue GetValue() => value;

        public void SetValue(TValue value)
        {
            this.value = value;
            OnValueChanged?.Invoke(value);
        }
    }
}
