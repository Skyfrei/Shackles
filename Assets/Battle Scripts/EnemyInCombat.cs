using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInCombat : MonoBehaviour
{
    // Start is called before the first frame update
    private float maxHealth = 100;
    public float currentHealth;
    public int armor;
    public HealthBar healthBar;
    public EnemyInCombat enemy;
    public bool fought = false;

    void Start()
    {
        enemy = GetComponent<EnemyInCombat>();
        enemy.currentHealth = maxHealth;
        healthBar = GameObject.Find("Health Bar").GetComponent<HealthBar>();
        healthBar.SetMaxHealth(Mathf.RoundToInt(enemy.maxHealth));
    }
    // Update is called once per frame
    
    void Update()
    {
       if (enemy.currentHealth <= 0)
       {
           enemy.fought = true;
       }
    }
    public void TakeDamage(int damage)
    {
        enemy.currentHealth -= damage - 0.25f * enemy.armor;
        
        healthBar.SetHealth(Mathf.RoundToInt(enemy.currentHealth));
    }
    
    public float DealDamage()
    {
        return 50.0f;
    }
}
