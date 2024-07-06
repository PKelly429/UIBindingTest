using System;
using System.Collections;
using System.Collections.Generic;
using DataBinding;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(menuName = "BindingFunctions/BuildingTypeColour")]
public class BuildingTypeColorFunction : GraphicBindingFunction
{
    [Serializable]
    public struct BuildingTypeColour
    {
        public BindableBuildingType.BuildingType type;
        public Color color;
        public Sprite sprite;
    }

    [SerializeField] private List<BuildingTypeColour> colourMappings;

    private Dictionary<BindableBuildingType.BuildingType, Color> colourMappingLookup = new Dictionary<BindableBuildingType.BuildingType, Color>();
    private Dictionary<BindableBuildingType.BuildingType, Sprite> spriteLookup = new Dictionary<BindableBuildingType.BuildingType, Sprite>();

    private void OnEnable()
    {
        foreach (var mapping in colourMappings)
        {
            colourMappingLookup.TryAdd(mapping.type, mapping.color);
            spriteLookup.TryAdd(mapping.type, mapping.sprite);
        }
    }

    public override void Bind(Graphic graphic, object obj)
    {
        Building building = (Building)obj;
        if (building == null) return;

        if (colourMappingLookup.ContainsKey(building.buildingType))
        {
            graphic.color = colourMappingLookup[building.buildingType];
        }
        
        if (spriteLookup.ContainsKey(building.buildingType))
        {
            Image image = (Image)graphic;
            if (image != null)
            {
                image.sprite = spriteLookup[building.buildingType];
            }
        }
    }

    public override void Unbind(Graphic graphic, object obj)
    {
    }
}
