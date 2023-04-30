using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{

    public GameObject endMenuUI;

    public void Restart(){
        Time.timeScale = 1f;
        endMenuUI.SetActive(false); 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextPhase(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitMenu(){
        Debug.Log("Quit");
        Application.Quit();
    }
}
