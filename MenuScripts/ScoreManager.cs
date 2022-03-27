using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using System.Linq;


public class ScoreManager : MonoBehaviour
{
    #region Singleton
    private static ScoreManager _instance;
    public static ScoreManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Scoremanager singleton doesnt work properly");
            }

            return _instance;
        }
    }

    void Awake()
    {

        if (ScoreManager._instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        playerScore = new PlayerScore();
        playerData = new PlayerData();
        playerData.playerScoreJson = new List<PlayerScore>();
        LoadScore();
        DontDestroyOnLoad(this.gameObject);
    }

    #endregion

                   
    public static PlayerScore playerScore;
    public static PlayerData playerData;
    public static string playerNameInput;
    public static string json;
    public static bool canSaveScore = false;
    public int maxHighScoreListCount = 9;

    #region Serializable player informations
    [Serializable]
    public class PlayerScore
    {
        public string playerName;
        public int point;
    }

    [Serializable]
    public class PlayerData
    {
        public List<PlayerScore> playerScoreJson;
    }
    #endregion

    void Update()
    {
        if (canSaveScore == true)
        {
            SaveScore();
            canSaveScore = false;
        }
    }
    
    public static void LoadScore()
    {
        if (!File.Exists(Application.persistentDataPath + "/highscores.json"))
        {
            File.Create(Application.persistentDataPath + "/highscores.json");            
        }
        else
        {            
            json = File.ReadAllText(Application.persistentDataPath + "/highscores.json");
            playerData = JsonUtility.FromJson<PlayerData>(json);           
        }
    }

    public static void SaveScore()
    {
        playerData.playerScoreJson.Add(playerScore);        
        playerData.playerScoreJson = playerData.playerScoreJson.OrderByDescending(x => x.point).ToList();

        while (playerData.playerScoreJson.Count > 8)
        {
           playerData.playerScoreJson.RemoveAt(8);
        }

        json = JsonUtility.ToJson(playerData,true);
        File.WriteAllText(Application.persistentDataPath + "/highscores.json",json);
    }
    public static List<PlayerScore> GetList()
    {
        return playerData.playerScoreJson;
    }
}
