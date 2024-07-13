using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public GameObject creditsPanel;

    private void Awake()
    {
        creditsPanel.SetActive(false);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenCredit(){
        creditsPanel.SetActive(true);
    }    
    public void CloseCredt(){
        creditsPanel.SetActive(false);
    }

    public void ExitGame(){
        Application.Quit();
    }
}
