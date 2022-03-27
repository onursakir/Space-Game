using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using TMPro;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject buttons;
    [SerializeField] GameObject playerNamePanel;    
    [SerializeField] GameObject highScorePanel;    
    [SerializeField] GameObject generalPanel;

    [SerializeField] Text playerName;
    [SerializeField] TextMeshProUGUI gamesTxt;

    public void StartButton()
    {       
        gamesTxt.gameObject.SetActive(false);
        buttons.SetActive(false);
        playerNamePanel.SetActive(true);
    }

    public void StartSpaceGame()
    {
        if (playerName.text.Length > 0)
        {
            ScoreManager.playerNameInput = playerName.text;            
            SceneManager.LoadScene("SpaceGame");
        }else
        {
            Debug.Log("Please write your name");
        }
    }
         
    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    } 

    public void HighScoreButton()
    {
        highScorePanel.SetActive(true);        
        generalPanel.SetActive(false);
    }   

    public void GetBackFromHighScorePanel()
    { 
        generalPanel.SetActive(true);
        highScorePanel.SetActive(false); 
    }
    
}
