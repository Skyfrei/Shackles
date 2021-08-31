using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyDetection : MonoBehaviour
{
    // Start is called before the first frame update
    private Enemy enemy;
    private Character player;
    
    void Start()
    {
        enemy = GameObject.Find("Enemy").GetComponent<Enemy>();
        player = GameObject.Find("Character").GetComponent<Character>();
    }

    // Update is called once per frame
    private void FixedUpdate() {
        
        if (enemy.position.x - player.Position.x <= 1 && enemy.fought == false && (!(player.Position.y > enemy.position.y + 1)  && !(player.Position.y < enemy.position.y - 1)))
        {

            if (enemy.fought == false)
            {
                player.player_speed = 0f;

                StartCoroutine("Timer");
            }
            Debug.Log("suh");
        }
    }

    // private void OnEnable() {
    //     enemy.fought = PlayerPrefs.GetInt("fought") == 1 ? true : false;
    // }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(2.0f);
        player.player_speed = 2.4f;
        SceneChanger changer = new SceneChanger();
        changer.ChangeToBattleScene();
        
    }
}
