using UnityEngine;
using UnityEngine.Events;

namespace NOJUMPO
{
    public abstract class CustomerState : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        protected CustomerStateMachine _stateMachine;

        public UnityEvent OnEnter, OnExit;


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public virtual void Initialize(CustomerStateMachine stateMachine) {
            _stateMachine = stateMachine;
        }

        public virtual void OnEnterState() {
            OnEnter?.Invoke();
        }

        public abstract void Tick();
        public abstract void FixedTick();

        public virtual void OnExitState() {
            OnExit?.Invoke();
        }

        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
    }
}