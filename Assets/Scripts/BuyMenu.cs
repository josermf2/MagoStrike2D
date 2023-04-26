using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyMenu : MonoBehaviour
{
    public static bool buyMenu = false;

    public GameObject buyMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (buyMenu)
            {
                buyMenuUI.SetActive(false);
                buyMenu = false;
            }
            else
            {
                buyMenuUI.SetActive(true);
                buyMenu = true;
            }
        }
    }
}
