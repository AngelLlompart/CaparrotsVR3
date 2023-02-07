using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IntegerData", menuName = "ScriptableObjects/IntegerScriptableObject", order = 0)]
public class IntegerPersistanceVariable : ScriptableObject
{
    public int Value = 10000;
}