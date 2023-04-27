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

    private void Start()
    {
        image = GetComponent<Image>();
        originalColor = image.color;

        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (playerHealth.pickupQuantity >= itemPrice)
        {
            image.color = new Color(originalColor.r, originalColor.g, originalColor.b, 1f);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = originalColor;
    }
}
