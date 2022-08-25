using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableZone : MonoBehaviour
{
    public List<GameObject> collectables = new List<GameObject>();
    public GameObject door = null;

    private Vector3 doorOpenPosition = new Vector3(0f, 10f, 40f);
    private Vector3 doorClosedPosition;

    private int requiredCounter = 0;


    private void Start()
    {
        doorClosedPosition = door.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject otherGO = other.gameObject;

        //if the collectable enters the collider of this zone:
        if (collectables.Contains(otherGO))
        {
            //increment counter
            requiredCounter++;
            //get rid of the wall blocking the path if all the objects are in the zone
            if (requiredCounter == (collectables.Count))
            {
                door.transform.position = doorOpenPosition;
            }
            //get rid of the wall blocking the path
        }
        //otherwise do nothing!
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject otherGO = other.gameObject;

        //if the collectable enters the collider of this zone:
        if (collectables.Contains(otherGO))
        {
            //increment counter
            requiredCounter--;
            //get rid of the wall blocking the path if all the objects are in the zone
            if (requiredCounter < (collectables.Count))
            {
                door.transform.position = doorClosedPosition;
            }
            //get rid of the wall blocking the path
        }
        //otherwise do nothing!
    }
}
