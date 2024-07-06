using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Serialization;

namespace DataBinding
{
    public class LocalisedTMPBinder : TMPTextBinding
    {
        [SerializeField] private LocalizedString localisedString;
        protected override string GetBoundText()
        {
            return localisedString.GetLocalizedString(bindableVariable.stringValue);
        }
    }
}
