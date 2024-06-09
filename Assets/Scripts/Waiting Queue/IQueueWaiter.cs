using UnityEngine;
using System;

namespace NOJUMPO
{
    public interface IQueueWaiter
    {
        //public Transform transform { get; }
        public void MoveTo(Vector3 destination, Action<IQueueWaiter> onComplete);
        public void LookAt(Transform target);
        public void LookAt(Vector3 target, bool rotateVertical = false);
        public void OnArrivedAtFrontOfQueue();
    }
}