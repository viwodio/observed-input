using System;

namespace viwodio.InputSystem
{
    public class Button : BaseInput
    {
        public event Action OnPressDown;
        public event Action OnPress;
        public event Action OnPressUp;

        public void InvokeOnPressDown() => OnPressDown?.Invoke();
        public void InvokeOnPress() => OnPress?.Invoke();
        public void InvokeOnPressUp() => OnPressUp?.Invoke();

        public static Button GetButton(string inputKey)
        {
            return ObservedInput<Button>.GetInput(inputKey);
        }
    }
}