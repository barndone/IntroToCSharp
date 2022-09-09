using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizePickup : BasePickup
{
    public float newSize = 1.5f;
    protected override void PickupAction(Player player)
    {
        player.gameObject.transform.localScale = Vector3.one * newSize;
    }
}
