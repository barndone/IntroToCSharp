using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseHazard : MonoBehaviour
{
    protected GameObject controller;
    protected HealthBar healthBar = null;

    private void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
        controller.TryGetComponent<HealthBar>(out healthBar);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        CharacterController2D character = null;
        //did we collide with the player
        if (other.TryGetComponent<CharacterController2D>(out character))
        {
            //if so do hazard stuff
            HazardAction();
        }
    }

    protected abstract void HazardAction();
}
