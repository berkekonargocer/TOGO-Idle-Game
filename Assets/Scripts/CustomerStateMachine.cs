using UnityEngine;

namespace NOJUMPO
{
    [DisallowMultipleComponent]
    public class CustomerStateMachine : Customer
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] CustomerState bootUpState;

        [Space]
        [SerializeField] string stateName = "";

        [SerializeField] float movementSpeed;

        
        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        protected override void Awake() {
            base.Awake();

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