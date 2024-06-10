using UnityEngine;

namespace NOJUMPO
{
    public class CustomerShoppingState : CustomerState
    {
        // -------------------------------- FIELDS ---------------------------------


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
        public override void OnEnterState() {
            base.OnEnterState();
            Debug.Log("EKMEEMI VER");
        }

        public override void Tick() {
            //throw new System.NotImplementedException();
        }

        public override void FixedTick() {
            //throw new System.NotImplementedException();
        }

        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
    }
}