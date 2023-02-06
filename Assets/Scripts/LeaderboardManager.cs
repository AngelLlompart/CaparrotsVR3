using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;

public class LeaderboardManager : MonoBehaviour
{

    [SerializeField] private BooleanSO _win;
    [SerializeField] private GameObject[] leaderBoardPlayers;

    [SerializeField] private GameObject leaderBoard;

    [SerializeField] private GameObject txtLose;
    // Start is called before the first frame update
    void Start()
    {
        if (_win.Value)
        {
            txtLose.SetActive(false);
            leaderBoard.SetActive(true);
            var filePath = Path.Combine(Application.persistentDataPath, "Leaderboard.json");
            AllPlayersInfoClass playersInfo = JsonConvert.DeserializeObject<AllPlayersInfoClass>(File.ReadAllText(filePath));
            playersInfo.PlayersInfos = playersInfo.PlayersInfos.OrderByDescending(x => x.Points).ToList();
            for (int i = 0; i < leaderBoardPlayers.Length; i++)
            {
                if (i >= playersInfo.PlayersInfos.Count)
                {
                    break;
                }
                leaderBoardPlayers[i].transform.Find("txtPlayer").GetComponent<TextMeshProUGUI>().text = playersInfo.PlayersInfos[i].Name;
                leaderBoardPlayers[i].transform.Find("txtPoints").GetComponent<TextMeshProUGUI>().text = playersInfo.PlayersInfos[i].Points.ToString();
            } 
        }
        else
        {
            txtLose.SetActive(true);
            leaderBoard.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
