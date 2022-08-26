using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //reference for timer and score text
    public UnityEngine.UI.Text scoreText;                                       
    public UnityEngine.UI.Text timerText;                                       
    
    //reference for victory screen UI Objects
    public UnityEngine.UI.Text gameOverText;
    public UnityEngine.UI.Text gameOverStatsText;

    //reference for quest tracker
    public UnityEngine.UI.Text questTracker;

    //reference for health tracker
    public UnityEngine.UI.Text healthTracker;

    public Player player = null;
    public BoostPad boostPad = null;
    public GameObject collectableZone = null;
    private CollectableZone zone;

    public List<GameObject> requiredPickups = new List<GameObject>();

    //  respawn references
    private bool checkpoint;
    private Vector3 initialPos = Vector3.zero;
    public GameObject respawn;

    //  timer references
    public float timer = 0.0f;
    private int minutesRemaining = 0;
    private int secondsRemaining = 0;

    // Start is called before the first frame update
    void Start()
    {
        zone = collectableZone.GetComponent<CollectableZone>();
        TryGetComponent<Player>(out player);
        gameOverText.text = "";                                                 //"hide" the ui element
        gameOverStatsText.text = "";                                            //"hide" the ui element

        initialPos = transform.position;                                        //assign initial position for respawn w/o checkpoints
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;                                            //increment the timer every frame
        minutesRemaining = (int)timer / 60;
        secondsRemaining = (int)timer % 60;

        timerText.text = "Time Remaining: " +
            minutesRemaining.ToString("00") +
            ":" +
            secondsRemaining.ToString("00");      //update the timer UI element (mm:ss formatting applied)

        healthTracker.text = "Health: " + player.health;

        //if timer is less than or equal to 0.0f
        if (timer <= 0.0f)
        {
            Time.timeScale = 0.0f;                                          //stop time
            gameOverText.text = "Oh no!\n" +
                "You ran out of time!";

            scoreText.text = " ";                                            //"hide" the ui element
            timerText.text = " ";                                            //"hide" the ui element
            healthTracker.text = "";

            //why aren't you working ????????????
            questTracker.text = " ";                                        //"hide this ui element
            

        }
        else if (player.health <= 0)
        {
            Time.timeScale = 0.0f;                                          //stop time
            gameOverText.text = "Oh no!\n" +
                "You died!";

            scoreText.text = " ";                                            //"hide" the ui element
            timerText.text = " ";                                            //"hide" the ui element
            healthTracker.text = "";


            //why aren't you working ????????????
            questTracker.text = " ";                                        //"hide this ui element
        }
        else 
        {
            scoreText.text = "Score: " + player.points.ToString();
        }
        
        //  if requiredPickups is empty
        if (requiredPickups.Count == 0)
        {
            //move the boost pad onto the level
            boostPad.transform.position = (boostPad.activePosition);
        }

        //if you do not have the checkpoint
        if (checkpoint == false)
        {
            //look at the first objective
            questTracker.text = requiredPickups.Count + " pickups remaining!";
            if (requiredPickups.Count == 0)
            {
                questTracker.text = "All pickups acquired!\nPlease move to the next area.";
            }
        }
        //otherwise
        else
        {
            //look at the next objective
            questTracker.text = "Put the cubes back in their place! " + (zone.collectables.Count - zone.requiredCounter) + " remaining.";
            
            if (zone.requiredCounter == zone.collectables.Count)
            {
                questTracker.text = "The door is open!\nDon't forget the extra pickups on your way out!";
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if the player enters the kill plane:
        if (other.CompareTag("KillPlane"))
        {
            //either respawn at the checkpoint
            if (checkpoint)
            {
                gameObject.transform.SetPositionAndRotation(respawn.transform.position,
                                                            respawn.transform.rotation);
            }
            //or respawn at the start
            else
            {
                gameObject.transform.SetPositionAndRotation(initialPos,
                                                            respawn.transform.rotation);
            }
        }

        //if the player hits the checkpoint:
        if (other.CompareTag("Checkpoint"))
        {
            //flag the checkpoint as true
            checkpoint = true;
            questTracker.text = "Put the cubes back in their place! " + zone.collectables.Count + " remaining.";
        }

        //if the player hits the finish line:
        if (other.CompareTag("Finish"))
        {

            //end the level
            gameOverText.text = "You Won!";
            gameOverStatsText.text = "Score: " +
                                        player.points.ToString() +
                                        "/8\nTime Remaining: " +
                                        minutesRemaining.ToString("00") +
                                        ":" +
                                        secondsRemaining.ToString("00") + 
                                        "\nRemaining Health: " + player.health;
            Time.timeScale = 0.0f;


            //  why aren't you hiding??????!?!??!!?
            scoreText.text = " ";                                            //"hide" the ui element
            timerText.text = " ";                                            //"hide" the ui element
            questTracker.text = " ";                                        //"hide this ui element
            healthTracker.text = " ";
        }
    }
}
