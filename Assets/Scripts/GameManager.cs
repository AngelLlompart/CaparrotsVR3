using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using TMPro;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class GameManager : MonoBehaviour
{
    //public bool win;
    [SerializeField] public BooleanSO win;
    private GameObject _player;
    private Timer _timer;
    public int points = 10000;
    [SerializeField] private TextMeshProUGUI username;
    [SerializeField] private TMP_InputField userInput;
    [SerializeField] private Button btnConfirm;
    [SerializeField] private TextMeshProUGUI txtPoints;
    [SerializeField] private GameObject xrCanvas;
    [SerializeField] private XROrigin playerOrigin;

    // Start is called before the first frame update
    void Start()
    {
        InitLevel();
        btnConfirm.onClick.AddListener(Confirm);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (userInput.text == String.Empty || userInput.text == null)
        {
            btnConfirm.interactable = false;
        }
        else
        {
            btnConfirm.interactable = true;
        }
    }
    
    private void Confirm()
    {
        //PlayerInfoClass player = new PlayerInfoClass(userInput.text, 100);
        var filePath = Path.Combine(Application.persistentDataPath, "Leaderboard.json");
        AllPlayersInfoClass playersInfo = new AllPlayersInfoClass();
        playersInfo.PlayersInfos = new List<PlayerInfoClass>();
        
        if (File.Exists(filePath))
        { 
            playersInfo = JsonConvert.DeserializeObject<AllPlayersInfoClass>(File.ReadAllText(filePath)); 
        }
        
        //PlayersInfo playersInfo = new PlayersInfo();
        PlayerInfoClass player = new PlayerInfoClass();
        player.Name = userInput.text;
        player.Points = points;

        
        playersInfo.PlayersInfos.Add(player);
        var jsonString = JsonConvert.SerializeObject(playersInfo);
        File.WriteAllText(filePath, jsonString);


        SceneManager.LoadScene("GameOver");
    }
    
    public void EndGame()
    {
        //desactivar manos y activar otra
        xrCanvas.SetActive(true);
        playerOrigin.transform.position = Vector3.zero;
        
        playerOrigin.GetComponent<ActionBasedContinuousMoveProvider>().enabled = false;
        playerOrigin.GetComponent<ActionBasedContinuousTurnProvider>().enabled = false;
        _player.transform.Find("LeftHand Controller").gameObject.SetActive(false);
        _player.transform.Find("LeftHand ControllerMenu").gameObject.SetActive(true);
        _timer.StopTimer();
        //_player.gameObject.GetComponent<PlayerController>().enabled = false;
        //Cursor.visible = true;
        //Cursor.lockState = CursorLockMode.None;
        //Time.timeScale = 0;
        if (win.Value)
        {
            txtPoints.text = "Points: " + points;
        }
        else
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void InitLevel()
    {
        _timer = GameObject.FindObjectOfType<Timer>();
        _player = GameObject.Find("Camera Offset");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        win.Value = false;
        xrCanvas.SetActive(false);
    }
}
