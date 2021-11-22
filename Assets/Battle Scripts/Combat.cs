using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combat : MonoBehaviour
{
    // Start is called before the first frame update
    private HealthBar healthBar;
    private Enemy enemy;
    private Character player;
    
    //Variables
    private bool playerTurn = true;

    //Buttons
    public Button basicAttack;
    public Button secondButton;
    public Button thirdButton;
    public Button forthButton;

    void Start()
    {
        //Finding objects from previous scene except healthbar which is new
        enemy = GameObject.FindObjectOfType<Enemy>();
        player = GameObject.Find("Character").GetComponent<Character>();
        player.GetEquippedItems();
        healthBar = GameObject.Find("Health Bar").GetComponent<HealthBar>();
        
        //Button component
        basicAttack = GameObject.Find("Basic Attack").GetComponent<Button>();
        secondButton = GameObject.Find("Second Button").GetComponent<Button>();
        thirdButton = GameObject.Find("Third Button").GetComponent<Button>();
        forthButton = GameObject.Find("Forth Button").GetComponent<Button>();
        
        //Linking Health bar with enemy health and repositioning enemy so it looks better on screen
        enemy.currentHealth = enemy.maxHealth;
        enemy.transform.position = new Vector3(3.7f, 1.3f , 0);
        healthBar.SetMaxHealth(Mathf.RoundToInt(enemy.maxHealth));
    }

    private void FixedUpdate()
    {

        if (enemy.currentHealth <= 0)
        {
            SceneChanger sc = new SceneChanger();
            player.player_speed = 5.0f;
            Destroy(enemy.gameObject);
            DontDestroyOnLoad(player);
            sc.ChangeToNormalScreen();
        }
        else if (player.HP <= 0)
        {
            player.enemiesFough.Remove(enemy.id);
            player.player_speed = 5.0f;
            Destroy(enemy.gameObject);
            DontDestroyOnLoad(player);
            SceneChanger sc = new SceneChanger();
            sc.ChangeToNormalScreen();
        }
    }

    private void NextTurn()
    {
        playerTurn = !playerTurn;
    }
    
    private void BasicAttack()
    {
        bool meme1 = player.items[0].itemEffects[0] is IEffect;

        if (playerTurn == true)
        {   
            if (player.items[0].itemEffects[0] is IEffect effect)
            {
                effect.PastAttack();
            }
            enemy.TakeDamage(20);
            healthBar.SetHealth(Mathf.RoundToInt(enemy.currentHealth));
            NextTurn();
        }
    }

    
    
}
