using System.Collections.Generic;
using UnityEngine;

namespace NOJUMPO
{
    public class WaitingQueue : MonoBehaviour {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] List<Vector3> _waitingPositions = new List<Vector3>();
        List<IQueueWaiter> _waitersList = new List<IQueueWaiter>();


        [SerializeField] Customer[] waiters;

        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {

        }

        void OnEnable() {
        }

        void OnDisable() {
        }

        void Start() {
            for (int i = 0; i < waiters.Length; i++)
            {
                AddWaiter(waiters[i]);
            }
        }

        void Update() {
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void AddWaiter(IQueueWaiter waiter) {
            if (!CanAddWaiter())
                return;

            _waitersList.Add(waiter);
            Vector3 waitPosition = _waitingPositions[_waitersList.Count - 1];
            waiter.MoveTo(waitPosition);
        }

        public void RemoveWaiter(IQueueWaiter waiter) {
            _waitersList.Remove(waiter);
        }

        public IQueueWaiter GetWaiter(int index) {
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