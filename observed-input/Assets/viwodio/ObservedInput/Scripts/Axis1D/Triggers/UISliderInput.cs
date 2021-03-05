using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace viwodio.InputSystem
{
    [RequireComponent(typeof(Slider))]
    public class UISliderInput : BaseAxis1DBehaviour, IPointerUpHandler
    {
        [SerializeField] private float minValue = -1f;
        [SerializeField] private float maxValue = 1f;
        [SerializeField] private float idleValue = 0;
        [SerializeField] private float sensitivity = 1f;

        private Slider slider;
        private float value;

        private Slider GetSlider()
        {
            if (slider == null)
                slider = GetComponent<Slider>();

            return slider;
        }

        void OnEnable()
        {
            GetSlider().onValueChanged.AddListener(OnSliderValueChanged);
        }

        private void OnSliderValueChanged(float sliderValue)
        {
            value = sliderValue;
        }

        void OnDisable()
        {
            GetSlider().onValueChanged.RemoveListener(OnSliderValueChanged);
        }

        void Update()
        {
            float val = Mathf.MoveTowards(GetInput().GetValue(), value, sensitivity * Time.deltaTime);
            GetInput().SetValue(val);
        }

        void OnValidate()
        {
            GetSlider().minValue = minValue;
            GetSlider().maxValue = maxValue;
            idleValue = Mathf.Clamp(idleValue, minValue, maxValue);
            GetSlider().value = idleValue;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            value = idleValue;
            GetSlider().value = value;
        }
    }
}