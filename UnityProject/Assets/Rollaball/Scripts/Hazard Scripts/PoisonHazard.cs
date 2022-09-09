using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonHazard : BaseHazards
{
    float timer = 0f;
    int healthLost = 0;             //TODO implement player health

    bool startTimer = false;

    private void Update()
    {
        if (startTimer)
        {
            timer += Time.deltaTime;
        }
    }
    protected override void OnPlayerEnter(Player player)
    {
        timer = 0f;
        startTimer = true;
    }

    protected override void OnPlayerExit(Player player)
    {
        startTimer = false;
        healthLost = (int)timer * 10;
        base.player.health -= healthLost;
    }
}
