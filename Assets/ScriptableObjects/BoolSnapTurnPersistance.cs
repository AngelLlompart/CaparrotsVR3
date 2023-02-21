using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SnapTurnData", menuName = "ScriptableObjects/SnapTurnSO", order = 3)]
public class BoolSnapTurnPersistance : ScriptableObject
{
    private bool _value = false;

    public bool Value
    {
        get => _value;
        set => _value = value;
    }
}