using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Weapon {
    public string name;
    public Transform gun;
    public Transform shootPoint;
    public float bulletSpeed;
    public float shootDelay;
    public float bulletTime;
}

public class ShootScript : MonoBehaviour
{
    public List<Weapon> weapons;  
    public int currentWeaponIndex = 0;

    Vector2 direction;

    public GameObject Bullet;

    private TouchingDirections groundCheck;
    private bool canShoot = true;


    private void Start()
    {
        groundCheck = GetComponent<TouchingDirections>();
        SetCurrentWeaponActive();
    }

    private void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (transform.localScale.x < 0)
        {
            direction = (Vector2)GetCurrentWeapon().gun.position - mousePos;
        }
        else
        {
            direction = mousePos - (Vector2)GetCurrentWeapon().gun.position;
        }

        FaceMouse();

        if (groundCheck.IsGrounded)
        {
            GetCurrentWeapon().gun.gameObject.SetActive(true);
        }
        else
        {
            GetCurrentWeapon().gun.gameObject.SetActive(false);
        }

        /*if (Input.GetKeyDown(KeyCode.F))
        {
            currentWeaponIndex = (currentWeaponIndex + 1) % weapons.Count;
            SetCurrentWeaponActive();
        }*/

        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    private void FaceMouse()
    {
        // Check if the player is facing in the same direction as the mouse
        if ((transform.localRotation.eulerAngles.y == 0 && direction.x > 0) ||
            (transform.localRotation.eulerAngles.y == 180 && direction.x < 0))
        {
            GetCurrentWeapon().gun.transform.right = direction;
        }
    }

    private IEnumerator Shoot()
    {
        if (!GetCurrentWeapon().gun.gameObject.activeSelf) {
            yield break; // Player cannot shoot when not on the ground
        }
        canShoot = false;

        GameObject bulletIns = Instantiate(Bullet, GetCurrentWeapon().shootPoint.position, GetCurrentWeapon().shootPoint.rotation);

        // Check if the player is facing left
        if (transform.localScale.x < 0)
        {
            bulletIns.transform.right = -GetCurrentWeapon().shootPoint.right; // Flip bullet direction
        }
        else
        {
            bulletIns.transform.right = GetCurrentWeapon().shootPoint.right;
        }

        bulletIns.GetComponent<Rigidbody2D>().AddForce(bulletIns.transform.right * GetCurrentWeapon().bulletSpeed);

        yield return new WaitForSeconds(GetCurrentWeapon().shootDelay);

        canShoot = true;
    }

    public void SetCurrentWeaponActive()
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            weapons[i].gun.gameObject.SetActive(i == currentWeaponIndex);
        }
    }

    public void SetCurrentWeaponInactive()
    {
        GetCurrentWeapon().gun.gameObject.SetActive(false);
    }

    public Weapon GetCurrentWeapon()
    {
        return weapons[currentWeaponIndex];
    }
}
