using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rigidbody;

    [SerializeField] float height = 200;

    Player player;

    public GameObject prefab;

    public void InitSetting(float _height)
    {
        height = _height;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player = other.GetComponent<Player>();

            player.On_Damage(10f);
        }
        
        else if (other.tag == "Bullet")
        {
            if (transform.localScale.x <= 0.3)
            {
                Debug.Log("DestroyBall");
            }

            else
            {
                for (int i = 0; i < 2; i++)
                {
                    GameObject obj = Instantiate(prefab, new Vector3(transform.position.x + 2f * i, transform.position.y, transform.position.z), Quaternion.identity);
                    Ball smallball = obj.GetComponent<Ball>();
                    smallball.InitSetting((float)(height * 0.3));

                    Vector3 v = obj.transform.localScale;

                    v.x *= 0.5f;
                    v.y *= 0.5f;
                    v.z *= 0.5f;

                    obj.transform.localScale = v;


                }
            }

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

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
