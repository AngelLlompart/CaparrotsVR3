using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ReadPointsGameOver : MonoBehaviour
{
    [SerializeField] private IntegerPersistanceVariable Points;

    [SerializeField] private TextMeshProUGUI txtPoints;
    // Start is called before the first frame update
    void Start()
    {
        txtPoints.text = "Congratulations, you earned " + Points.Value + "!";
    }
}
