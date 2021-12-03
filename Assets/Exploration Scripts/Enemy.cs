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
    public float mana;
    public int armor;
    public byte level;
    public float critChance;
    public float ATK { get; set; }
    public List<ItemsScriptableObject> equippedSO;
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
        mana = enemySO.mana;
        armor = enemySO.armor;
        level = enemySO.level;
        critChance = enemySO.critChance;
        ATK = enemySO.atk;
        maxHealth = enemySO.maxhealth;
        equippedSO = enemySO.equipped;
        foreach (ItemsScriptableObject itemSo in equippedSO)
        {
            equipped.Add(new Item(itemSo));
        }
        
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

    public float TakeDamage(float damage)
    {
        float actualDamage = damage - (0.35f * this.armor);
        if (actualDamage <= 0)
        {
            this.currentHealth -= 30;
            return 30.0f;
        }
        else
        {
            this.currentHealth -= damage - (0.35f * this.armor);
            return damage - (0.35f * this.armor);
        }
    }

    public void Turn()
    {
        float randomNumber = Random.Range(0.0f, 1.0f);
        if (randomNumber <= 0.75)
        {
            BasicAttack(player);
        }
        else if (randomNumber > 0.75 && randomNumber <= 0.8)
        {
            Skill2();
        }
        else if (randomNumber > 0.8 && randomNumber <= 0.85)
        {
            Skill3();
        }
        else
        {
            Skill4();
        }


    }
    private float BasicAttack(Character player)
    {
        var randomNumber = Random.Range(0.0f, 1.0f);
        bool criticalStruck = false;
        float damage = 0.0f;
        float actualDamage = damage - (0.35f * player.Armor);

        if (criticalStruck = randomNumber <= critChance ? true : false == true)
        {
            damage =  ATK + (ATK * 0.5f);
        }
        else
        {
            damage = ATK;
        }        
        if (actualDamage <= 0)
        {
            player.HP-= 10;
        }
        else
        {
            player.HP -= damage - (0.35f * player.Armor);
        }

        return damage;
    }
    private void Skill2()
    {

    }
    private void Skill3()
    {

    }
    private void Skill4()
    {

    }

    //Item drops from enemies
    public Item DropItem()
    { 
        if (equipped.Count >= 1)
        {
            var randomNumber = Random.Range(0.0f, 1.0f);
            if (randomNumber > 0.95f)
            {
                foreach (Item item in this.equipped)
                {
                    if (item.ItemRarity == ItemRarity.Legendary)
                    {
                        return item;
                    }
                }
            }
            else if (randomNumber > 0.9f && randomNumber <= 0.95f)
            {
            foreach (Item item in this.equipped)
                {
                    if (item.ItemRarity == ItemRarity.Epic)
                    {
                        return item;
                    }
                }  
            }
            else if (randomNumber > 0.7f && randomNumber <= 0.9f)
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
        }
        
        return new Item(Resources.Load("Health Potion") as ItemsScriptableObject);
    }

    ///<summary>
    /// Changes player stats whenever player changes equipped gear. 
    ///</summary>
    public void ChangeStats()
    {

    }
    
    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(2.0f);
        SceneChanger changer = new SceneChanger();
        changer.ChangeToBattleScene();
        
    }
}
