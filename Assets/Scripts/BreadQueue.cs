using System;
using System.Collections.Generic;
using UnityEngine;

namespace NOJUMPO
{
    public class BreadQueue : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        public static BreadQueue Instance = null;

        [SerializeField] protected Transform buyAreaTransform;
        
        Queue<CustomerStateMachine> _customerQueue = new Queue<CustomerStateMachine>();

        public event Action OnQueueUpdated;

        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            InitializeSingleton();
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
        public void GetInQueue(CustomerStateMachine customer) {
            _customerQueue.Enqueue(customer);
            OnQueueUpdated?.Invoke();
        }

        public void Dequeue() {
            _customerQueue.Dequeue();
            OnQueueUpdated?.Invoke();
        }

        public CustomerStateMachine GetLastCustomer() {
            return _customerQueue.Peek();
        }

        public Vector3 GetQueuePosition() {
            if (_customerQueue.Count == 0)
            {
                return buyAreaTransform.position;
            }

            Transform lastCustomerTransform = GetLastCustomer().transform;
            Vector3 offset = -lastCustomerTransform.forward * 1.25f;
            Vector3 destination = lastCustomerTransform.position + offset;
            return destination;
        }


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void InitializeSingleton() {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}