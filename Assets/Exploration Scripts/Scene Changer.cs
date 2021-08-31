using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger
{
    public void ChangeToBattleScene()
    {
        SceneManager.LoadScene("Battle Scene");
    }
    public void ChangeToNormalScreen()
    {
        SceneManager.LoadScene("First Level");
    }
}
