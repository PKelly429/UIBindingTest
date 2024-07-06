using System;

namespace DataBinding
{
    [Serializable]
    public class BindableString : BindableVariable<string>
    {
        public override string stringValue
        {
            get => GetValue();
            set => SetValue(value);
        }
    }
}