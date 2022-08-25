using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableZone : MonoBehaviour
{
    public List<GameObject> collectables = new List<GameObject>();
    public GameObject door = null;

    private Vector3 doorOpenPosition = new Vector3(0f, 10f, 40f);

    private void OnTriggerEnter(Collider other)
    {
        //if the collectable enters the collider of this zone:
        if (other.CompareTag("Collectable"))
        {
            //get rid of the wall blocking the path
            door.transform.position = doorOpenPosition;
        }

        //otherwise do nothing!
    }
}
