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
        enemy = GameObject.FindObjectOfType<Enemy>();
        player = GameObject.Find("Character").GetComponent<Character>();
        enemy.currentHealth = enemy.maxHealth;
        healthBar = GameObject.Find("Health Bar").GetComponent<HealthBar>();
        healthBar.SetMaxHealth(Mathf.RoundToInt(enemy.maxHealth));


        basicAttack = GameObject.Find("Basic Attack").GetComponent<Button>();
        secondButton = GameObject.Find("Second Button").GetComponent<Button>();
        thirdButton = GameObject.Find("Third Button").GetComponent<Button>();
        forthButton = GameObject.Find("Forth Button").GetComponent<Button>();
    }
    // Update is called once per frame

    private void FixedUpdate()
    {
        if (enemy.currentHealth <= 0)
        {
            SceneChanger sc = new SceneChanger();
            Destroy(enemy.gameObject);
            DontDestroyOnLoad(player);
            player.player_speed = 2.4f;
            sc.ChangeToNormalScreen();
        }
        if (player.HP <= 0)
        {
            player.enemiesFough.Remove(enemy.id);
            Destroy(enemy.gameObject);
            DontDestroyOnLoad(player);
            player.player_speed = 2.4f;
            SceneChanger sc = new SceneChanger();
            sc.ChangeToNormalScreen();
            
        }
    }

     private void NextTurn()
    {
        playerTurn = false;
    }
    
    private void BasicAttack()
    {
        enemy.TakeDamage(20);
        healthBar.SetHealth(Mathf.RoundToInt(enemy.currentHealth));
        NextTurn();
    }
    
}
