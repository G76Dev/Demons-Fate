using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerInterface : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Text killCountText;
    [SerializeField] Color flashColor;
    Color originalColor;
    int killCount;
    int enemiesToKill;
    MetaBehaviour metaBehaviour;
    void Start()
    {
        originalColor = killCountText.color;
        killCountText.text = "";
        if (SceneManager.GetActiveScene().name == "Nivel tutorial")
        {
            addEnemiesToKill(2);
            initKillCount(1);
        } else if (SceneManager.GetActiveScene().name == "Nivel Final")
        {
            addEnemiesToKill(2);
            initKillCount(1);
        }
    }

    public void flashKillCount()
    {

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
    public void initKillCount(float clearPercentage, MetaBehaviour meta)
    {
        metaBehaviour = meta;
        enemiesToKill = (int)(enemiesToKill * clearPercentage);
        killCountText.text = "Kill Count: " + killCount + "/" + enemiesToKill;
    }

    public void enemyKilled()
    {
        metaBehaviour = GameObject.FindGameObjectWithTag("meta").GetComponent<MetaBehaviour>();

        killCount++;
        if (metaBehaviour != null && killCount >= enemiesToKill)
        {
            metaBehaviour.enemysKilled = true;
        }
        killCountText.text = "Kill Count: " + killCount + "/" + enemiesToKill;
    }
}
