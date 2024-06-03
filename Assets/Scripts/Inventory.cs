using UnityEngine;

namespace NOJUMPO
{
    public class Inventory : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------

        [field: SerializeField] public ItemStack BreadStack { get; private set; }
        [field: SerializeField] public ItemStack DoughStack { get; private set; }

        //[SerializeField] Transform itemStackPoint;
        //[SerializeField] float itemStackOffset = 0.1f;

        //Stack<GameObject> _doughs = new Stack<GameObject>();
        //public int GetDoughCount { get { return _doughs.Count; } }
        //public int MaxDoughCount { get; private set; } = 5;
        //public bool IsDoughFull { get { return GetDoughCount >= MaxDoughCount; } }

        //Stack<GameObject> _breads = new Stack<GameObject>();
        //public int GetBreadCount { get { return _breads.Count; } }
        //public int MaxBreadCount { get; private set; } = 5;
        //public bool IsBreadFull { get { return GetBreadCount >= MaxBreadCount; } }


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
            if (!DoughStack.IsStackFull)
            {
                DoughStack.AddItem(dough); 
            }
        }

        public void AddBread(GameObject bread) {
            if (!BreadStack.IsStackFull)
            {
                BreadStack.AddItem(bread); 
            }
        }


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
    }
}