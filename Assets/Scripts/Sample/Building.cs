using System;
using DataBinding;
using UnityEngine;
using UnityEngine.Serialization;

[Bindable]
public class Building : ClickableObject
{
   public BuildingEventChannel buildingClickedEvent;

   public BindableBuildingType buildingType;
   public BindableString buildingName;
   public BindableColour testBindableColour;
   public BindableFloat buildingHealth;
   public BindableFloat buildingCost;
   public BindableBool testBindableBool;

   private Material material;

   private void Awake()
   {
      material = GetComponent<MeshRenderer>().material;
   }
   
   private void OnEnable()
   {
      buildingHealth.onValueChanged += OnHealthUpdated;
      OnHealthUpdated();
   }

   private void OnDisable()
   {
      buildingHealth.onValueChanged -= OnHealthUpdated;
   }

   public override void OnClick()
   {
      if (buildingClickedEvent == null) return;
      
      buildingClickedEvent.Invoke(this);
   }
   
   private void OnHealthUpdated()
   {
      if (material == null) return;

      material.color = Color.Lerp(Color.red, Color.green, Mathf.Clamp01(buildingHealth.GetValue()));
   }
}
