using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPickup : MonoBehaviour
{
    //  detect when the player has picked up the pickup
    //  if so, give them a new color
    //      and then destroy ourselves :(
    //  if not, nothing

    public Material rewardMaterial;

    private void OnTriggerEnter(Collider other)
    {
        Player player = null;

        //was the other object the player
        if(other.TryGetComponent<Player> (out player))
        {
            //if so, add color to list
            player.colorMaterials.Add(rewardMaterial);
            //destroy object
            Destroy(gameObject);
        }

        //otherwise, do nothing
    }
}
