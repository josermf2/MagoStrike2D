using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float force;
    private float timer;

    public AudioSource hitSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, - direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 10)
        {
            Destroy(gameObject);
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            hitSound.Play();
            
            if(other.gameObject.GetComponent<PlayerHealth>().kevlar > 0)
            {
                other.gameObject.GetComponent<PlayerHealth>().kevlar -= 20;
            }
            else 
            {
                other.gameObject.GetComponent<PlayerHealth>().health -= 20;                
            }
            Destroy(gameObject);

        }
        if(other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Interactive"))
        {
            Destroy(gameObject);
        }
    }


}
