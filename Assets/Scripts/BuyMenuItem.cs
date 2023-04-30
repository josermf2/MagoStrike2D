using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuyMenuItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int itemPrice;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private PlayerHealth playerHealth;
    private Image image;

    private Transform popUpNoMoneyTransform;
    private GameObject popUpNoMoney; 

    private Transform popUpInfoTransform;
    private GameObject popUpInfo;

    private void Start()
    {
        image = GetComponent<Image>();
        originalColor = image.color;

        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        
        popUpNoMoneyTransform = transform.Find("popUpNoMoney");
        popUpNoMoney = popUpNoMoneyTransform.gameObject;

        popUpInfoTransform = transform.Find("popUpInfo");
        popUpInfo = popUpInfoTransform.gameObject;

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (playerHealth.pickupQuantity >= itemPrice)
        {
            image.color = new Color(originalColor.r, originalColor.g, originalColor.b, 1f);
            popUpInfo.SetActive(true);  
        } else {
            popUpNoMoney.SetActive(true);
        }
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = originalColor;
        
        if (popUpNoMoney.activeSelf){
            popUpNoMoney.SetActive(false);
        }

        if (popUpInfo.activeSelf){
            popUpInfo.SetActive(false);
        }
    }
}
