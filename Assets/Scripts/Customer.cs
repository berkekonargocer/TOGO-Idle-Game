using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

namespace NOJUMPO
{
    public class Customer : MonoBehaviour, IQueueWaiter
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] protected Transform idleAreaTransform;

        [SerializeField] protected Animator animator;

        protected NavMeshAgent _customerAgent;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        protected virtual void Awake() {
            SetComponents();
        }

        protected virtual void Update() {
            SetAnimationParameters();
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void SetAgentStopDistance(float distance) {
            _customerAgent.stoppingDistance = distance;
        }

#nullable enable
        public void MoveTo(Vector3 destination, Action? onComplete = null, Action<IQueueWaiter>? onCompleteWaiter = null) {
            MoveTask(destination, onComplete, onCompleteWaiter).Forget();
        }

        public void MoveTo(Vector3 destination, Action? onComplete = null) {
            MoveTask(destination, onComplete).Forget();
        }

        public void MoveTo(Vector3 destination, Action<IQueueWaiter>? onCompleteWaiter = null) {
            MoveTask(destination, onCompleteWaiter).Forget();
        }
#nullable disable

        public void LookAt(Transform target) {
            transform.LookAt(target);
        }

        public void LookAt(Vector3 target, bool rotateVertical = false) {
            Vector3 direction = target - transform.position;

            if (direction != Vector3.zero)
            {
                Quaternion rotation = Quaternion.LookRotation(direction);
                Vector3 newRotation = rotateVertical ? rotation.eulerAngles : new Vector3(transform.rotation.x, rotation.eulerAngles.y, transform.rotation.z);
                transform.DORotate(newRotation, 0.75f);
            }
        }

        public virtual void OnArrivedAtFrontOfQueue() {

        }


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        protected virtual void SetComponents() {
            _customerAgent = GetComponent<NavMeshAgent>();
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void SetAnimationParameters() {
            animator.SetFloat("MoveX", _customerAgent.velocity.x);
            animator.SetFloat("MoveZ", _customerAgent.velocity.z);
        }

        async UniTaskVoid MoveTask(Vector3 destination, Action onComplete = null, Action<IQueueWaiter> onCompleteWaiter = null) {
            _customerAgent.SetDestination(destination);

            await UniTask.WaitUntil(() => Vector3.Distance(transform.position, destination) < _customerAgent.stoppingDistance + 0.25f);

            onComplete?.Invoke();
            onCompleteWaiter?.Invoke(this);
        }

        async UniTaskVoid MoveTask(Vector3 destination, Action<IQueueWaiter> onCompleteWaiter = null) {

            CancellationToken cancellationToken = this.GetCancellationTokenOnDestroy();

            try
            {
                _customerAgent.SetDestination(destination);

                await UniTask.WaitUntil(() => Vector3.Distance(transform.position, destination) < _customerAgent.stoppingDistance + 0.15f,
                    cancellationToken: cancellationToken);

                onCompleteWaiter.Invoke(this);
            }
            catch (OperationCanceledException)
            {

            }
        }

    }
}