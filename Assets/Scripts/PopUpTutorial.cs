using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpTutorial : MonoBehaviour
{

    public GameObject popUpWalk;
    public GameObject popUpRun;
    public GameObject popUpJump;
    public GameObject popUpPath;
    public GameObject popUpFire;
    public GameObject popUpMoney;
    public GameObject popUpRespawn;
    public GameObject popUpBlock;
    public GameObject popUpEnemy;


    void onTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PopUpArea"))
        {
            if (other.gameObject.name == "ColliderWalk")
            {
                popUpWalk.SetActive(true);
            } 

            if (other.gameObject.name == "ColliderRun")
            {
                popUpRun.SetActive(true);
            } 

            if (other.gameObject.name == "ColliderJump")
            {
                popUpJump.SetActive(true);
            } 

            if (other.gameObject.name == "ColliderChoosePath")
            {
                popUpPath.SetActive(true);
            } 

            if (other.gameObject.name == "ColliderFire")
            {
                popUpFire.SetActive(true);
            } 

            if (other.gameObject.name == "ColliderMoney")
            {
                popUpMoney.SetActive(true);
            } 

            if (other.gameObject.name == "ColliderRespawn")
            {
                popUpRespawn.SetActive(true);
            } 

            if (other.gameObject.name == "ColliderBlock")
            {
                popUpBlock.SetActive(true);
            } 

            if (other.gameObject.name == "ColliderEnemy")
            {
                popUpEnemy.SetActive(true);
            } 
        }
    }

}
