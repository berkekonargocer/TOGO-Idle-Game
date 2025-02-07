using System;
using System.Collections.Generic;
using UnityEngine;

namespace NOJUMPO
{
    [Serializable]
    public class WaitingQueue
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] List<Vector3> _waitingPositions = new List<Vector3>();
        List<IQueueWaiter> _waitersList = new List<IQueueWaiter>();

        public event Action OnQueueUpdated;

        event Action<IQueueWaiter> WaiterOnMoveCompleted;

        public WaitingQueue() {
            WaiterOnMoveCompleted = WaiterOnMoveComplete;
        }

        public WaitingQueue(List<Vector3> waitingPositions) {
            _waitingPositions = waitingPositions;
            WaiterOnMoveCompleted = WaiterOnMoveComplete;
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void AddWaiter(IQueueWaiter waiter) {
            if (!CanAddWaiter())
                return;

            Vector3 waitPosition = _waitingPositions[_waitersList.Count];
            waiter.MoveTo(waitPosition, WaiterOnMoveCompleted);
            _waitersList.Add(waiter);
            OnQueueUpdated?.Invoke();
        }

        public void RemoveWaiter(IQueueWaiter waiter) {
            _waitersList.Remove(waiter);
            RelocateAllWaiters();
            OnQueueUpdated?.Invoke();
        }

        public IQueueWaiter GetWaiter(int index) {
            return _waitersList[index];
        }

        public IQueueWaiter GetFirstInQueue() {
            if (_waitersList.Count == 0)
                return null;

            return _waitersList[0];
        }

        public IQueueWaiter RemoveFirst() {
            if (_waitersList.Count == 0)
                return null;

            IQueueWaiter waiter = _waitersList[0];
            _waitersList.RemoveAt(0);
            RelocateAllWaiters();
            OnQueueUpdated?.Invoke();
            return waiter;
        }

        public int WaiterCount() {
            return _waitersList.Count;
        }

        public bool CanAddWaiter() {
            return _waitersList.Count < _waitingPositions.Count;
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void RelocateAllWaiters() {
            for (int i = 0; i < _waitersList.Count; i++)
            {
                _waitersList[i].MoveTo(_waitingPositions[i], WaiterOnMoveCompleted);
            }
        }

        void WaiterOnMoveComplete(IQueueWaiter waiter) {
            if (_waitersList.Count > 0 && waiter == _waitersList[0])
            {
                waiter.OnArrivedAtFrontOfQueue();
                return;
            }

            int waiterIndex = _waitersList.IndexOf(waiter);

            if (waiterIndex <= 0)
            {
                return;
            }

            waiter.LookAt(_waitingPositions[waiterIndex - 1]);
        }
    }
}