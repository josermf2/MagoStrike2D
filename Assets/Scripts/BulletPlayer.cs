using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : MonoBehaviour
{
    private GameObject enemy;
    private Rigidbody2D rb;
    private float force;
    public GameObject cashDrop;
    private float timer;
    private ShootScript shootScript;
    private float bulletTime;

    public AudioSource blockSound;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        shootScript = FindObjectOfType<ShootScript>();
        bulletTime = shootScript.GetCurrentWeapon().bulletTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > bulletTime)
        {
           Destroy(gameObject);
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            Instantiate(cashDrop, transform.position,Quaternion.identity);

        }

        if(other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }

        if(other.gameObject.CompareTag("Interactive"))
        {
            blockSound.Play();
            Destroy(gameObject);
            Destroy(other.gameObject);
            Instantiate(cashDrop, transform.position,Quaternion.identity);

        }
    }
}
