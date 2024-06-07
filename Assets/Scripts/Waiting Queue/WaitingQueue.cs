using System.Collections.Generic;
using UnityEngine;

namespace NOJUMPO
{
    public class WaitingQueue : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] List<Vector3> _waitingPositions = new List<Vector3>();
        List<QueueWaiter> _waitersList = new List<QueueWaiter>();


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
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
        public void AddWaiter(QueueWaiter waiter) {
            if (CanAddWaiter())
                return;

            _waitersList.Add(waiter);
            Vector3 queuePosition = _waitingPositions[_waitersList.Count - 1];
            waiter.MoveTo(queuePosition);
        }

        public void RemoveWaiter(QueueWaiter waiter) {
            _waitersList.Remove(waiter);
        }

        public QueueWaiter GetWaiter(int index) {
            return _waitersList[index];
        }

        public int WaiterCount() {
            return _waitersList.Count;
        }

        public bool CanAddWaiter() {
            return _waitersList.Count < _waitingPositions.Count;
        }

        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
    }
}