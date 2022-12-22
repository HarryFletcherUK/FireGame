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
    public Transform hoseGun;
    public Transform baseObject;
    public Transform hoseReel;
    private float dist;
    private float rotAng;
    public float hoseMaxLength = 10f;

    private void Start()
    {
        cursor = GetComponentInChildren<ObiRopeCursor>();
        rope = cursor.GetComponent<ObiRope>();

        mainCam = Camera.main;
        if (!mainCam.gameObject.GetComponent<ObiFluidRenderer>())
        {
            Debug.LogError("Remember to add Obi Fluid Renderer Component to Main Camera");
        }
    }

    private void Update()
    {
        dist = Vector3.Distance(hoseGun.position, baseObject.position);

        //set length of rope based on the hose gun distance from hose reel
        if(dist < hoseMaxLength) 
        { 
            cursor.ChangeLength(dist);
        }
    }
}
