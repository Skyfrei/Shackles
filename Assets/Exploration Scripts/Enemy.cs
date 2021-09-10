using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class that handles enemy position in exploration. 
// Enemy dialog, position, if the enemy has fought or not goes in this script.
public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Vector2 position;
    public EnemyScriptableObject enemySO;
    public SpriteRenderer artwork;
    public bool fought;

    void Start() {
        artwork.sprite = enemySO.sprite;
        fought = enemySO.fought;
        position = enemySO.position;
   }
    // Update is called once per frame
}
