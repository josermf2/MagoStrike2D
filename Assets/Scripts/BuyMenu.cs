using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyMenu : MonoBehaviour
{
    public static bool buyMenu = false;
    
    public bool buyArea = false;

    public GameObject buyMenuUI;
    public GameObject pauseMenuUI;
    private GameObject player;
    private PlayerHealth playerHealth;
    private ShootScript shootScript;

    void Start()
    { 
        player = GameObject.Find("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        shootScript = player.GetComponent<ShootScript>();
    }
    
    // Update is called once per frame
    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.Z) && buyArea && !PauseMenu.gameIsPaused)
        {
            if (buyMenu)
            {
                buyMenuUI.SetActive(false);
                buyMenu = false; 
            }
            else
            {
                buyMenuUI.SetActive(true);
                buyMenu = true;
            }
        } 
        if (!buyArea) 
        {
            buyMenuUI.SetActive(false);
            buyMenu = false;
        }
    }

    public void BuyKevlar()
    {

        if (playerHealth.pickupQuantity >= 0)
        {
            playerHealth.pickupQuantity -= 0;
            if (playerHealth.kevlar < 50){
                playerHealth.pickupQuantity -= 0;
                playerHealth.kevlar = 50;
            }
        }
    }

    public void BuyKevlarHelmet()
    {
        if (playerHealth.pickupQuantity >= 0)
        {
            if (playerHealth.kevlar < 100){
                playerHealth.pickupQuantity -= 0;
                playerHealth.kevlar = 100;
            }
        }
    }

    public void BuyDeagle()
    {
        if (playerHealth.pickupQuantity >= 0)
        {
            playerHealth.pickupQuantity -= 0;
            shootScript.currentWeaponIndex = 5;
            shootScript.SetCurrentWeaponActive();

        }
    }

    public void BuyAk()
    {
        if (playerHealth.pickupQuantity >= 0)
        {
            playerHealth.pickupQuantity -= 0;
            shootScript.currentWeaponIndex = 1;
            shootScript.SetCurrentWeaponActive();

        }
    }

    public void BuyAwp()
    {
        if (playerHealth.pickupQuantity >= 0)
        {
            playerHealth.pickupQuantity -= 0;
            shootScript.currentWeaponIndex = 4;
            shootScript.SetCurrentWeaponActive();
        }
    }

    public void BuyMac()
    {
        if (playerHealth.pickupQuantity >= 0)
        {
            playerHealth.pickupQuantity -= 0;
            shootScript.currentWeaponIndex = 2;
            shootScript.SetCurrentWeaponActive();

        }
    }

    public void BuyGalil()
    {
        if (playerHealth.pickupQuantity >= 0)
        {
            playerHealth.pickupQuantity -= 0;
            shootScript.currentWeaponIndex = 3;
            shootScript.SetCurrentWeaponActive();

        }
    }
}

