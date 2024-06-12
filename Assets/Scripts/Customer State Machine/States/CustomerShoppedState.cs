using System;
using UnityEngine;

namespace NOJUMPO
{
    public class CustomerShoppedState : CustomerState
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] Transform idlePlace;


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public override void OnEnterState() {
            base.OnEnterState();
            _stateMachine.SetAgentStopDistance(1.5f);
            _stateMachine.MoveTo(idlePlace.transform.position, ArrivedToIdlePlace);
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void ArrivedToIdlePlace() {
            _stateMachine.ChangeState(_stateMachine.StateFactory.Idle);
        }
    }
}