using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Vector3 rotationVector = new Vector3(45, 0, 0);             //rotation vector for our pickup object
    void Update()
    {
        transform.Rotate(rotationVector * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        //did we collide with a player
        Player player = null;
        if (other.TryGetComponent<Player>(out player))                  //only allocates memory if it finds a player!
        {
            //if so, give the player a point
            player.points += 1;
            //destroy the pickup object
            Destroy(gameObject);
        }
        //otherwise, do nothing
    }
}
