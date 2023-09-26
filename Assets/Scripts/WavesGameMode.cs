using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WavesGameMode : MonoBehaviour
{
    [SerializeField] private Life playerLife;
    //[SerializeField] private Life playerBaseLife;
    

    void Awake()
    {
        playerLife.onDeath.AddListener(OnPlayerOrBaseDied);
        //playerBaseLife.onDeath.AddListener(OnPlayerOrBaseDied);
       
    }
    

    void OnPlayerOrBaseDied() {
        SceneManager.LoadScene("LoseScreen");
    }
    // Start is called before the first frame update
    void Start()
    {
        playerLife.onDeath.AddListener(OnPlayerOrBaseDied);
        //playerBaseLife.onDeath.AddListener(OnPlayerOrBaseDied);
        
        EnemiesManager.instance.onChanged.AddListener(CheckWinCondition);
        WavesManager.instance.onChanged.AddListener(CheckWinCondition);
        
        //ScoreManager.instance.onChanged.AddListener(CheckWinCondition);
    }

    // Update is called once per frame
    void CheckWinCondition()
    {
        /*if (EnemiesManager.instance.enemies.Count <= 0 || WavesManager.instance.waves.Count<=0)
        {
            SceneManager.LoadScene("WinScreen");
        }*/

       /* if (ScoreManager.instance.amount > 3)
        {
            SceneManager.LoadScene("WinScreen");
        }*/

    }
    
}
