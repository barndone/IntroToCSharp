using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //did we collide with a player?
        Player player = null;
        if (other.TryGetComponent<Player>(out player))
        {
            //if so do the pickup thing
            PickupAction(player);
            //then destroy the pickup object
            Destroy(gameObject);
        }
        //otherwise do nothing
    }
    //implemented by derived classes
    protected abstract void PickupAction(Player player);
}