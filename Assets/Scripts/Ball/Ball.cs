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

    public int cnt = 0;

    public void InitSetting(float _height, int _cnt)
    {
        height = _height;
        cnt = _cnt;
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
            int ran = Random.Range(1, 100);

            if (ran >= 50)
            {
                GameObject item = Instantiate(Item, new Vector3(transform.position.x, 0.5f, transform.position.z), Quaternion.identity);
            }

            if (cnt > 1)
            {
                Debug.Log("DestroyBall");
            }

            else
            {
                for (int i = 0; i < 2; i++)
                {
                    GameObject obj = Instantiate(SmallBall, new Vector3(transform.position.x + 2f * i, transform.position.y, transform.position.z), Quaternion.identity);
                    Ball smallball = obj.GetComponent<Ball>();
                    smallball.InitSetting((float)(height * 0.3), cnt + 1);

                    Vector3 v = obj.transform.localScale;

                    v.x *= 0.5f;
                    v.y *= 0.5f;
                    v.z *= 0.5f;

                    obj.transform.localScale = v;

                    BallManager.Instance.Ball_Create(obj);
                }
            }

            Destroy(other.gameObject);
            Destroy(gameObject);
            BallManager.Instance.Ball_Dealth(gameObject);
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
