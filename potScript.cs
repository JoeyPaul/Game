using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potScript : MonoBehaviour
{

    //float potRotation;
    public GameObject pot;
    public GameObject potTop;
    public float smooth = 0.5f;
    public float tiltAngle = 60.0f;
    public float tiltAngleX = 1f;
    private float forwardTilt;

    // Start is called before the first frame update
    void Start()
    {
        forwardTilt = tiltAngleX + 0.84f;
    }

    // Update is called once per frame
    void Update()
    {

        //---------------------pot rotation------------------------//

        PotRotation();

        //---------------------------------------------------------//
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
    }


    //references:
    //pot rotation
    //https://docs.unity3d.com/ScriptReference/Transform-rotation.html
}
