using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potScript : UnityEngine.MonoBehaviour
{

    public GameObject pot;
    public GameObject potTop;
    public GameObject soup;
    //UI BAR
    public PotSlider potSlider;
    //animator
    //public Animator animator;
    //POT ROTATION
    public float smooth = 2f;
    public float tiltAngle = 60.0f;
    public float tiltAngleX = 0f;
    private float forwardTilt;
    //Amount of Soup
    public int potVolume;
    private int potMaxVolume = 10000;
    //TIPPING
    public float tilt;
    public float soupScale;
    //Grab the relevant collider
    public BoxCollider2D bc2d;
    public BoxCollider2D bcKing;

    // Start is called before the first frame update
    void Start()
    {
        //initialize pot volume, and the slider for the UI
        potVolume = potMaxVolume;
        potSlider.SetMaxVolume(potVolume);
      
    }

    // Update is called once per frame
    void Update()
    {
        //We want soupScale to be 1 or lower with decimals, so we can use it
        //for transform.scale where the biggest value is 1
        //Its in the update function because we want it to constantly update its value
        soupScale = potVolume;

        //Call the pot rotation function, which uses quaternions to smooth the rotation
        PotRotation();

        //If the pot tilts in either direction, decrease how much soup is in the pot accordingly
        DecreasePotVolume();

        //if the pot isn't empty, it will look like the soup is decreasing in it
        if (soupScale >= 0)
        {
            soup.transform.localScale = new Vector3((float)soupScale / 10000, (float)soupScale / 10000, 1);
            //soup.transform.position = new Vector3(0, (float)soupScale / 10001, 0);
        }
        
   
    }

    void DecreasePotVolume()
    {
        //breaks out of the function if the game has been won.
        if (bc2d.IsTouching(bcKing))
        {
            return;
        }

        if (tilt >= 0.15)
        {
            //tipping left animation here
            //animator.SetBool("isTippingLeft", true);

        }
        if (tilt <= -0.15)
        {
            //tipping right animation here
            // one that starts the tip, and a second animation that loops ( constant flow)
        }
        if (tilt >= 0.15 || tilt <= -0.15)
        {
            potSlider.SetVolume(potVolume -= 3);
        }
        if (tilt >= 0.30 || tilt <= -0.30)
        {
            potSlider.SetVolume(potVolume -= 10);
        }
        if (tilt >= 0.40 || tilt <= -0.40)
        {
            potSlider.SetVolume(potVolume -= 50);
        }

        if (bc2d.IsTouchingLayers())
        {
            potSlider.SetVolume(potVolume -= 20);
            //splash animation here

        }
    }

    void PotRotation()
    {
        // Smoothly tilts a transform towards a target rotation.
        float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
        float tiltAroundX = Input.GetAxis("Vertical") * tiltAngleX;

        // Rotate the pot by converting the angles into a quaternion.
        Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);
        
        //scale forward tipping.. (not complete)
        //Quaternion target2 = Quaternion.Euler(1.129f, tiltAroundX, 1f);
        //tiltAroundX = tiltAroundX % 0.72f + 1;
        if (tiltAroundX > 0.55f && tiltAroundX < 0.80f)
        potTop.transform.localScale = new Vector3(1.129f, tiltAroundX, 1);

        // Dampen towards the target rotation
        pot.transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);

        ///TO DO: (if I want it to tip forwards and backwards too)
        ///make a rotation specifically for the x axis (the one that needs to modify the scale)
        ///scale resets to 0.5, cannot go smaller than 0.25, and cannot go wider than 0.75
        ///for visuals 

        //sets the tilt variable  -0.5 fully left 0.5 fully right
        tilt = pot.transform.rotation.z;
    }

   

    //references:
    //quaternion pot rotation
    //https://docs.unity3d.com/ScriptReference/Transform-rotation.html
}
