using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudHazard : BaseHazards
{
    public float mudHazard = 0.5f;                          //mud hazard's impact on the player
    protected override void OnPlayerEnter(Player player)
    {
        //on enter, slow player down
        player.movementModifier -= mudHazard;               
    }

    protected override void OnPlayerExit(Player player)
    {
        //on enter, reset speed
        player.movementModifier += mudHazard;
    }
}
