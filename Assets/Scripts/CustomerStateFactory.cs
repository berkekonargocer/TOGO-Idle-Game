using UnityEngine;

namespace NOJUMPO
{
    public class CustomerStateFactory : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] public CustomerState Idle { get; private set; }
        [SerializeField] public CustomerState InQueue { get; private set; }
        [SerializeField] public CustomerState WaitingProduct { get; private set; }
        [SerializeField] public CustomerState Buying { get; private set; }
        [SerializeField] public CustomerState Bought { get; private set; }



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


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
    }
}