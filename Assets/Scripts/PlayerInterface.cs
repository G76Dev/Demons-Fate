using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInterface : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Text killCountText;
    int killCount;
    int enemiesToKill;
    void Start()
    {
        killCountText.text = "";
    }

    public void addEnemiesToKill(int n)
    {
        enemiesToKill += n;
        //killCountText.text = "Kill Count: " + killCount + "/" + enemiesToKill;
    }

    public void initKillCount(float clearPercentage)
    {
        enemiesToKill = (int)(enemiesToKill * clearPercentage);
        killCountText.text = "Kill Count: " + killCount + "/" + enemiesToKill;
    }

    public void enemyKilled()
    {
        killCount++;
        killCountText.text = "Kill Count: " + killCount + "/" + enemiesToKill;
    }
}
