using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FresnelSelection : MonoBehaviour
{
    [SerializeField] private Material highlightMaterial;

    private Material selectedObjectMaterial;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Select"))
        {
            selectedObjectMaterial = other.GetComponent<Renderer>().material;
            other.GetComponent<Renderer>().material = highlightMaterial;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Select"))
        {
           other.GetComponent<Renderer>().material = selectedObjectMaterial;
        }
    }
}
