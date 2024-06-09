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

        public CustomerStateFactory StateFactory { get; private set; }

        CustomerState _currentState;
        CustomerState _previousState;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        protected override void Awake() {
            SetComponents();
            InitializeStates();
        }

        void Start() {
            BootUpStateMachine();
        }

        void Update() {
            _currentState.Tick();
        }

        void FixedUpdate() {
            _currentState.FixedTick();
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void ChangeState(CustomerState newState) {
            _currentState.OnExitState();

            _previousState = _currentState;
            _currentState = newState;
            _currentState.OnEnterState();

            DisplayState();
        }

        public void TransitionToPreviousState() {
            ChangeState(_previousState);
        }

        public override void OnArrivedAtFrontOfQueue() {
            //ChangeState(StateFactory.)
            Debug.Log("EKMEEMI VER");
        }

        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        protected override void SetComponents() {
            base.SetComponents();
            StateFactory = GetComponentInChildren<CustomerStateFactory>();
        }

        protected virtual void InitializeStates() {
            StateFactory.InitializeStates(this);
        }

        protected void DisplayState() {
            stateName = _currentState.GetType().ToString();
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void BootUpStateMachine() {
            _currentState = bootUpState;
            _currentState.OnEnterState();
        }
    }
}