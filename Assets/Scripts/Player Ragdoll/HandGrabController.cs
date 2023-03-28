using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGrabController : MonoBehaviour
{
    //The object currently being grabbed
    private GameObject grabbedObject;

    private bool grabActive;

    [SerializeField]
    private float grabRange;

    // Start is called before the first frame update
    void Start()
    {
        grabActive = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (grabActive)
        {
            if (grabbedObject != null && !grabbedObject.GetComponent<FixedJoint>())
            {
                //Create and attach a fixed joint to the grabbed object
                FixedJoint fj = grabbedObject.AddComponent<FixedJoint>();
                fj.connectedBody = GetComponent<Rigidbody>();
            }
        }
        else
        {
            //Destroy the joint and drop the grabbed object
            if (grabbedObject != null && grabbedObject.GetComponent<FixedJoint>())
                Destroy(grabbedObject.GetComponent<FixedJoint>());
        }
    }
    
    public void ToggleGrab(bool toggle)
    {
        grabActive = toggle;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (grabActive)
        {
            grabbedObject = other.gameObject;
        }
    }

    private void OnTriggerExit()
    {
        grabbedObject = null;
    }
}
