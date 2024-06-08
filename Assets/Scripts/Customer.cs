using Cysharp.Threading.Tasks;
using DG.Tweening;
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

        void OnEnable() {
        }

        void OnDisable() {
        }

        void Start() {

        }

        void Update() {

        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void MoveTo(Vector3 destination, Vector3? lookAt = null) {
            MoveTask(destination, lookAt).Forget();
        }

        public void LookAt(Transform target) {
            transform.LookAt(target);
        }

        public void LookAt(Vector3 target, bool rotateVertical = false) {
            Vector3 direction = target - transform.position;
            if (direction != Vector3.zero)
            {
                Quaternion rotation = Quaternion.LookRotation(direction);
                Vector3 newRotation = new Vector3(transform.rotation.x, rotation.eulerAngles.y, transform.rotation.z);
                transform.DORotate(newRotation, 0.75f);
            }
        }


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        protected virtual void SetComponents() {
            _customerAgent = GetComponent<NavMeshAgent>();
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        async UniTaskVoid MoveTask(Vector3 destination, Vector3? lookAt = null) {
            _customerAgent.SetDestination(destination);
            //animator.SetBool("IsWalking", true);

            await UniTask.WaitUntil(() => Vector3.Distance(transform.position, destination) < 1.4f);

            if (lookAt.HasValue)
            {
                LookAt(lookAt.Value);
            }

            Debug.Log("In Queue");
            //animator.SetBool("IsWalking", false);
        }

    }
}