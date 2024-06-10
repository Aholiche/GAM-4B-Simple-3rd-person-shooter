using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Target
{
    public enum Health
    {
        Full, 
        Medium,
        Empty
    }

    //Wanted to make player's health decrease when enemy collides with player
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Enemy"))
            return;
        health--;
    }
}
