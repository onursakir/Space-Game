using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScorePrefabCreator : MonoBehaviour
{
    [SerializeField] GameObject prefab;

    void OnEnable() {
        foreach (var item in ScoreManager.GetList()) 
        {
            prefab.GetComponent<TextMeshProUGUI>().text = item.playerName;
            prefab.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = item.point.ToString();            
            Instantiate(prefab,transform);
        }         
    }
}
