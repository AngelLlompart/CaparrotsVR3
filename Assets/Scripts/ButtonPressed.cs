using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ButtonPressed : MonoBehaviour
{
   
    public List<bool> objectPlaced;
    public List<bool> caparrotsInPedestals;

    public List<GameObject> placeHolders;
    private GameManager _gameManager;

    //private BlinkCheck _blinkCheck;

    private bool win = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        //_blinkCheck = FindObjectOfType<BlinkCheck>();

        objectPlaced = Enumerable.Repeat(false,placeHolders.Count).ToList();
        caparrotsInPedestals = Enumerable.Repeat(false,placeHolders.Count).ToList();
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
        for (int i = 0; i < objectPlaced.Count; i++)
        {
            if (objectPlaced[i])
            {
                placeHolders[i].GetComponent<MeshRenderer>().material.color = Color.green;
            }
            else
            {
                placeHolders[i].GetComponent<MeshRenderer>().material.color = Color.red;
            }
        }

        win = true;
        foreach (var objects in objectPlaced)
        {
            if (objects == false)
            {
                win = false;
                _gameManager.points -= 200; 
                            
                if (_gameManager.points <= 0) 
                {
                    _gameManager.points = 0;
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
