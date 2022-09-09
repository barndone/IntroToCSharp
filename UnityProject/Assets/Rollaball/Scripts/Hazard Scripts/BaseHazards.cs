using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseHazards : MonoBehaviour
{
    protected Player player = null;
    //on entering trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out player))
        {
            //do some thing
            OnPlayerEnter(player);
        }
    }

    //on exiting trigger
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out player))
        {
            //stop doing that thing
            OnPlayerExit(player);
        }
    }

    //implemented by hazards themselves
    protected abstract void OnPlayerEnter(Player player);

    //implemebted by hazards themselves
    protected abstract void OnPlayerExit(Player player);
}
