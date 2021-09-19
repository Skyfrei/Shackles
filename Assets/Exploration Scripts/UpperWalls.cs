using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperWalls : MonoBehaviour
{
    // Start is called before the first frame update
    private Character player;
    private Vector2 wallPosition;
    void Start()
    {
        player = GameObject.FindObjectOfType<Character>();
        wallPosition = this.transform.position;
    }

    private void FixedUpdate() {
        if (player.Position.y + 0.35 >= wallPosition.y)
        {
            
        }
    }
}
