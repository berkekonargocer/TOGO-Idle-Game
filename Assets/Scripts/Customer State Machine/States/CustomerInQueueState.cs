using UnityEngine;

namespace NOJUMPO
{
    public class CustomerInQueueState : CustomerState
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
            GetInQueue();
        }

        public override void Tick() {
            
        }

        public override void FixedTick() {
            throw new System.NotImplementedException();
        }


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void GetInQueue() {
            
        }

        void MoveInQueue() {
            
        }

    }
}