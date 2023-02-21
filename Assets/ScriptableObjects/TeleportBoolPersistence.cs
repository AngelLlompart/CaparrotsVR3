using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TeleportBoolData", menuName = "ScriptableObjects/TeleportBoolSO", order = 0)]
public class TeleportBoolPersistence : ScriptableObject
{
    public bool Value = true;
}