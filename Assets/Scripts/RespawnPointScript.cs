using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPointScript : MonoBehaviour
{
    public Vector3 spawnPosition;
    public Quaternion spawnRotation;

    void Start()
    {
        // Set the spawn position and rotation to the initial position and rotation of the RespawnPoint
        spawnPosition = transform.position;
        spawnRotation = transform.rotation;
    }


}
