using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    private float playerhp = 300f;

    [SerializeField]
    private float Speed = 10f;

    Rigidbody rigidbody;
    Vector3 movement;

    float ry;
    public float rotSpeed = 200;

    public GameObject bullet;
    public Transform bulletpos;
    
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.forward * -Speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.right * -Speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
        }

       
        if (Input.GetMouseButtonDown(0))
        {
            GameObject obj = Instantiate(bullet, bulletpos.position , Quaternion.identity);
            Bullet b = obj.GetComponent<Bullet>();
            b.initbullet(bulletpos.rotation);
        }

        float mx = Input.GetAxis("Mouse X");

        ry += rotSpeed * mx * Time.deltaTime;

        transform.eulerAngles = new Vector3(0, ry, 0);
    }

    public void On_Damage(float damage)
    {
        playerhp -= damage;
    }
}
