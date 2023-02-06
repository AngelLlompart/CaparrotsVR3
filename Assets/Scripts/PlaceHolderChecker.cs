using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceHolderChecker : MonoBehaviour
{
    public bool[] objectPlaced = {false, false, false};
    public bool[] caparrotsInPedestals = {false, false, false};
    public List<GameObject> placeHolders;
    private GameManager _gameManager;
   // private BlinkCheck _blinkCheck;

    [SerializeField] private float pickupRange = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
     //   _blinkCheck = FindObjectOfType<BlinkCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit,
                    pickupRange))
            {
                if (hit.transform.CompareTag("Button") && _gameManager.win.Value != true)
                {
                    //_blinkCheck.buttonHit = true;
                    StartCoroutine(button(hit.transform));
                    if (objectPlaced[0])
                    {
                        placeHolders[0].GetComponent<MeshRenderer>().material.color = Color.green;
                    }
                    else
                    {
                        placeHolders[0].GetComponent<MeshRenderer>().material.color = Color.red;
                    }
                    
                    if (objectPlaced[1])
                    {
                        placeHolders[1].GetComponent<MeshRenderer>().material.color = Color.green;
                    }
                    else
                    {
                        placeHolders[1].GetComponent<MeshRenderer>().material.color = Color.red;
                    }
                    
                    if (objectPlaced[2])
                    {
                        placeHolders[2].GetComponent<MeshRenderer>().material.color = Color.green;
                    }
                    else
                    {
                        placeHolders[2].GetComponent<MeshRenderer>().material.color = Color.red;
                    }


                    if (objectPlaced[0] && objectPlaced[1] && objectPlaced[2])
                    {
                        _gameManager.win.Value = true;
                        _gameManager.EndGame();
                    }
                    else
                    {
                        _gameManager.points -= 200;
                        if (_gameManager.points <= 0)
                        {
                            _gameManager.points = 0;
                        }
                    }
                }
            }
        }
    }

    IEnumerator button(Transform transform)
    {
        transform.position -= new Vector3(0, 0.05f, 0);
        yield return new WaitForSecondsRealtime(0.05f);
        transform.position += new Vector3(0, 0.05f, 0);
    }
}
