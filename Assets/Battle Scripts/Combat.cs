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
    
    // Variables
    private bool playerTurn = true;

    //UI
    public Button basicAttack;
    public Button secondButton;
    public Button thirdButton;
    public Button forthButton;
    public Button itemButton;
    public Button runButton;
    public Text healthText;
    public Text manaText;

    // Temporary variables that hold the players position before battle
 

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
        itemButton = GameObject.Find("Items").GetComponent<Button>();
        runButton = GameObject.Find("Run").GetComponent<Button>();
        healthText = GameObject.Find("Hp").GetComponent<Text>();
        manaText = GameObject.Find("Mana").GetComponent<Text>();
        
        //Linking Health bar with enemy health and repositioning enemy so it looks better on screen
        enemy.currentHealth = enemy.maxHealth;
        healthBar.SetMaxHealth(Mathf.RoundToInt(enemy.maxHealth));

    }

    private void FixedUpdate()
    {
        healthText.text = "Health: " + $"{player.HP}";
        manaText.text = "Mana: " + $"{player.Mana}";
        if (enemy.currentHealth <= 0)
        {
            Item droppedItem = enemy.DropItem();
            player.inventory.Add(droppedItem);
            Debug.Log($"You have received {droppedItem.itemName} by defeating {enemy.name}");
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
        playerTurn = playerTurn;
    }
    
    public void BasicAttack()
    {
        // bool meme1 = player.items[0].itemEffects[0] is IBattleEffect;

        if (playerTurn == true)
        {   
            // player.equipped[0].itemEffects[0].BattleEffect();
            float damage = player.BasicAttack();
            enemy.TakeDamage(damage);
            healthBar.SetHealth(Mathf.RoundToInt(enemy.currentHealth));
            NextTurn();
        }
    }

    public void Skill1()
    {

    }
    public void Skill2()
    {

    }
    public void Skill3()
    {

    }
    ///<summary>
    /// <para>Secondary Button.</para>
    /// <para>Opens Item menu when clicked.</para>
    ///</summary>
    public void Items()
    {

    }
    ///<summary>
    /// <para>Secondary Button.</para>
    /// <para>Player tries to run when clicked.</para>
    ///</summary>
    public void Run()
    {

    }
    
}
