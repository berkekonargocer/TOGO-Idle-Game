using UnityEngine;

namespace NOJUMPO
{
    public class CustomerStateFactory : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [field: SerializeField] public CustomerState Idle { get; private set; }
        [field: SerializeField] public CustomerState InQueue { get; private set; }
        [field: SerializeField] public CustomerState WaitingProduct { get; private set; }
        [field: SerializeField] public CustomerState Buying { get; private set; }
        [field: SerializeField] public CustomerState Bought { get; private set; }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void InitializeStates(CustomerStateMachine stateMachine) {
            CustomerState[] customerStates = GetComponents<CustomerState>();

            for (int i = customerStates.Length - 1; i >= 0; i--)
            {
                customerStates[i].Initialize(stateMachine);
            }
        }
    }
}