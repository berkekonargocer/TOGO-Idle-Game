using System.Collections.Generic;
using UnityEngine;

namespace NOJUMPO
{
    public class DoughStack : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] Transform doughStackPosTransform;

        [SerializeField] float doughStackOffset = 0.1f;

        Stack<GameObject> _doughs = new Stack<GameObject>();
        public int GetDoughCount { get { return _doughs.Count; } }
        public bool IsStackFull { get { return _doughs.Count >= MAX_DOUGH_COUNT; } }
        public bool IsStackEmpty { get { return _doughs.Count <= 0; } }

        const int MAX_DOUGH_COUNT = 5;


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
        public void AddDough(GameObject dough) {
            dough.transform.SetParent(doughStackPosTransform);

            if (IsStackEmpty)
            {
                dough.transform.localPosition = Vector3.zero;
            }
            else
            {
                dough.transform.localPosition = new Vector3(0, 0, _doughs.Peek().transform.position.z + doughStackOffset);
            }

            _doughs.Push(dough);
        }

        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
    }
}