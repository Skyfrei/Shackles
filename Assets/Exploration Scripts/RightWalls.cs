using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightWalls : MonoBehaviour
{
    // Start is called before the first frame update
    private Character player;
    private Vector2 wallPosition;

    void Start()
    {
        wallPosition = this.transform.position;
        player = GameObject.FindObjectOfType<Character>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (player.Position.x + 0.35 >= wallPosition.x)
        {
            
        }
    }
}
