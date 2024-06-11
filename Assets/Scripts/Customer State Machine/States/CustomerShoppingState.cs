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

        void OnEnable() {
        }

        void OnDisable() {
        }

        void Start() {
        }

        void Update() {
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public override async void OnEnterState() {
            base.OnEnterState();
            await ShopTask();
        }

        public override void Tick() {
            //throw new System.NotImplementedException();
        }

        public override void FixedTick() {
            //throw new System.NotImplementedException();
        }

        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        async UniTask ShopTask() {
            while (shoppingStand.BreadStack.IsStackEmpty)
            {
                await UniTask.Yield();
            }

            shoppingStand.BreadStack.RemoveItem();
            //_stateMachine.ChangeState()
        }
    }
}