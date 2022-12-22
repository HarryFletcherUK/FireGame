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
        //Debug.Log(rope.restLength);
        //Debug.Log(Vector3.Distance(hoseGun.position, baseObject.position));
        cursor.ChangeLength(Vector3.Distance(hoseGun.position, baseObject.position));
    }
}
