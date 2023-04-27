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

    public float kevlar; 
    public float maxKevlar;
    public Image kevlarBar;
    public TextMeshProUGUI kevlarText;

    public Animator animator;
    public GameObject restartMenuUI;
    public int pickupQuantity;
    public TextMeshProUGUI cashText;

    public bool isColliding = false;

    private float damageInterval = 0.5f;
    private float lastDamageTime = 0f;

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
        maxKevlar = 100;
        healthText.text = maxHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
        healthText.text = health.ToString();
    
        kevlarBar.fillAmount = Mathf.Clamp(kevlar / maxKevlar, 0, 1);
        kevlarText.text = kevlar.ToString();

        cashText.text = pickupQuantity.ToString();

        if (kevlar < 0){
            health += kevlar;
            kevlar = 0;
        }

        if(health <= 0)
        {
            health = 0;
            IsDead = true;
            Time.timeScale = 0f;
            restartMenuUI.SetActive(true);
        }

        if (isColliding && !IsInvoking("DamageOverTime"))
        {
            InvokeRepeating("DamageOverTime", 0f, damageInterval);
        }
        else if (!isColliding && IsInvoking("DamageOverTime"))
        {
            CancelInvoke("DamageOverTime");
        }

        //Debug.Log(isColliding);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Money"))
        {
            pickupQuantity += 10;
            Destroy(other.gameObject);
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Cactus")
        {
            isColliding = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Cactus")
        {
            isColliding = false;
        }
    }

    private void DamageOverTime()
    {
        if (Time.time - lastDamageTime >= damageInterval)
        {
            health -= 40;
            lastDamageTime = Time.time;
        }
    }


}
