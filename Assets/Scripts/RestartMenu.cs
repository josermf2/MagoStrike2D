using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartMenu : MonoBehaviour
{
    public GameObject restartMenuUI;
    public GameObject Player;

    private PlayerController playerScript;

    public void Start () {
        playerScript = Player.GetComponent<PlayerController>();
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        restartMenuUI.SetActive(false); 

        if (playerScript.respawnPoint != Vector3.zero)
        {
            playerScript.Respawn();
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

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
