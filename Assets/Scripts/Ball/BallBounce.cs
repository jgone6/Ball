using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    Rigidbody rigidbody;

    [SerializeField] float height = 200;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {

        ExcecuteReBounding(collision);
    }

    private void ExcecuteReBounding(Collision collision)
    {
        ContactPoint cp = collision.GetContact(0);
        Vector3 dir = transform.position - cp.point;
        rigidbody.AddForce((dir).normalized * height);
    }
}
