using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// Inspiration for solution found here: https://gamedev.stackexchange.com/questions/170126/make-a-platform-appear-and-disappear-constantly
/// tweaked to allow for offset disappearing platforms
/// </summary>
public class DisappearingPlatform : MonoBehaviour
{
    public GameObject target;

    public float timeInterval = 3.0f;

    public float delayStart = 0.0f;

    IEnumerator Start()
    {
        //wait for the designer specified amount before starting the loop.
        yield return new WaitForSeconds(delayStart);

        if (target == gameObject)
        {
            Debug.LogError("DisappearingPlatform cannot target itself, it must target a separate game object.");
        }

        while (true)
        {
            yield return new WaitForSeconds(timeInterval);

            target.SetActive(!target.activeSelf);

        }
    }
}
