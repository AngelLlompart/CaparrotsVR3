using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearOnHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(destroy());
    }
    
    IEnumerator destroy()
    {
        yield return new WaitForSecondsRealtime(4);
        Destroy(gameObject);
    }
}
