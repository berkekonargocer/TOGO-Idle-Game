using UnityEngine;

namespace NOJUMPO
{
    public class CustomerInQueueState : CustomerState
    {
        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public override void OnEnterState() {
            base.OnEnterState();
            GetInQueue();
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void GetInQueue() {
            _stateMachine.SetAgentStopDistance(0.05f);
            GameManager.Instance.BreadCustomerQueue.AddWaiter(_stateMachine);
        }
    }
}