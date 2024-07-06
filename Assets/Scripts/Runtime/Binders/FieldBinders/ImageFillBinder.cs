using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace DataBinding
{
    public class ImageFillBinder : AbstractBinder<float>
    {
        [SerializeField] private Image image;
        [BindingType(typeof(float))] [SerializeField] private BindingField target;
        [SerializeField] private bool smoothValue;
        [SerializeField] private float smoothTime;
        
        protected override BindingField BindingField => target;
        protected override void OnBindingValueChanged()
        {
            if (smoothValue)
            {
                image.DOFillAmount(bindableVariable.GetValue(), smoothTime);
            }
            else
            {
                image.fillAmount = bindableVariable.GetValue();   
            }
        }
        
        private void Awake()
        {
            if (image == null)
            {
                image = GetComponent<Image>();
            }

            if (smoothTime <= 0) smoothValue = false;
        }
        
#if UNITY_EDITOR
        public override void Reset()
        {
            base.Reset();
            image = GetComponent<Image>();
        }
#endif
    }
}
