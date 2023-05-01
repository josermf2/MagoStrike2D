using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

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
    public GameObject buyMenuUI;
    public int pickupQuantity;
    public TextMeshProUGUI cashText;

    public bool isColliding = false;

    private float damageInterval = 0.5f;
    private float lastDamageTime = 0f;

    public AudioSource dieSound;
    public AudioSource fireCactusSound;
    public AudioSource MoneySound;

    private bool playedDieSound = false;

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

        if (SceneManager.GetActiveScene().buildIndex > 2){
            pickupQuantity = PlayerPrefs.GetInt("Cash");

            PlayerPrefs.DeleteAll();
        }
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

        if (health <= 0 && !playedDieSound){
            dieSound.Play();
            playedDieSound = true;
        }

        if(health <= 0 && playedDieSound)
        {
            health = 0;
            IsDead = true;
            Time.timeScale = 0f;
            buyMenuUI.SetActive(false);
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
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Money"))
        {
            pickupQuantity += 10;
            MoneySound.Play();
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Fire"))
        {
            isColliding = true;
        }        

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fire"))
        {
            isColliding = false;
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
            fireCactusSound.Play();
        }
    }


}
