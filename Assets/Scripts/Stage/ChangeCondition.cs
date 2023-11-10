using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ChangeCondition : MonoBehaviour
{
    public void UpAw()
    {
        if (GameManager.Instance.amino >= 1)
        {
            GameManager.Instance.amino--;
            GameManager.Instance.aw += 0.05f;
            if (GameManager.Instance.aw >= 1)
            {
                GameManager.Instance.aw = 1;
            }
        }
    }

    public void DownAw()
    {
        if (GameManager.Instance.amino >= 1)
        {
            GameManager.Instance.amino--;
            GameManager.Instance.aw -= 0.05f;
            if (GameManager.Instance.aw <= 0)
            {
                GameManager.Instance.aw = 0;
            }
        }
    }

    public void UpPH()
    {
        if (GameManager.Instance.amino >= 1)
        {
            GameManager.Instance.amino--;
            GameManager.Instance.ph += 1;
            if (GameManager.Instance.ph >= 14)
            {
                GameManager.Instance.ph = 14;
            }
        }
    }
    public void DownPH()
    {
        if (GameManager.Instance.amino >= 1)
        {
            GameManager.Instance.amino--;
            GameManager.Instance.ph -= 1;
            if (GameManager.Instance.ph <= 0)
            {
                GameManager.Instance.ph = 0;
            }
        }
    }

    public void UpTemp()
    {
        if (GameManager.Instance.amino >= 1)
        {
            GameManager.Instance.amino--;
            GameManager.Instance.temp += 4;
            if (GameManager.Instance.temp >= 100)
            {
                GameManager.Instance.temp = 100;
            }
        }
    }

    public void DownTemp()
    {
        if (GameManager.Instance.amino >= 1)
        {
            GameManager.Instance.amino--;
            GameManager.Instance.temp -= 4;
            if (GameManager.Instance.temp <= 0)
            {
                GameManager.Instance.temp = 0;
            }
        }
    }
}
