using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Class that handles enemy position in exploration. 
// Enemy dialog, position, if the enemy has fought or not goes in this script.
public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    
    // public Enemy enemy;
    public bool fought = false;
    public Vector2 position;

    void Start()
    {
        position = GameObject.Find("Enemy").transform.position;
    }
    // Update is called once per frame
}
