using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHazard : BaseHazard
{
    [SerializeField] float damage = 10f;

    protected override void HazardAction()
    {
        base.healthBar.TakeDamage(damage);
        Debug.Log("I stepped on a spike :(");
    }
}
