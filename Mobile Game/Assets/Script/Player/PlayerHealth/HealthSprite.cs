using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HealthSprite : MonoBehaviour
{ 
    public void TakeDamage(float i)
    {
        gameObject.transform.GetChild((int)i).gameObject.SetActive(false);
    }
}
