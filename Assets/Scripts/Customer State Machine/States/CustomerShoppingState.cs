using Cysharp.Threading.Tasks;
using UnityEngine;

namespace NOJUMPO
{
    public class CustomerShoppingState : CustomerState
    {
        // -------------------------------- FIELDS ---------------------------------
        Stand shoppingStand;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            shoppingStand = GameObject.FindWithTag("Stand").GetComponent<Stand>();
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public override async void OnEnterState() {
            base.OnEnterState();
            await ShopTask();
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        async UniTask ShopTask() {
            while (shoppingStand.BreadStack.IsStackEmpty)
            {
                await UniTask.Yield();
            }

            shoppingStand.BreadStack.RemoveItem();
            GameManager.Instance.BreadCustomerQueue.RemoveFirst();
            _stateMachine.ChangeState(_stateMachine.StateFactory.Shopped);
        }
    }
}