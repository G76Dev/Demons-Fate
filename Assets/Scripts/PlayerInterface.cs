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
    MetaBehaviour metaBehaviour;
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
        metaBehaviour = GameObject.Find("Meta").GetComponent<MetaBehaviour>();
        enemiesToKill = (int)(enemiesToKill * clearPercentage);
        killCountText.text = "Kill Count: " + killCount + "/" + enemiesToKill;
    }
    public void initKillCount(float clearPercentage, MetaBehaviour meta)
    {
        metaBehaviour = meta;
        enemiesToKill = (int)(enemiesToKill * clearPercentage);
        killCountText.text = "Kill Count: " + killCount + "/" + enemiesToKill;
    }

    public void enemyKilled()
    {
        killCount++;
        if (metaBehaviour != null && killCount >= enemiesToKill)
        {
            metaBehaviour.enemysKilled = true;
        }
        killCountText.text = "Kill Count: " + killCount + "/" + enemiesToKill;
    }
}
