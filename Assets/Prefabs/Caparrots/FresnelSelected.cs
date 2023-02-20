using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FresnelSelected : MonoBehaviour
{
    [SerializeField] private Material highlightMaterial;

    private Material objectMaterial;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fresnel()
    {
        objectMaterial = GetComponent<Renderer>().material;
        GetComponent<Renderer>().material = highlightMaterial;
    }

    public void NormalMat()
    {
        GetComponent<Renderer>().material = objectMaterial;
    }
}
