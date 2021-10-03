using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rigidbody;

    [SerializeField] float height = 200;

    Player player;

    public GameObject SmallBall;

    //아이템 여러가지로 바꿔야됨
    public GameObject Item;


    public void InitSetting(float _height)
    {
        height = _height;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player = other.GetComponentInParent<Player>();

            player.On_Damage();
        }
        
        else if (other.tag == "Bullet")
        {
            //확률에 따라 나오는 아이템 정해야됨
            GameObject item = Instantiate(Item, new Vector3(transform.position.x, 0.5f, transform.position.z), Quaternion.identity);

            if (transform.localScale.x <= 0.3)
            {
                Debug.Log("DestroyBall");
            }

            else
            {
                for (int i = 0; i < 2; i++)
                {
                    GameObject obj = Instantiate(SmallBall, new Vector3(transform.position.x + 2f * i, transform.position.y, transform.position.z), Quaternion.identity);
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
