using System;
using UnityEngine;

public class UIEnemy : MonoBehaviour
{
    private int index;
    private ForUIEnemy UI;

    public GameObject[] EnemyHead;
    private void Start()
    {
        index = 0;
    }
    public void DisActive(GameObject Enemy)
    {
        try
        {
            UI = Enemy.GetComponent<ForUIEnemy>();
            ForUIEnemy.count++;
            if (!UI.isCount)
            {
                EnemyHead[index++].SetActive(true);
            }
            else
            {
                Debug.Log("DisActive not executed. Check array bounds or UI state.");
            }
        }
        catch (Exception e)
        {
            Debug.Log("Exception in DisActive: " + e);
        }
    }
}