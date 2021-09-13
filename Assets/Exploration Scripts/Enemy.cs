using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class that handles enemy position in exploration. 
// Enemy dialog, position, if the enemy has fought or not goes in this script.
public class Enemy : MonoBehaviour
{
    [SerializeField]
    private EnemyScriptableObject enemySO;
    [SerializeField]
    private SpriteRenderer artwork;
    public int id;
    private Character player;
    public float maxHealth;
    public float currentHealth;
    public int armor;
    void Start() {
        player = GameObject.FindObjectOfType<Character>();

        artwork.sprite = enemySO.sprite;
        id = enemySO.id;
        armor = enemySO.armor;
        maxHealth = enemySO.maxhealth;
   }
   private void FixedUpdate() {
        Detect();
    }

    private void Detect()
    {
        if (this.transform.position.x - player.Position.x <= 2 && this.transform.position.x - player.Position.x >= -2 && (!(player.Position.y > this.transform.position.y + 1 ) && !(player.Position.y < this.transform.position.y - 1)))
        {
            if (!(player.enemiesFough.Contains(this.id)))
            {
                player.enemiesFough.Add(this.id);
                DontDestroyOnLoad(player.gameObject);
                DontDestroyOnLoad(this.gameObject);
                player.player_speed = 0f;
                StartCoroutine("Timer");

            }
        }
    }

    public void TakeDamage(int damage)
    {
        this.currentHealth -= damage - 0.25f * this.armor;
    }
    
    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(2.0f);
        SceneChanger changer = new SceneChanger();
        changer.ChangeToBattleScene();
        
    }
}
