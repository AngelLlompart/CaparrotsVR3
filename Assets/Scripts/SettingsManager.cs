using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] private BoolSnapTurnPersistance snapTurn;

    [SerializeField] private TeleportBoolPersistence teleport;

    [SerializeField] private Toggle snapTurnToggle;
    [SerializeField] private Toggle continuousTurnToggle;
    [SerializeField] private Toggle teleportToggle;
    [SerializeField] private Toggle continuousMoveToggle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (snapTurnToggle.isOn)
        {
            snapTurn.Value = true;
        }
        else
        {
            snapTurn.Value = false;
        }

        if (teleportToggle.isOn)
        {
            teleport.Value = true;
        }
        else
        {
            teleport.Value = false;
        }
        
    }

    public void ContinuousTurnToggle()
    {
        if (continuousTurnToggle.isOn)
        {
            snapTurnToggle.isOn = false;
        }
        else
        {
            snapTurnToggle.isOn = true;
        }
    }
    
    public void SnapTurnToggle()
    {
        if (snapTurnToggle.isOn)
        { 
            continuousTurnToggle.isOn = false;
        }
        else
        {
            continuousTurnToggle.isOn = true;
        }
    }
    
    public void ContinuousMoveToggle()
    {
        if (continuousMoveToggle.isOn)
        {
            teleportToggle.isOn = false;
        }
        else
        {
            teleportToggle.isOn = true;
        }
    }
    
    public void TeleportToggle()
    {
        if (teleportToggle.isOn)
        { 
            continuousMoveToggle.isOn = false;
        }
        else
        {
            continuousMoveToggle.isOn = true;
        }
    }
}
