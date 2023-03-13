using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(ActionBasedController))]
public class HandController : MonoBehaviour
{
    private ActionBasedController controller;

    public Hand hand; 
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<ActionBasedController>();
       /* if (gameObject.name.Equals("LeftHand Controller"))
        {
            hand = GameObject.Find("LeftHand(Clone)").GetComponent<Hand>();
        }
        else
        {
            hand = GameObject.Find("RightHand(Clone)").GetComponent<Hand>();
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        hand.SetGrup(controller.selectAction.action.ReadValue<float>());
        hand.SetTrigger(controller.selectAction.action.ReadValue<float>());
    }
}
