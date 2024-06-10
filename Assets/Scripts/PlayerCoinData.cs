using Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class PlayerCoinData : MonoBehaviour
    {
        #region Variables

        [SerializeField] private UIController uiController;
        private int coins = 0;

        #endregion

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Coin"))
                return;
            coins++;

            //Compile error: numberOfCoins is inaccessable due to its protection level. Don't know how to go around this
            uiController.numberOfCoinsText.text = $"Coins: {coins}";
        }
    }
}
