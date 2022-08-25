using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public UnityEngine.UI.Text scoreText;                                       //no functional difference from ading using UnityEngine.UI.*
    public UnityEngine.UI.Text timerText;                                       //reference for timer text
    //reference for victory screen UI Objects
    public UnityEngine.UI.Text gameOverText;
    public UnityEngine.UI.Text gameOverStatsText;
    
    public Player player = null;

    public List<Pickup> requiredPickups = new List<Pickup>();

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

        //if timer is less than or equal to 0.0f
        if (timer <= 0.0f)
        {
            Time.timeScale = 0.0f;                                          //stop time
            gameOverText.text = "Oh no!\n" +
                "You ran out of time!";

            scoreText.text = " ";                                            //"hide" the ui element
            timerText.text = " ";                                            //"hide" the ui element
        }
        else 
        {
            scoreText.text = "Score: " + player.points.ToString();
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
                                        secondsRemaining.ToString("00");
            Time.timeScale = 0.0f;


            //  why aren't you hiding??????!?!??!!?
            scoreText.text = " ";                                            //"hide" the ui element
            timerText.text = " ";                                            //"hide" the ui element

        }
    }
}
