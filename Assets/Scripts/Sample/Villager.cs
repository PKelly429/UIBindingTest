using System.Collections;
using System.Collections.Generic;
using DataBinding;
using UnityEngine;

[Bindable]
public class Villager : ClickableObject
{
    public VillagerEventChannel villagerClickedEvent;
    
    
    public override void OnClick()
    {
        if (villagerClickedEvent == null) return;
      
        villagerClickedEvent.Invoke(this);
    }
}
