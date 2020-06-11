using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class Infector_Health : MonoBehaviour
{

    public RectTransform healthBar;
    public const int maxHealth = 100; //最大血量
    public int currentHealth = maxHealth;  //目前角色血量*/
    public void LoseBlood(int amount)
    {
        //扣血機制
        currentHealth -= amount;
        if (currentHealth <= 0){
            currentHealth = 0;
            //Debug.Log("Dead!");
        }

    }
	
	
	
}
