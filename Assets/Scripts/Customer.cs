using UnityEngine;
using UnityEngine.AI;

namespace NOJUMPO
{
    public class Customer : MonoBehaviour, IQueueWaiter
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] protected Transform idleAreaTransform;

        [SerializeField] protected bool isBuying;

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
            //if (isBuying && Vector3.Distance(transform.position, buyAreaTransform.position) > 0.3f)
            //{
            //    _customerAgent.SetDestination(buyAreaTransform.position);
            //}
            //else if (!isBuying && Vector3.Distance(transform.position, idleAreaTransform.position) > 0.3f)
            //{
            //    _customerAgent.SetDestination(idleAreaTransform.position);
            //}
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void SetDestination(Vector3 destination) {
            _customerAgent.SetDestination(destination);
        }

        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        protected virtual void SetComponents() {
            _customerAgent = GetComponent<NavMeshAgent>();
        }

        public void MoveTo(Vector3 destination) {
            _customerAgent.SetDestination(destination);
        }

        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
    }
}