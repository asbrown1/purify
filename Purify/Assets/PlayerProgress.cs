﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerProgress : MonoBehaviour {
    string currentLevel;
    int experience;
    int expLevel;
    public int[] levelExpNeeded;
    public int[] attackGainLevel;
    public int[] manaGainLevel;
    public int[] healthGainLevel;
    int numberOfLevels;
	// Use this for initialization
	void Start () {
        currentLevel = SceneManager.GetActiveScene().name;
        expLevel = 0;
        numberOfLevels = levelExpNeeded.Length;
        PlayerPrefs.SetString("LastLevel", currentLevel);
        if(PlayerPrefs.HasKey("PlayerExperience"))
        {
            experience = PlayerPrefs.GetInt("PlayerExperience");
            checkExpLevel();
        }
        else
        {
            PlayerPrefs.SetInt("PlayerExpereince", 0);
            experience = 0;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public int getExperience()
    {
        return experience;
    }

    public int getExpLevel()
    {
        return expLevel;
    }
    public int getExpNextLevel()
    {
        if (expLevel == numberOfLevels)
        {
            return experience;
        }
        else
        {
            return levelExpNeeded[expLevel + 1];
        }
    }
    public void gainExperience(int amount)
    {
        experience = experience + amount;
        checkExpLevel();
    }

    void checkExpLevel()
    {
        int oldExpLevel = expLevel;
        for(int i=0;i<numberOfLevels;i++)
        {
            if(experience>=levelExpNeeded[i])
            {
                expLevel = i;
            }
        }
        if(expLevel>oldExpLevel)
        {
            PlayerAttack attack = GetComponent<PlayerAttack>();
            Mana mana = GetComponent<Mana>();
            Health health = GetComponent<Health>();
            attack.addStrength(attackGainLevel[expLevel]);
            mana.addMana(manaGainLevel[expLevel]);
            health.addHealth(healthGainLevel[expLevel]);
        }
    }
}