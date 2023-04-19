using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartMenu : MonoBehaviour
{
    public GameObject restartMenuUI;

    public void Restart(){
        Time.timeScale = 1f;
        restartMenuUI.SetActive(false); 
        SceneManager.LoadScene("Dust");
    }

    public void LoadMenu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitMenu(){
        Debug.Log("Quit");
        Application.Quit();
    }

}
