using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FresnelSelection : MonoBehaviour
{
    [SerializeField] private Material highlightMaterial;

    private Material selectedObjectMaterial;
    private GameObject objectSelected;
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
        if (objectSelected == null)
        {
            if (other.CompareTag("Select"))
            {
                objectSelected = other.gameObject;
                Material objectMat = other.GetComponent<Renderer>().material;
                if (objectMat.shader.name != highlightMaterial.shader.name)
                {
                    Debug.Log("a");
                    selectedObjectMaterial = other.GetComponent<Renderer>().material;
                    other.GetComponent<Renderer>().material = highlightMaterial;
                }
                
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Select"))
        {
            objectSelected = null;
            if (selectedObjectMaterial != null)
            {
                Debug.Log("b");
                other.GetComponent<Renderer>().material = selectedObjectMaterial;
            }
        }
    }
}
