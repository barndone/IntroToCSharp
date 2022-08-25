using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rbody;
    public UnityEngine.UI.Text scoreText;                                       //no functional difference from ading using UnityEngine.UI.*
    public UnityEngine.UI.Text timerText;                                       //reference for timer text
    //reference for victory screen UI Objects
    public UnityEngine.UI.Text gameOverText;
    public UnityEngine.UI.Text gameOverStatsText;
    public float boostPower;

    public int points = 0;                                                      //keeps track of points the player has earned
    public float timer = 30.0f;                                                 //time to complete level
    private int minutesRemaining = 0;
    private int secondsRemaining = 0;
    private bool checkpoint;
    private Vector3 initialPos = Vector3.zero;
    public GameObject respawn;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        initialPos = transform.position;
        gameOverText.text = "";                                                 //"hide" the ui element
        gameOverStatsText.text = "";                                            //"hide" the ui element
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");                  //abstraction for a raw Horizontal axis 
        float forward = Input.GetAxisRaw("Vertical");                       //abstraction for a raw Vertical axis

        timer -= Time.deltaTime;                                            //increment the timer every frame
        minutesRemaining = (int) timer / 60;
        secondsRemaining = (int) timer % 60;

        timerText.text = "Time Remaining: " + 
            minutesRemaining.ToString("00") + 
            ":" + 
            secondsRemaining.ToString("00");      //update the timer UI element (mm:ss formatting applied)


        rbody.AddForce(horizontal, 0.0f, forward);                          //adds force every frame equal to the input values (-1, 0, or 1)

        scoreText.text = "Score: " + points.ToString();

        //if spacebar is pressed:
        if (Input.GetKeyDown (KeyCode.Space))
        {
            //apply an impulse force in the direction the player is moving (BOOST)
            rbody.AddForce(horizontal * boostPower, 
                0.0f, 
                forward * boostPower, 
                ForceMode.Impulse);
        }
        //else, do nothing

        //if timer is less than or equal to 0.0f
        if (timer <= 0.0f)
        {
            Time.timeScale = 0.0f;                                          //stop time
            scoreText.text = "";                                            //"hide" the ui element
            timerText.text = "";                                            //"hide" the ui element
            gameOverText.text = "Oh no!\n" +
                "You ran out of time!";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if collide with boost pad
        BoostPad boostPad = null;
        if (other.TryGetComponent<BoostPad>(out boostPad))
        {
            //if points >= 4
            if (points >= 4)
            {
                //apply force to rbody equal to the boost direction specified on the boost pad
                rbody.AddForce(boostPad.boostDirection, ForceMode.VelocityChange);
            }
            //otherwise do nothing (it is hidden at this point) 
        }

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
            scoreText.text = "";                                            //"hide" the ui element
            timerText.text = "";                                            //"hide" the ui element
            gameOverText.text = "You Won!";
            gameOverStatsText.text = "Score: " + 
                                        points.ToString() + 
                                        "/8\nTime Remaining: " +
                                        minutesRemaining.ToString("00") + 
                                        ":" + 
                                        secondsRemaining.ToString("00");                                     
            Time.timeScale = 0.0f;
        }
    }
}
