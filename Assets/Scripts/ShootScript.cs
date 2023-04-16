using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public Transform Gun;
    public Transform Player;

    Vector2 direction;

    public GameObject Bullet;
    public float BulletSpeed;
    public Transform ShootPoint;

    private TouchingDirections groundCheck;
    private bool canShoot = true;

    [SerializeField]
    private float shootDelay = 0.2f;

    private void Start()
    {
        groundCheck = Player.GetComponent<TouchingDirections>();
    }

    private void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Player.localScale.x < 0)
        {
            direction = (Vector2)Gun.position - mousePos;
        }
        else
        {
            direction = mousePos - (Vector2)Gun.position;
        }

        FaceMouse();

        if (groundCheck.IsGrounded)
        {
            Gun.gameObject.SetActive(true);
        }
        else
        {
            Gun.gameObject.SetActive(false);
        }

        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    private void FaceMouse()
    {
        // Check if the player is facing in the same direction as the mouse
        if ((Player.localRotation.eulerAngles.y == 0 && direction.x > 0) ||
            (Player.localRotation.eulerAngles.y == 180 && direction.x < 0))
        {
            Gun.transform.right = direction;
        }
    }

    private IEnumerator Shoot()
    {
        if (!Gun.gameObject.activeSelf) {
            yield break; // Player cannot shoot when not on the ground
        }
        canShoot = false;

        GameObject bulletIns = Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);

        // Check if the player is facing left
        if (Player.localScale.x < 0)
        {
            bulletIns.transform.right = -ShootPoint.right; // Flip bullet direction
        }
        else
        {
            bulletIns.transform.right = ShootPoint.right;
        }

        bulletIns.GetComponent<Rigidbody2D>().AddForce(bulletIns.transform.right * BulletSpeed);

        yield return new WaitForSeconds(shootDelay);

        canShoot = true;
    }
}
