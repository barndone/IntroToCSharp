using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindHazard : BaseHazards
{
    protected override void OnPlayerEnter(Player player)
    {
        //on enter, push player in specified direction
    }

    protected override void OnPlayerExit(Player player)
    {
        //on exit, stop pushing the player
    }
}
