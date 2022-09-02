using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public static HealthBar instance;



    [SerializeField] Image bar;
    [SerializeField] float health;
    [SerializeField] float maxHealth;
    [SerializeField] float iFrameDuration;

    Color startingColor;
    [SerializeField]Color endingColor;

    bool isInvincible = false;
    public Coroutine poisonCoroutine;

    bool isPoisoned = false;

    float Health
    {
        get { return health; }
        set
        {
            health = value;
            if (health > maxHealth)
            {
                health = maxHealth;
            }
            DisplayHealth();
            //check for death!
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //singleton pattern, ensures there is only one in the scene
        if (instance == null)
        {
            instance = this;
        }
        //if i'm not the instance
        else
        {
            //end me
            Destroy(gameObject);
        }

        

        startingColor = bar.color;
        DisplayHealth();
    }

    void DisplayHealth()
    {
        bar.fillAmount = health / maxHealth;
        //more optimized to just swap starting color and ending color rather than calculating the inverse.
        bar.color = Color.Lerp(endingColor, startingColor, health / maxHealth);
    }
    /*void CheckForDeath()
    {
        if (health <= 0)
        {
            //HazardGame.instance.
        }
    }*/
    //ignores iframes
    public void TakeDamageOverTime(float dmg, float duration)
    {
        if (!isPoisoned)
        {
            poisonCoroutine = StartCoroutine(ApplyDOT(dmg, duration));
        }
    }
    public void StopDamageOverTime()
    {
        if (isPoisoned)
        {
            StopCoroutine(poisonCoroutine);
            Debug.Log("Damage over time stopped.");
        }
    }
    IEnumerator ApplyDOT(float dmg, float duration)
    {
        isInvincible = true;
        float damageToApply = dmg / duration;
        float damageTaken = 0f;


        while (damageTaken < dmg)
        {
            Health -= damageToApply * Time.deltaTime;
            damageTaken += damageToApply * Time.deltaTime;

            yield return null;
        }
        isInvincible = false;
    }

    IEnumerator IFrame()
    {
        float startTime = Time.time;
        Debug.Log("I am invincible for two seconds!");

        while (Time.time - startTime < iFrameDuration)
        {
            yield return null;
        }
    }
    public void TakeDamage(float dmg = 25.0f)
    {
        //if the character is NOT invincible
        if (isInvincible == false)
        {
            //take damage, start IFrames
            Health -= dmg;
            StartCoroutine(IFrame());
        }
        //otherwise do nothing
    }
     
    public void Heal(float restore = 20.0f)
    {
        //heal the character by the specified restoration amount
        Health += restore;
    }


    #region testing
    public void TestDamage()
    {
        TakeDamage();
    }

    public void TestHeal()
    {
        Heal();
    }

    public void TestDOT()
    {
        TakeDamageOverTime(30f, 10f);
    }
    #endregion
}
