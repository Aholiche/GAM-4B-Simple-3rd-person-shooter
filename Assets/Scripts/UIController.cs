using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Player;

namespace Controllers
{ 
    public class UIController : MonoBehaviour
    {
        #region Variables

        //[SerializeField] private PlayerHandler player;
        [SerializeField] private TMP_Text numberOfCoinsText;

        #endregion

        //Subscribing to the event 
        private void OnEnable()
        {
            EventManager.CoinCollected += EventManagerOnCoinCollected;
        }

        //Unsubscribing from the event
        private void OnDisable()
        {
            EventManager.CoinCollected -= EventManagerOnCoinCollected;
        }

        private void EventManagerOnCoinCollected()
        {
            numberOfCoinsText.text = $"Coins: {Player.GetNumberOfCoins()}";
        }
    }
}