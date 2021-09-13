using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    private Character character;
    private Vector3 offset;

    // Update is called once per frame

    private void Start() {
        character = GameObject.FindObjectOfType<Character>();
    }
    void Update () 
    {
        // Camera follows the player with specified offset position
        if (transform != null)
            transform.position = new Vector3 (character.Position.x + offset.x, character.Position.y + offset.y, this.transform.position.z); 
    }
}
