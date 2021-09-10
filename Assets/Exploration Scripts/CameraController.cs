using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
 
    public Transform player;
    private Vector3 offset;

    // Update is called once per frame

    private void Start() {
        
    }
    void Update () 
    {
        // Camera follows the player with specified offset position
        if (player != null)
            transform.position = new Vector3 (player.position.x + offset.x, player.position.y + offset.y, this.transform.position.z); 
    }
}
