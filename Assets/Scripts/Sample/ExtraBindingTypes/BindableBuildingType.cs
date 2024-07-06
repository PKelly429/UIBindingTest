using System;
using System.Collections;
using System.Collections.Generic;
using DataBinding;
using UnityEngine;

[Serializable]
public class BindableBuildingType : BindableEnum<BindableBuildingType.BuildingType>
{
    public enum BuildingType
    {
        House,
        Gathering,
        Manufacturing
    }
}
