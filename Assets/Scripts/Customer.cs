using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace NOJUMPO
{
    public class Customer : MonoBehaviour, IQueueWaiter
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] protected Transform idleAreaTransform;

        [SerializeField] Animator animator;

        protected NavMeshAgent _customerAgent;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        protected virtual void Awake() {
            SetComponents();
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
        public void MoveTo(Vector3 destination) {
            MoveTask(destination).Forget();
        }


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        protected virtual void SetComponents() {
            _customerAgent = GetComponent<NavMeshAgent>();
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        async UniTaskVoid MoveTask(Vector3 destination) {
            _customerAgent.SetDestination(destination);
            animator.SetBool("IsWalking", true);

            await UniTask.WaitUntil(() => Vector3.Distance(transform.position, destination) < 0.2f);

            animator.SetBool("IsWalking", false);
        }

    }
}