using TMPro;
using UnityEngine;

namespace NOJUMPO
{
    public class MoneyTextUI : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------

        [SerializeField] TextMeshProUGUI moneyText;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
        }

        void OnEnable() {
        }

        void OnDisable() {
        }

        void Start() {
        }

        void Update() {
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void UpdateText(int moneyAmount) {
            moneyText.SetText($"{moneyAmount}$");
        }

        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
    }
}