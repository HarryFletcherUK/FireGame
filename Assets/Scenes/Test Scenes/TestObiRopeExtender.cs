using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;
using Unity.VisualScripting;

public class TestObiRopeExtender : MonoBehaviour
{

    ObiRopeCursor cursor;
    ObiRope rope;
    Camera mainCam;

    private float dist;
    private float lastDist;
    private float scaleValue;
    private float hoseStartVal;

    public Transform hoseGun;
    public Transform baseObject;
    public Transform hoseReel;
    public float hoseMaxLength = 10f;
    public float reelRotationMult = 20f;


    private void Start()
    {
        cursor = GetComponentInChildren<ObiRopeCursor>();
        rope = cursor.GetComponent<ObiRope>();

        dist = Vector3.Distance(hoseGun.position, baseObject.position);
        hoseStartVal = dist / hoseMaxLength;

        mainCam = Camera.main;
        if (!mainCam.gameObject.GetComponent<ObiFluidRenderer>())
        {
            Debug.LogError("Remember to add Obi Fluid Renderer Component to Main Camera");
        }
    }

    private void Update()
    {
        dist = Vector3.Distance(hoseGun.position, baseObject.position);
       
        if(dist < hoseMaxLength) 
        {
            //set length of rope based on the hose gun distance from hose reel
            cursor.ChangeLength(dist);

            //scale the hose reel model to simulate it getting smaller
            scaleValue = (dist / hoseMaxLength) - hoseStartVal;
            hoseReel.localScale = new Vector3(1, 1 - scaleValue, 1 - scaleValue);

            //rotate hose reel model to simulate unwinding
            float posDelta = dist - lastDist;
            lastDist = dist;

            float mult = hoseMaxLength * reelRotationMult;

            hoseReel.Rotate(-posDelta * mult,0,0);
        }
    }
}
