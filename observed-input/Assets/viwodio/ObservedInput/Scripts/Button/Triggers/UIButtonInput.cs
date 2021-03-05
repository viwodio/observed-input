using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace viwodio.InputSystem
{
    [RequireComponent(typeof(Graphic))]
    public class UIButtonInput : BaseButtonBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private bool isPress;

        public void OnPointerDown(PointerEventData eventData)
        {
            isPress = true;
            GetInput().InvokeOnPressDown();
        }

        private void Update()
        {
            if (isPress)
            {
                GetInput().InvokeOnPress();
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            isPress = false;
            GetInput().InvokeOnPressUp();
        }

        private void OnDisable()
        {
            OnPointerUp(null);
        }
    }
}
