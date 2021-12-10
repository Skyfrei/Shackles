using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItemsEquipped;

// Class that handles enemy position in exploration. 
// Enemy dialog, position, if the enemy has fought or not goes in this script.
public class Enemy : Units, IItemsEquipped 
{
    [SerializeField]
    private EnemyScriptableObject enemySO;
    [SerializeField]
    private SpriteRenderer artwork;
    public int id;
    private Character player;
    public override float MaxHealth { get; set; }
    public override float HP { get; set; }
    public override float Mana { get; set; }
    public override float Armor { get; set; }
    public byte level;
    public override float CritChance { get; set; }
    public override float ATK { get; set; }

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
        Mana = enemySO.mana;
        Armor = enemySO.armor;
        level = enemySO.level;
        CritChance = enemySO.critChance;
        ATK = enemySO.atk;
        MaxHealth = enemySO.maxhealth;
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
            player.pressF.enabled = true;
        }
        player.pressF.enabled = false;
    }

    public float TakeDamage(float damage)
    {
        float actualDamage = damage - (0.35f * this.Armor);
        if (actualDamage <= 0)
        {
            this.HP -= 30;
            return 30.0f;
        }
        else
        {
            this.HP -= damage - (0.35f * this.Armor);
            return damage - (0.35f * this.Armor);
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
        float damage = ATK;
        float actualDamage = 0.0f;

        if (criticalStruck = randomNumber <= CritChance ? true : false == true)
        {
            damage =  ATK + (ATK * 0.5f);
        }

        actualDamage = damage - (0.5f * player.Armor);
        if (criticalStruck == true)
        {
            Debug.Log($"Enemy critical struck for {damage} damage.");
        }
        else 
        {
            Debug.Log($"Enemy deals {damage} damage.");
        }
 
        if (actualDamage <= 0)
        {
            player.HP-= 10;
        }
        else
        {
            player.HP -= actualDamage;
        }
        
        return actualDamage;
    }
    private void Skill2()
    {
        foreach(Item item in equipped)
            {
                if (item.ItemType == ItemType.Helmet)
                {
                    foreach(EffectScriptableObject effect in item.itemEffects)
                    {
                        effect.NonBattleEffect(this);
                    }
                }
            }
            this.Mana -= 20;
    }
    private void Skill3()
    {
        foreach(Item item in equipped)
            {
                if (item.ItemType == ItemType.Armor)
                {
                    foreach(EffectScriptableObject effect in item.itemEffects)
                    {
                        effect.NonBattleEffect(this);
                    }
                }
            }
            this.Mana -= 20;
    }
    private void Skill4()
    {
        foreach(Item item in equipped)
            {
                if (item.ItemType == ItemType.Ring)
                {
                    foreach(EffectScriptableObject effect in item.itemEffects)
                    {
                        effect.NonBattleEffect(this);
                        effect.BattleEffect(player, this);
                    }
                }
            }
        this.Mana -= 40;
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
        
        foreach(Item item in equipped)
        {
            this.MaxHealth += item.health;
            this.ATK += item.attack;
            this.Armor += item.defense;
            this.CritChance += item.critChance;     
        }
    }
    
    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(2.0f);
        SceneChanger changer = new SceneChanger();
        changer.ChangeToBattleScene();
        
    }
}
