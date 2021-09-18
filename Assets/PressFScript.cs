using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressFScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Enemy enemies;
    void Start()
    {
        enemies = GameObject.FindObjectOfType<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (enemies.transform.position.x == )
    }
}
