using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ButtonPressed : MonoBehaviour
{
   
    public List<bool> objectsPlaced;
    public List<bool> caparrotsInPedestals;

    public List<GameObject> placeHolders;
    private GameManager _gameManager;

    //private BlinkCheck _blinkCheck;

    private bool win = false;

    [Header("Persistent points")] 
    [SerializeField] private IntegerPersistanceVariable Points;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        //_blinkCheck = FindObjectOfType<BlinkCheck>();

        objectsPlaced = Enumerable.Repeat(false,placeHolders.Count).ToList();
        caparrotsInPedestals = Enumerable.Repeat(false,placeHolders.Count).ToList();

        Points.Value = 9000;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //StartCoroutine(Button());
        Press();
    }


    public void Press()
    {
        for (int i = 0; i < objectsPlaced.Count; i++)
        {
            if (objectsPlaced[i])
            {
                placeHolders[i].GetComponent<MeshRenderer>().material.color = Color.green;
            }
            else
            {
                placeHolders[i].GetComponent<MeshRenderer>().material.color = Color.red;
            }
        }

        win = true;
        foreach (var caparrot in objectsPlaced)
        {
            if (caparrot == false)
            {
                win = false;
                Points.Value -= 200; 
                            
                if (Points.Value <= 0) 
                {
                    Points.Value = 0;
                }
            }
        }
                    
        if (win)
        {
            _gameManager.win.Value = true;
            _gameManager.EndGame();
        }
    }

    IEnumerator Button()
    {
        transform.position -= new Vector3(0, 0.05f, 0);
        yield return new WaitForSecondsRealtime(0.05f);
        transform.position += new Vector3(0, 0.05f, 0);
    }
}
