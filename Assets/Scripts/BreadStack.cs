using System.Collections.Generic;
using UnityEngine;

namespace NOJUMPO
{
    public class BreadStack : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] Transform breadStackPosTransform;

        [SerializeField] float breadStackOffset = 0.1f;

        Stack<GameObject> _bakedBreads = new Stack<GameObject>();
        public int GetBreadCount { get { return _bakedBreads.Count; } }
        public bool IsStackFull { get { return GetBreadCount >= MAX_BREAD_COUNT; } }
        public bool IsStackEmpty { get { return _bakedBreads.Count <= 0; } }

        const int MAX_BREAD_COUNT = 5;


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
        public void AddBread(GameObject bread) {
            bread.transform.SetParent(breadStackPosTransform);

            if (IsStackEmpty)
            {
                bread.transform.localPosition = Vector3.zero;
            }
            else
            {
                bread.transform.localPosition = new Vector3(0, 0, _bakedBreads.Peek().transform.position.z + breadStackOffset);
            }

            _bakedBreads.Push(bread);
        }

        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
    }
}