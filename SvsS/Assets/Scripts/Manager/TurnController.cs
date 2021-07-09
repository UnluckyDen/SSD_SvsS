using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Players;

public class TurnController : MonoBehaviour
{
    public Animator turnManager;
    public Player player;
    public void Start()
    {
        turnManager.SetTrigger("PlayerFirst");      
    }

    public void Update()
    {
        //player does not contain playerHealthSystem attribute
        /*if (player.playerHealthSystem.GetHp() == 0)
        {
            turnManager.SetTrigger("PlayerToEnd");
        }*/
    }
}
