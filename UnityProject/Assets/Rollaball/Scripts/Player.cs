using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rbody;
    private MeshRenderer meshRend;


    public float boostPower;
    public int points = 0;                                                      //keeps track of points the player has earned


    public List<Material> colorMaterials = new List<Material>();
    private int currentColorIndex = 0;

    public List<AudioClip> boostSounds = new List<AudioClip>();
    AudioSource myAudio = null;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        meshRend = GetComponent<MeshRenderer>();
        TryGetComponent<AudioSource>(out myAudio);
    }

    // Update is called once per frame
    void Update()
    {
        //  color swaps
        //  if you press right bracket, next color
        //  otherwise if you press left bracket, previous color
        if (Input.GetKeyUp(KeyCode.RightBracket))
        {
            if (currentColorIndex == (colorMaterials.Count - 1))
            {
                currentColorIndex = 0;
                meshRend.material = colorMaterials[0];
            }
            else
            {
                currentColorIndex++;
                meshRend.material = colorMaterials[currentColorIndex];
            }
        }
        else if (Input.GetKeyUp(KeyCode.LeftBracket))
        {
            if (currentColorIndex == 0)
            {
                currentColorIndex = (colorMaterials.Count - 1);
                meshRend.material = colorMaterials[currentColorIndex];
            }
            else
            {
                currentColorIndex--;
                meshRend.material = colorMaterials[currentColorIndex];

            }
        }

        float horizontal = Input.GetAxisRaw("Horizontal");                  //abstraction for a raw Horizontal axis 
        float forward = Input.GetAxisRaw("Vertical");                       //abstraction for a raw Vertical axis

        rbody.AddForce(horizontal, 0.0f, forward);                          //adds force every frame equal to the input values (-1, 0, or 1)

        //if spacebar is pressed:
        if (Input.GetKeyDown (KeyCode.Space))
        {
            //apply an impulse force in the direction the player is moving (BOOST)
            rbody.AddForce(horizontal * boostPower, 
                0.0f, 
                forward * boostPower, 
                ForceMode.Impulse);
            myAudio.PlayOneShot(boostSounds[Random.Range(0,boostSounds.Count)]);
        }
        //else, do nothing
    }

    private void OnTriggerEnter(Collider other)
    {
        //if collide with boost pad
        BoostPad boostPad = null;
        if (other.TryGetComponent<BoostPad>(out boostPad))
        {
            //apply force to rbody equal to the boost direction specified on the boost pad
            rbody.AddForce(boostPad.boostDirection, ForceMode.VelocityChange);
        }       
    }
}
