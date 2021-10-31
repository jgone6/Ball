using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public GameObject[] Stage;

    public int NowStage = 0;

    private static StageManager instance = null;

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

        for (int i = 0; i < Stage.Length; i++)
        {
            if (i != 0)
            {
                Stage[i].SetActive(false);
            }

            else
            {
                Stage[i].SetActive(true);
            }
        }
    }

    public static StageManager Instance
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

    public void Next_Stage()
    {
        Stage[NowStage].SetActive(false);
        Stage[++NowStage].SetActive(true);
    }
}
