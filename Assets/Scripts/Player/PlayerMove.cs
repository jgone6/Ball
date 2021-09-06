using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float Speed = 10f;

    Rigidbody rigidbody;
    Vector3 movement;
    float h, v;

    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        movement.Set(h, 0f, v);
        movement = movement.normalized * Speed * Time.deltaTime;
        rigidbody.MovePosition(transform.position + movement);

        if (Input.GetMouseButtonDown(0))
        {
            
        }
    }
}
