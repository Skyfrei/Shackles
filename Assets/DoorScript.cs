using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Character player;
    private Vector2 position;
    void Start()
    {
        player = GameObject.FindObjectOfType<Character>();
        position = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (player.CollisionDetection((RectTransform)this.transform))
        {
            Debug.Log("Collision detected");
        }
    }
}
