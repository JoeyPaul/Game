using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potScript : UnityEngine.MonoBehaviour
{

    public GameObject pot;
    public GameObject potTop;
    //UI BAR
    public PotSlider potSlider;
    //POT ROTATION
    public float smooth = 0.5f;
    public float tiltAngle = 60.0f;
    public float tiltAngleX = 0f;
    private float forwardTilt;
    //Amount of Soup
    public int potVolume;
    private int potMaxVolume = 10000;
    //TIPPING
    public float tilt;
    //Grab the collider
    public BoxCollider2D bc2d;

    // Start is called before the first frame update
    void Start()
    {
        //forwardTilt = tiltAngleX + 0.84f;
        potVolume = potMaxVolume;
    }

    // Update is called once per frame
    void Update()
    {


        //---------------------pot rotation------------------------//

        PotRotation();

        //---------------------------------------------------------//

        if (tilt < 0 || tilt > 0)
        {
            potTip();
        }
   
    }

    void potTip()
    {
        if (tilt >= 0.15)
        {
            //tipping left animation here
        }
        if (tilt <= -0.15)
        {
            //tipping right animation here
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
        
        //scale
        //Quaternion target2 = Quaternion.Euler(1.129f, tiltAroundX, 1f);
        //tiltAroundX = tiltAroundX % 0.72f + 1;
        if (tiltAroundX > 0.55f && tiltAroundX < 0.80f)
        potTop.transform.localScale = new Vector3(1.129f, tiltAroundX, 1);
        //figure out forwards tipping
        // need the tipping to default to 0.55 instead of 0 (x scale)
        // min 0.12 and max 0.75
        //if (tiltAroundX > 0.12f && tiltAroundX < 0.55f)
        //    potTop.transform.localScale = new Vector3(1.129f, tiltAroundX, 1);

        // Dampen towards the target rotation
        pot.transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);

        //make a rotation specifically for the x axis (the one that needs to modify the scale)
        //scale resets to 0.5, cannot go smaller than 0.25, and cannot go wider than 0.75

        //sets the tilt variable  -0.5 fully left 0.5 fully right
        tilt = pot.transform.rotation.z;
    }

   

    //references:
    //pot rotation
    //https://docs.unity3d.com/ScriptReference/Transform-rotation.html
}
