using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ChangeHandPistol : MonoBehaviour
{
    //private bool hand = true;

    //[SerializeField] private GameObject handPrefab;

    //[SerializeField] private GameObject pistolPrefab;

    [SerializeField] private GameObject pistolHand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeHand()
    {
        /*if (hand)
        {
            Debug.Log("EE");
            GameObject pistolModel = Instantiate(pistolPrefab, transform);
            GetComponent<ActionBasedController>().modelPrefab = pistolModel.transform;
        }
        else
        {
            GetComponent<ActionBasedController>().modelPrefab = handPrefab.transform;
        }*/
        pistolHand.SetActive(true);
        StartCoroutine(Wait());

    }

    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(0.05f);
        gameObject.SetActive(false);
    }
}
