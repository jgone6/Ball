using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    private Image image;
    public BulletType type;

    public void InitSetting(BulletType _type)
    {
        type = _type;

        switch(type)
        {
            case BulletType.Double:

                break;
        }
    }
}