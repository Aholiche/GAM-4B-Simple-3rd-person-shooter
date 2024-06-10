using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCounter : Target
{
    //Tried to make an "objective" for the player. Tried to inherit from the Targte.cs script to track the amount of enemies currently on the map.
    //Would it be better to make Target inherit EnemyCounter so that if a GameObject is destroyed, the counter would be decreased by - 1? 
    GameObject[] target;
    public Text enemyCountText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCountText.text = "Enemies: " + target.Length.ToString();
    }
}
