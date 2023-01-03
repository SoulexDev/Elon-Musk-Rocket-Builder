using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableObject : MonoBehaviour, IGrabbable
{
    private Rigidbody rb;
    private Transform follow;
    [SerializeField] private float camSpeedMult = 0.85f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Drop()
    {
        follow = null;
        rb.useGravity = true;
        Player.Instance.controller.weight = 1;
        Player.Instance.controller.carryingObject = false;
    }

    public void Grab(Transform followTransform)
    {
        follow = followTransform;
        rb.useGravity = false;
        Player.Instance.controller.weight = camSpeedMult;
        Player.Instance.controller.carryingObject = true;
    }
    private void FixedUpdate()
    {
        if(follow != null)
        {
            if (rb.velocity.magnitude < 0.05f)
                rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.velocity = (follow.position - transform.position) * 15;
            transform.rotation = Quaternion.Slerp(transform.rotation, follow.rotation, Time.fixedDeltaTime * 15);
        }
    }
}