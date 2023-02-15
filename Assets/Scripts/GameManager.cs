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
    private TouchScreenKeyboard keyboard;

    // Start is called before the first frame update
    void Start()
    {
        InitLevel();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (username.text == String.Empty || username.text == null)
        {
            btnConfirm.interactable = false;
        }
        else
        {
            btnConfirm.interactable = true;
        }
    }
    
    public void Confirm()
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
        player.Name = username.text;
        player.Points = points;

        
        playersInfo.PlayersInfos.Add(player);
        var jsonString = JsonConvert.SerializeObject(playersInfo);
        File.WriteAllText(filePath, jsonString);


        SceneManager.LoadScene("GameOver");
    }
    
    public void EndGame()
    {
        //desactivar manos y activar otra
       
        _timer.StopTimer();
        //_player.gameObject.GetComponent<PlayerController>().enabled = false;
        //Cursor.visible = true;
        //Cursor.lockState = CursorLockMode.None;
        //Time.timeScale = 0;
        if (win.Value)
        { 
            xrCanvas.SetActive(true);
            playerOrigin.transform.position = new Vector3(0,0,0);
            _player.transform.position = new Vector3(0,0,0);
        
            playerOrigin.GetComponent<ActionBasedContinuousMoveProvider>().enabled = false;
            playerOrigin.GetComponent<ActionBasedContinuousTurnProvider>().enabled = false;
            playerOrigin.GetComponent<TeleportationProvider>().enabled = false;
            _player.transform.Find("LeftHand Controller").gameObject.SetActive(false);
            _player.transform.Find("LeftHand Ray").gameObject.SetActive(false);
            _player.transform.Find("LeftHand ControllerMenu").gameObject.SetActive(true);
            _player.transform.Find("RightHand Controller").gameObject.SetActive(false);
            _player.transform.Find("RightHand ControllerMenu").gameObject.SetActive(true);
            txtPoints.text = "Points: " + points;
        }
        else
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void OpenKeyboard()
    {
        if (keyboard != null)
        {
            keyboard.active = true;
        }
        else
        {
            TouchScreenKeyboard.Open("");
        }
    }

    public void CloseKeyboard()
    {
        keyboard.active = false;
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
