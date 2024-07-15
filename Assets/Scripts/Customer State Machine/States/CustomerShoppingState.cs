using Cysharp.Threading.Tasks;
using UnityEngine;

namespace NOJUMPO
{

    [RequireComponent(typeof(AudioSource))]
    public class CustomerShoppingState : CustomerState
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] AudioClip purchaseSFX;

        AudioSource _audioSource;
        Stand shoppingStand;


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
            int randomAmount = Random.Range(1, 4);

            while (shoppingStand.BreadStack.IsStackEmpty)
            {
                await UniTask.Yield();
            }

            await UniTask.WaitForSeconds(2);


            while (shoppingStand.BreadStack.GetItemCount < randomAmount)
            {
                await UniTask.Yield();
            }

            for (int i = 0; i < randomAmount; i++)
            {
                shoppingStand.BreadStack.RemoveItem();
                _audioSource.PlayOneShot(purchaseSFX);
                Bank.Instance.PlayerAccount.AddMoney(50);
            }

            GameManager.Instance.BreadCustomerQueue.RemoveFirst();
            _stateMachine.ChangeState(_stateMachine.StateFactory.Shopped);
        }
    }
}