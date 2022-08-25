using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPad : MonoBehaviour
{
    public Vector3 boostDirection = Vector3.zero;
    public GameObject player;
    private Player playerScript = null;

    public Material inertMaterial;
    public Material activeMaterial;

    void Start()
    {
        player.TryGetComponent<Player>(out playerScript);                           //get the Player script component
        gameObject.GetComponent<Renderer>().material = inertMaterial;           //set the material of the boost to inactive
    }
    void Update()
    {
        if (playerScript.points >= 4)
        {
            gameObject.GetComponent<Renderer>().material = activeMaterial;      //if points equals 4, set the material of the boost to active
        }
    }
}
