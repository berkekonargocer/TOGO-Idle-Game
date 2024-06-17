using Cysharp.Threading.Tasks;
using UnityEngine;

namespace NOJUMPO
{

    [RequireComponent(typeof(AudioSource))]
    public class CustomerShoppingState : CustomerState
    {
        // -------------------------------- FIELDS ---------------------------------
        Stand shoppingStand;

        [SerializeField] AudioClip purchaseSFX;
        AudioSource _audioSource;

        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            shoppingStand = GameObject.FindWithTag("Stand").GetComponent<Stand>();
            _audioSource = GetComponent<AudioSource>();
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
            _audioSource.PlayOneShot(purchaseSFX);
            _stateMachine.ChangeState(_stateMachine.StateFactory.Shopped);
        }
    }
}