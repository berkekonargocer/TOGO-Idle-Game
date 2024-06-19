using System;
using UnityEngine;

namespace NOJUMPO
{
    [Serializable]
    public class BankAccount
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] CountingFloat moneyAmount;


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void AddMoney(float addAmount) {
            moneyAmount.AddValue(addAmount);
        }
    }
}