using Cysharp.Threading.Tasks;
using System.Collections;
using TMPro;
using UnityEngine;

namespace NOJUMPO
{

    [RequireComponent(typeof(AudioSource))]
    public class CustomerShoppingState : CustomerState
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] GameObject chatBubbleCanvas;
        [SerializeField] TextMeshProUGUI chatBubbleText;

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
        void PurchaseBread(int amount) {
            for (int i = 0; i < amount; i++)
            {
                shoppingStand.BreadStack.RemoveItem();
                _audioSource.PlayOneShot(purchaseSFX);
                Bank.Instance.PlayerAccount.AddMoney(50);
            }
        }

        void LeaveFromQueue() {
            GameManager.Instance.BreadCustomerQueue.RemoveFirst();
            _stateMachine.ChangeState(_stateMachine.StateFactory.Shopped);
        }

        void ActivateChatBubble(bool activate = true) {
            chatBubbleCanvas.SetActive(activate);
        }

        void SetChatBubbleText(string text) {
            chatBubbleText.text = text;
        }

        string GetRandomGreetText(int breadAmount) {
            int textRandomizer = Random.Range(0, 5);

            string text = textRandomizer switch
            {
                0 => $"Hello, {breadAmount} bread please",
                1 => $"Morning, {breadAmount} bread please",
                2 => $"May i get {breadAmount} bread please",
                3 => $"I would like to buy {breadAmount} bread.",
                4 => $"Hey!, can i get {breadAmount} bread please",
                _ => $"{breadAmount} bread please",
            };

            return text;
        }

        string GetRandomLeaveText() {
            int textRandomizer = Random.Range(0, 8);

            string text = textRandomizer switch
            {
                0 => "Thank you!",
                1 => "Looks delicious!",
                2 => "This bakery is the best!",
                3 => "Thank you! Have a great day.",
                4 => "Thanks!",
                5 => "Take care!",
                6 => "Thank you! Bye!",
                7 => "Have a good day!",
                _ => "This place is so good!"
            };

            return text;
        }

        IEnumerator DeactivateChatBubbleAfterDelay(float delayAmount) {
            yield return new WaitForSeconds(delayAmount);

            ActivateChatBubble(false);
        }

        async UniTask ShopTask() {
            int randomAmount = Random.Range(1, 4);

            SetChatBubbleText(GetRandomGreetText(randomAmount));
            ActivateChatBubble();

            while (shoppingStand.BreadStack.IsStackEmpty)
            {
                await UniTask.Yield();
            }

            await UniTask.WaitForSeconds(2);

            while (shoppingStand.BreadStack.GetItemCount < randomAmount)
            {
                await UniTask.Yield();
            }

            PurchaseBread(randomAmount);

            SetChatBubbleText(GetRandomLeaveText());

            StartCoroutine(DeactivateChatBubbleAfterDelay(2.5f));

            LeaveFromQueue();
        }
    }
}