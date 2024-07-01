using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Bindable]
public class Building : ClickableObject
{
   public BuildingEventChannel buildingClickedEvent;
   
   public StringBindingVariable buildingName;
   public FloatBindingVariable buildingHealth;

   public void Update()
   {
      if (Input.GetKeyDown(KeyCode.Space))
      {
         buildingHealth.SetValue(buildingHealth +1);
      }
   }

   public override void OnClick()
   {
      if (buildingClickedEvent == null) return;
      
      buildingClickedEvent.Invoke(this);
   }
}
