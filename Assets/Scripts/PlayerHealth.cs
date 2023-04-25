using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public float health; 
    public float maxHealth;
    public Image healthBar;
    public TextMeshProUGUI healthText;
    public Animator animator;
    public GameObject restartMenuUI;
    public int pickupQuantity;
    public TextMeshProUGUI cashText;

    [SerializeField]
    private bool _isDead = false;
    public bool IsDead { get
        {
            return _isDead;
        } 
        set
            {
                _isDead = value;
                animator.SetBool("isDead", value);
            }
    }

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        healthText.text = maxHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
        healthText.text = health.ToString();

        cashText.text = pickupQuantity.ToString();

        if(health <= 0)
        {
            IsDead = true;
            Time.timeScale = 0f;
            restartMenuUI.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Money"))
        {
            pickupQuantity += 10;
            Destroy(other.gameObject);
        }
    }
}
