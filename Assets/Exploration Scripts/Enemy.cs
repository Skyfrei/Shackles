using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItemsEquipped;

// Class that handles enemy position in exploration. 
// Enemy dialog, position, if the enemy has fought or not goes in this script.
public class Enemy : MonoBehaviour, IItemsEquipped 
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
    public List<Item> equipped;

    //Items equipped
    public int HelmetId { get; set; }
    public int WeaponId { get; set; }
    public int RingId { get; set; }
    public int ArmorId { get; set; }

    void Start() 
    {
        player = GameObject.FindObjectOfType<Character>();
        artwork.sprite = enemySO.sprite;
        id = enemySO.id;
        armor = enemySO.armor;
        maxHealth = enemySO.maxhealth;
        equipped = enemySO.equipped;
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

    public void TakeDamage(float damage)
    {
        this.currentHealth -= damage - (0.25f * this.armor);
    }

    //Item drops from enemies

    public Item DropItem()
    { 
        var randomNumber = Random.Range(0.0f, 1.0f);
        if (randomNumber > 0.99f)
        {
            foreach (Item item in this.equipped)
            {
                if (item.ItemRarity == ItemRarity.Legendary)
                {
                    return item;
                }
            }
        }
        else if (randomNumber > 0.9f && randomNumber <= 0.99f)
        {
          foreach (Item item in this.equipped)
            {
                if (item.ItemRarity == ItemRarity.Epic)
                {
                    return item;
                }
            }  
        }
        else if (randomNumber > 0.7f & randomNumber <= 0.9f)
        {
            foreach (Item item in this.equipped)
            {
                if (item.ItemRarity == ItemRarity.Rare)
                {
                    return item;
                }
            }
        }
        else if (randomNumber > 0.5f && randomNumber <= 0.7f)
        {
           foreach (Item item in this.equipped)
            {
                if (item.ItemRarity == ItemRarity.Common)
                {
                    return item;
                }
            } 
        }
        return new Item();
    }
    
    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(2.0f);
        SceneChanger changer = new SceneChanger();
        changer.ChangeToBattleScene();
        
    }
}
