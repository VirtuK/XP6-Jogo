using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollider : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerMovement player;

    private void Start()
    {
        player = FindAnyObjectByType<PlayerMovement>();
    }
    private void OnTriggerEnter(Collider other)
    {
        print("a");
        player.canMove = false;
    }

    private void OnTriggerExit(Collider other)
    {
        player.canMove = true;
    }
}
