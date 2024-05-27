using System.Collections.Generic;
using UnityEngine;

namespace NOJUMPO
{
    public class Inventory : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] Transform itemStackPoint;
        [SerializeField] float itemStackOffset = 0.1f;

        Stack<GameObject> _doughs = new Stack<GameObject>();
        public int GetDoughCount { get { return _doughs.Count; } }
        public int MaxDoughCount { get; private set; } = 5;
        public bool IsDoughFull { get { return GetDoughCount >= MaxDoughCount; } }

        Stack<GameObject> _breads = new Stack<GameObject>();


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
        public void AddDough(GameObject objectToAdd) {
            objectToAdd.transform.SetParent(itemStackPoint);

            if (_doughs.Count == 0)
            {
                objectToAdd.transform.localPosition = Vector3.zero;
            }
            else
            {
                Transform lastDoughTransform = _doughs.Peek().transform;
                objectToAdd.transform.localPosition = new Vector3(0, lastDoughTransform.localPosition.y + itemStackOffset, 0);
            }

            _doughs.Push(objectToAdd);
        }

        public void RemoveLastDough() {
            GameObject dough = _doughs.Pop();
            Destroy(dough);
        }


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
    }
}