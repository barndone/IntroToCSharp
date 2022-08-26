using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPickup : BasePickup
{
    //  detect when the player has picked up the pickup
    //  if so, give them a new color
    //      and then destroy ourselves :(
    //  if not, nothing

    public Material rewardMaterial;

    protected override void PickupAction(Player player)
    {
        player.colorMaterials.Add(rewardMaterial);
    }
}
