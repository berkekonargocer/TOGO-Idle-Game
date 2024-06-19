using System;
using UnityEngine;

namespace NOJUMPO
{
    public class GameManager : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        public static GameManager Instance;
        public WaitingQueue BreadCustomerQueue = new WaitingQueue();

        [SerializeField] CountingFloat moneyAmount;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            InitializeSingleton();
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
        public void AddMoney(float addAmount) {
            moneyAmount.AddValue(addAmount);
        }
        

        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void InitializeSingleton() {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}