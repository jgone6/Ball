using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float bulletSpeed = 10f;

    private Transform trans;

    private void Start()
    {
        Invoke("DestroySec", 6f);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
    }

    public void initbullet(Quaternion _rota)
    {
        transform.rotation = _rota;
    }

    private void DestroySec()
    {
        Destroy(gameObject);
    }
}
