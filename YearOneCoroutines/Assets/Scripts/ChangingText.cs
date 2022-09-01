using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;                //using text mesh pro
using UnityEngine.UI;       //using regular text/ui elements
using UnityEngine.Events;   //for using events

public class ChangingText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI displayText;                                       //this will make the property available in the inspector without being public
                                                                                        //also allows the scene to save it
    [SerializeField] Button activationButton;
    [SerializeField] Image cooldownImage;

    [SerializeField] UnityEvent OnCooldownStart;
    [SerializeField] UnityEvent OnCooldownEnd;

    public void UpdateDisplay()
    {
        //to call coroutines, you have to pass info to them: by passing a behavior to the actual update stack temporarily
        //can make your own outside of unity but it's a process
        StartCoroutine(Cooldown());
    }

    //will default to red squigglies, need to include a yield
    //how to set cooldowns!!
    IEnumerator Cooldown(float duration = 10f)
    {
        OnCooldownStart.Invoke();
        float startTime = Time.time;                                                //time.time is accessing the current time since the application has started
        cooldownImage.enabled = true;
        activationButton.interactable = false;

        while (Time.time - startTime < duration)
        {
            //lets us know when to stop executing
            yield return null;                                                      //must be inside of the loop, come back after nothing
            cooldownImage.fillAmount = (Time.time - startTime) / duration;
            if (displayText)
            {
                displayText.text = (Time.time - startTime).ToString("##.#");            //not a string by itself - float, must convert to String
            }
        }
        if (displayText)
        {
            displayText.text = duration.ToString();
        }

        activationButton.interactable = true;
        cooldownImage.enabled = false;
        OnCooldownEnd.Invoke();
    }
}
