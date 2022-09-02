using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonHazard : BaseHazard
{
    [SerializeField] float dot = 25f;


    protected override void HazardAction()
    {
        healthBar.TakeDamageOverTime(dot, 5f);
    }
}
