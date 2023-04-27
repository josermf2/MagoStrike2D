using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyMenu : MonoBehaviour
{
    public static bool buyMenu = false;

    public GameObject buyMenuUI;
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
        if (Input.GetKeyDown(KeyCode.Z))
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
    }

    public void BuyKevlar()
    {

        if (playerHealth.pickupQuantity >= 50)
        {
            playerHealth.pickupQuantity -= 50;
            playerHealth.kevlar += 50;
            Debug.Log("Kevlar purchased! Money: " + playerHealth.pickupQuantity + " Kevlar: " + playerHealth.kevlar);
        }
        else
        {
            Debug.Log("Not enough money to buy kevlar!");
        }
    }

    public void BuyKevlarHelmet()
    {
        if (playerHealth.pickupQuantity >= 80)
        {
            playerHealth.pickupQuantity -= 80;
            playerHealth.kevlar += 100;
            Debug.Log("Kevlar and Helmet purchased! Money: " + playerHealth.pickupQuantity + " Kevlar: " + playerHealth.kevlar);
        }
        else
        {
            Debug.Log("Not enough money to buy kevlar and helmet!");
        }
    }

    public void BuyDeagle()
    {
        if (playerHealth.pickupQuantity >= 10)
        {
            playerHealth.pickupQuantity -= 10;
            shootScript.currentWeaponIndex = 5;
            shootScript.SetCurrentWeaponActive();

        }
        else
        {
            Debug.Log("Not enough money to buy deagle");
        }
    }

    public void BuyAk()
    {
        if (playerHealth.pickupQuantity >= 10)
        {
            playerHealth.pickupQuantity -= 10;
            shootScript.currentWeaponIndex = 1;
            shootScript.SetCurrentWeaponActive();

        }
        else
        {
            Debug.Log("Not enough money to buy ak");
        }
    }

    public void BuyAwp()
    {
        if (playerHealth.pickupQuantity >= 10)
        {
            playerHealth.pickupQuantity -= 10;
            shootScript.currentWeaponIndex = 4;
            shootScript.SetCurrentWeaponActive();

        }
        else
        {
            Debug.Log("Not enough money to buy ak");
        }
    }

    public void BuyMac()
    {
        if (playerHealth.pickupQuantity >= 10)
        {
            playerHealth.pickupQuantity -= 10;
            shootScript.currentWeaponIndex = 2;
            shootScript.SetCurrentWeaponActive();

        }
        else
        {
            Debug.Log("Not enough money to buy ak");
        }
    }

    public void BuyGalil()
    {
        if (playerHealth.pickupQuantity >= 10)
        {
            playerHealth.pickupQuantity -= 10;
            shootScript.currentWeaponIndex = 3;
            shootScript.SetCurrentWeaponActive();

        }
        else
        {
            Debug.Log("Not enough money to buy ak");
        }
    }
}

