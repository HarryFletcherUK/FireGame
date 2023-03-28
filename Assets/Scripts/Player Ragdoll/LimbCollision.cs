using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbCollision : MonoBehaviour
{
    [SerializeField]
    private RagdollPlayerMovement player;

    private void OnCollisionEnter(Collision collision)
    {
        player.IsGrounded(true);
    }

}
