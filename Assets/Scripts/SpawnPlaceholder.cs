using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnPlaceholder : MonoBehaviour
{
    [SerializeField] private List<string> nomsPedestals = new List<string>();

    // Cada Prefab pedestal contiene un GameObject hijo llamado TxtNomCaparrot
    [SerializeField] private List<GameObject> prefabsPedestal;
    //private PlaceHolderChecker _placeHolderChecker;
    private ButtonPressed _buttonPressed;
    
    
    private void Awake()
    {
        _buttonPressed = FindObjectOfType<ButtonPressed>();
        _buttonPressed.placeHolders = prefabsPedestal;
    }

    // Start is called before the first frame update
    void Start()
    {
        nomsPedestals = nomsPedestals.OrderBy(x => Random.value).ToList();
        for (int i = 0; i < prefabsPedestal.Count; i++)
        {
            prefabsPedestal[i].GetComponent<ObjectPlaced>().num = i;
            // Create a new TextMeshPro game object as a child of the current placeholder object
            GameObject textObject = new GameObject("txtPedestal");
            Transform placa = prefabsPedestal[i].transform.Find("Canvas").Find("Placa");
            textObject.transform.SetParent(placa);

            // Add a TextMeshPro component to the text object and set its text to the corresponding string from the textStrings array
            TextMeshProUGUI textComponent = textObject.AddComponent<TextMeshProUGUI>();
            textComponent.text = nomsPedestals[i];
            
            // Set the size and font size of the TextMeshPro component
            RectTransform rectTransform = textObject.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(1f, 1f);
            rectTransform.localPosition = new Vector3(-0.038f, -0.02f, 0f);
            textComponent.alignment = TextAlignmentOptions.Center;
            rectTransform.rotation = Quaternion.Euler(0f, -90f, 0f);
            textComponent.fontSize = 0.15f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
