using UnityEngine;
using System;

namespace NOJUMPO
{
    public interface IQueueWaiter
    {
        public void MoveTo(Vector3 destination, Action onComplete, Action<IQueueWaiter> onCompleteWaiter);
        public void MoveTo(Vector3 destination, Action<IQueueWaiter> onCompleteWaiter);
        public void LookAt(Transform target);
        public void LookAt(Vector3 target, bool rotateVertical = false);
        public void OnArrivedAtFrontOfQueue();
    }
}