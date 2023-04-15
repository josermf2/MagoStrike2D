 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public Transform Gun;
    public Transform Player;

    Vector2 direction;

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Player.localScale.x < 0) {
            direction = (Vector2)Gun.position - mousePos;
        } else {
            direction = mousePos - (Vector2)Gun.position;
        }

        FaceMouse();
    }

    void FaceMouse()
    {
        // Check if the player is facing in the same direction as the mouse
        if (Player.localRotation.eulerAngles.y == 0 && direction.x > 0 || 
            Player.localRotation.eulerAngles.y == 180 && direction.x < 0)
        {
            Gun.transform.right = direction;
        }
    }
}