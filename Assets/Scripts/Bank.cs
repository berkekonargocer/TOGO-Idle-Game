using UnityEngine;

namespace NOJUMPO
{
    public class Bank : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        public static Bank Instance;

        [field: SerializeField] public BankAccount PlayerAccount { get; private set; }


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            InitializeSingleton();
        }


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