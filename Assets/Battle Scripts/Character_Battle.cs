using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character_Battle : MonoBehaviour
{
    // Start is called before the first frame update

    public Button basicAttack;
    public Button secondButton;
    public Button thirdButton;
    public Button forthButton;
    private Character player;
    private bool playerTurn = true;
    private EnemyInCombat enemy;
    void Start()
    {
        enemy = GameObject.Find("Enemy").GetComponent<EnemyInCombat>();
        player = GameObject.Find("Character").GetComponent<Character>();

        basicAttack = GameObject.Find("Basic Attack").GetComponent<Button>();
        secondButton = GameObject.Find("Second Button").GetComponent<Button>();
        thirdButton = GameObject.Find("Third Button").GetComponent<Button>();
        forthButton = GameObject.Find("Forth Button").GetComponent<Button>();
    }

    // Update is called once per frame
    
    void Update()
    {
        if (enemy.currentHealth <= 0)
        {
            SceneChanger sc = new SceneChanger();
            sc.ChangeToNormalScreen();
        }    
        if (player.HP <= 0)
        {
            SceneChanger sc = new SceneChanger();
            sc.ChangeToNormalScreen();
        }

        if (playerTurn == false) 
        {
            player.HP -= enemy.DealDamage() - 0.35f * player.Armor;
            Debug.Log(player.HP);
            playerTurn = true;
        }
    }
    private void OnDisable() {
        PlayerPrefs.SetInt("fought", 1);
    }

    private void NextTurn()
    {
        playerTurn = false;
    }
    
    public void BasicAttack()
    {
        enemy.TakeDamage(20);
        NextTurn();
    }
    public void Skill2()
    {
        
    }
    public void Skill3()
    {
        
    }
    public void Skill4()
    {
        
    }
}
