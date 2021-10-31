using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public enum BulletType
{
    basic = 0,
    Double,

}

public class Player : MonoBehaviour
{
    [SerializeField]
    private Image[] PlayerHp;

    [SerializeField]
    private float Speed = 10f;

    Rigidbody rigidbody;
    Vector3 movement;

    float ry;
    public float rotSpeed = 200;

    public GameObject bullet;
    public Transform bulletpos;

    private BulletType type = BulletType.basic;
    private int deathcnt = 0;

    public GameObject DeathUI;

    private void Awake()
    {
        DeathUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Item")
        {
            Item item = other.gameObject.GetComponent<Item>();

            type = item.type;

            Destroy(other.gameObject);
        }
    }

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
            Create_Bullet();
        }

        float mx = Input.GetAxis("Mouse X");

        ry += rotSpeed * mx * Time.deltaTime;

        transform.eulerAngles = new Vector3(0, ry, 0);
    }

    public void Create_Bullet()
    {
        switch(type)
        {
            case BulletType.basic:
                GameObject obj = Instantiate(bullet, bulletpos.position, Quaternion.identity);
                Bullet b = obj.GetComponent<Bullet>();
                b.initbullet(bulletpos.rotation);
                break;

            case BulletType.Double:
                StartCoroutine(DBullet());
                break;
        }
    }

    IEnumerator DBullet()
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject obj = Instantiate(bullet, bulletpos.position, Quaternion.identity);
            Bullet b = obj.GetComponent<Bullet>();
            b.initbullet(bulletpos.rotation);
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void On_Damage()
    {
        for (int i = 0; i < PlayerHp.Length; i++)
        {
            if (PlayerHp[i].gameObject.activeSelf)
            {
                PlayerHp[i].gameObject.SetActive(false);
                deathcnt++;
                break;
            }
        }

        if (deathcnt >= 3)
        {
            Time.timeScale = 0;
            DeathUI.SetActive(true);
        }
    }
}
