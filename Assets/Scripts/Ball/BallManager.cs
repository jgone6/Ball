using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    private List<GameObject> ball_count;
    private List<GameObject> Death_ball_count;

    private static BallManager instance = null;

    public GameObject player;

    void Awake()
    {
        if (null == instance)
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static BallManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    public void Ball_Create(GameObject g)
    {
        ball_count.Add(g);
    }

    public void Ball_Dealth(GameObject g)
    {
        Death_ball_count.Add(g);

        if (ball_count.Count == Death_ball_count.Count)
        {
            StageManager.Instance.Next_Stage();

            Vector3 obj = new Vector3(-19.5f, 1f, -20.5f);

            player.transform.position = obj;
        }
    }
}
