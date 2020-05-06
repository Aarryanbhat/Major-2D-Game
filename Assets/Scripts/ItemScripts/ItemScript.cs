using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public float hook_speed;
    public int scorevalue;

     void OnDisable()
    {
        GameplayManager.instance.DisplayScore(scorevalue);     
    }
}
