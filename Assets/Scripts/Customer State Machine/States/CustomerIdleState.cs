using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace NOJUMPO
{
    public class CustomerIdleState : CustomerState
    {
        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public override void OnEnterState() {
            base.OnEnterState();
            StartCoroutine(ChangeToQueueState());
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        IEnumerator ChangeToQueueState() {
            int randomNumber = Random.Range(5, 15);

            yield return new WaitForSeconds(randomNumber);

            _stateMachine.ChangeState(_stateMachine.StateFactory.InQueue);
        }
    }
}