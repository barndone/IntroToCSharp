using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonHazard : BaseHazard
{
    float timeEnterHazard = 0f;
    float timeInHazard = 0f;
    [SerializeField] float dot = 5f;
    bool inPoison = false;

    private bool InPoison
    {
        get { return inPoison; }
        set
        {
            if (value != inPoison)
            {
                if (value == true)
                {
                    Debug.Log("I have entered the poison :(");
                    timeEnterHazard = Time.time;
                }
                else
                {
                    Debug.Log("I have exited the poison :)");

                    timeInHazard = Time.time - timeEnterHazard;
                    base.healthBar.TakeDamageOverTime(dot * timeInHazard, timeInHazard);
                }
                inPoison = value;
            }
        }
    }

    protected override void HazardAction()
    {
        if (!InPoison)
        {
            InPoison = true;
        }
        else
        {
            InPoison = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CharacterController2D character = null;
        if (collision.TryGetComponent<CharacterController2D>(out character))
        {
            HazardAction();
        }
    }
}
