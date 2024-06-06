using UnityEngine;

namespace NOJUMPO
{
    public class CustomerIdleState : CustomerState
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
        }



        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void GetInQueue() {
            _stateMachine.SetDestination(BreadQueue.Instance.GetQueuePosition());
            BreadQueue.Instance.GetInQueue(_stateMachine);
        }
    }
}