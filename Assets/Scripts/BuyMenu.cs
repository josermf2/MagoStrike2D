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

    public AudioSource buySound;

    void Start()
    { 
        player = GameObject.Find("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        shootScript = player.GetComponent<ShootScript>();
    }
    
    // Update is called once per frame
    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.Z) && buyArea && !PauseMenu.gameIsPaused && !playerHealth.IsDead)
        {
            if (buyMenu)
            {
                buyMenuUI.SetActive(false);
                buyMenu = false; 
                shootScript.canShoot = true;
            }
            else
            {
                shootScript.canShoot = false;
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

        if (playerHealth.pickupQuantity >= 80)
        {
            if (playerHealth.kevlar < 50){
                playerHealth.pickupQuantity -= 80;
                playerHealth.kevlar = 50;
                buySound.Play();
            }
        }
    }

    public void BuyKevlarHelmet()
    {
        if (playerHealth.pickupQuantity >= 200)
        {
            if (playerHealth.kevlar < 100){
                playerHealth.pickupQuantity -= 200;
                playerHealth.kevlar = 100;
                buySound.Play();
            }
        }
    }

    public void BuyDeagle()
    {
        if (playerHealth.pickupQuantity >= 100)
        {
            playerHealth.pickupQuantity -= 100;
            shootScript.currentWeaponIndex = 5;
            shootScript.SetCurrentWeaponActive();
            buySound.Play();
        }
    }

    public void BuyAk()
    {
        if (playerHealth.pickupQuantity >= 460)
        {
            playerHealth.pickupQuantity -= 460;
            shootScript.currentWeaponIndex = 1;
            shootScript.SetCurrentWeaponActive();
            buySound.Play();
        }
    }

    public void BuyAwp()
    {
        if (playerHealth.pickupQuantity >= 660)
        {
            playerHealth.pickupQuantity -= 660;
            shootScript.currentWeaponIndex = 4;
            shootScript.SetCurrentWeaponActive();
            buySound.Play();
        }
    }

    public void BuyMac()
    {
        if (playerHealth.pickupQuantity >= 220)
        {
            playerHealth.pickupQuantity -= 220;
            shootScript.currentWeaponIndex = 2;
            shootScript.SetCurrentWeaponActive();
            buySound.Play();
        }
    }

    public void BuyGalil()
    {
        if (playerHealth.pickupQuantity >= 260)
        {
            playerHealth.pickupQuantity -= 260;
            shootScript.currentWeaponIndex = 3;
            shootScript.SetCurrentWeaponActive();
            buySound.Play();
        }
    }
}

