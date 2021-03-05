using UnityEngine;
using System.Collections;
using UnityEngine.Events;

namespace viwodio.InputSystem
{
    public class ButtonHandler : BaseButtonBehaviour
    {
        public UnityEvent OnPressDown;
        public UnityEvent OnPress;
        public UnityEvent OnPressUp;

        private void OnEnable()
        {
            GetInput().OnPressDown += OnPressDown.Invoke;
            GetInput().OnPress += OnPress.Invoke;
            GetInput().OnPressUp += OnPressUp.Invoke;
        }

        private void OnDisable()
        {
            GetInput().OnPressDown -= OnPressDown.Invoke;
            GetInput().OnPress -= OnPress.Invoke;
            GetInput().OnPressUp -= OnPressUp.Invoke;
        }
    }
}
