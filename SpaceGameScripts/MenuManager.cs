using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    #region  Singleton
    public static MenuManager instance;

    private void Awake() 

    {
        instance = this;
        isGameOn = true;
        Time.timeScale = 1;
    }
    #endregion

    public int totalPoint;
    public bool isGameOn = true;

    [SerializeField] Text scoreText;
    [SerializeField] Image menuImage;
    [SerializeField] GameObject player;
    
    Vector3 scaleVector = new Vector3(1.1f,1.1f,1.1f);
    Vector3 normalScaleVector = new Vector3(1,1,1);

    float waitingTime = 0.2f;

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (MenuManager.instance.isGameOn)
            {
                MenuManager.instance.GetMenu();
                
            }else if(player.activeInHierarchy)
            {
                MenuManager.instance.CloseMenu();                
            }
        }
    }
    
    public void AddPoint(int point)
    {
        totalPoint += point;

        scoreText.text =  "Score : " + totalPoint;
        StartCoroutine("textScaleRoutine");        
    }

    IEnumerator textScaleRoutine()
    {
        scoreText.GetComponent<RectTransform>().DOScale(scaleVector,waitingTime).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(waitingTime);
        scoreText.GetComponent<RectTransform>().DOScale(normalScaleVector,waitingTime).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(waitingTime);
    }
    IEnumerator CloseMenuWithDelay()
    {
        yield return new WaitForSeconds(1);
        
        menuImage.gameObject.transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
        menuImage.gameObject.SetActive(false);        
    }


    public void GetMenu()
    {
        menuImage.gameObject.SetActive(true);        
        menuImage.gameObject.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);

        Time.timeScale = 0;
        isGameOn = false;
    }

    public void CloseMenu()
    {
        menuImage.gameObject.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);   
        menuImage.gameObject.SetActive(false);          
        StartCoroutine(CloseMenuWithDelay());
        Time.timeScale = 1;
        isGameOn = true;
    }

    public void GameOver()
    {
        ScoreManager.playerScore = new ScoreManager.PlayerScore();
        ScoreManager.playerScore.playerName = ScoreManager.playerNameInput;
        ScoreManager.playerScore.point = totalPoint;
        ScoreManager.canSaveScore = true; 
        menuImage.gameObject.transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(true); // Paused game panel activation
        menuImage.gameObject.SetActive(true);
    }

    public void RestartButton()
    {
        CloseMenu();
        SceneManager.LoadScene("SpaceGame");
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("MenuScene");
    }

}
