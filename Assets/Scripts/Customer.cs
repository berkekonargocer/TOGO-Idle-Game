using UnityEngine;
using UnityEngine.AI;

namespace NOJUMPO
{
    public class Customer : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] protected Transform buyAreaTransform;
        [SerializeField] protected Transform idleAreaTransform;

        [SerializeField] protected bool isBuying;

        protected NavMeshAgent _customerAgent;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        protected virtual void Awake() {
            _customerAgent = GetComponent<NavMeshAgent>();
        }

        void OnEnable() {
        }

        void OnDisable() {
        }

        void Start() {
            //_customerAgent.SetDestination(buyAreaTransform.position);
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


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
    }
}