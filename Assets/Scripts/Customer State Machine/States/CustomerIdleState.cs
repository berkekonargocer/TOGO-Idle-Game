using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

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
            StartCoroutine(ChangeToQueueState());
        }

        public override void Tick() {
        }

        public override void FixedTick() {
        }



        // ------------------------ CUSTOM PROTECTED METHODS -----------------------



        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        IEnumerator ChangeToQueueState() {
            int randomNumber = Random.Range(5, 15);

            yield return new WaitForSeconds(randomNumber);

            _stateMachine.ChangeState(_stateMachine.StateFactory.InQueue);
        }
    }
}