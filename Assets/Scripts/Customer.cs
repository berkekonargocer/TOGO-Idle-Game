using UnityEngine;
using UnityEngine.AI;

namespace NOJUMPO
{
    public class Customer : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] Transform buyAreaTransform;
        [SerializeField] Transform idleAreaTransform;

        [SerializeField] bool isBuying;

        NavMeshAgent _customerAgent;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            _customerAgent = GetComponent<NavMeshAgent>();
        }

        void OnEnable() {
        }

        void OnDisable() {
        }

        void Start() {
        }

        void Update() {
            if (isBuying && Vector3.Distance(transform.position, buyAreaTransform.position) > 0.3f)
            {
                _customerAgent.SetDestination(buyAreaTransform.position);
            }
            else if (!isBuying && Vector3.Distance(transform.position, idleAreaTransform.position) > 0.3f)
            {
                _customerAgent.SetDestination(idleAreaTransform.position);
            }
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
    }
}