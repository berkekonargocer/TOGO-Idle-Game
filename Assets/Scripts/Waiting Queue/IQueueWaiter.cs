using UnityEngine;

namespace NOJUMPO
{
    public interface IQueueWaiter
    {
        public Transform transform { get; }
        public void MoveTo(Vector3 destination, Vector3? lookAt = null);
        public void LookAt(Transform target);
    }
}