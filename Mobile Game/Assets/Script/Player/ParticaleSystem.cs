using System.Collections;
using UnityEngine;

public class ParticaleSystem : MonoBehaviour
{
    public GameObject TranstionEffect;
    public void RunParticale(Transform tr,Transform tr2)
    {
        GameObject inst = Instantiate(TranstionEffect, tr.position, Quaternion.identity);
        GameObject inst2 = Instantiate(TranstionEffect, tr2.position, Quaternion.identity);

        StartCoroutine(DestroyIns(inst,inst2));
    }
    public IEnumerator DestroyIns(GameObject inst,GameObject inst2)
    {
        yield return new WaitForSeconds(2);
        Destroy(inst);
        Destroy(inst2);
    }
}
