using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float Speed = 10f;

    public float GetSpeed => Speed;

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

        anim.SetBool("Run", v > 0);
        anim.SetBool("RunLeft", h < 0);
        anim.SetBool("RunRight", h > 0);
        anim.SetBool("RunBack", v < 0);
        
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Attack");
        }
    }
}
