using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyAreas : MonoBehaviour
{
    private GameObject Canvas;
    private BuyMenu buyMenu;

    void Start()
    { 
        Canvas = GameObject.Find("Canvas");
        buyMenu = Canvas.GetComponent<BuyMenu>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            buyMenu.buyArea = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            buyMenu.buyArea = false;
        }
    }
}

