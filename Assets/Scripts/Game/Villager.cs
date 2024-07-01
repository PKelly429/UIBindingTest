using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Bindable]
public class Villager : ClickableObject
{
    public VillagerEventChannel villagerClickedEvent;
    
    public StringBindingVariable villagerName;
    
    
    public override void OnClick()
    {
        if (villagerClickedEvent == null) return;
      
        villagerClickedEvent.Invoke(this);
    }
}
