using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCondition : MonoBehaviour
{
    public float[,] aw = { { 0.94f, 1 }, { 0.99f, 1 }, { 0, 1 }, { 0.95f, 1 } };
    public float[,] ph = { { 5.6f, 9.6f }, { 7, 7.5f }, { 3, 6.5f }, { 5, 9 } };
    public float[,] temp = { { 18, 37 }, { 0, 100 }, { -20, 0 }, { 43, 47 } };
    //public bool[] oxygen = { false, true, true, false };

    private static UnitCondition _instance;
    public static UnitCondition instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }
}
