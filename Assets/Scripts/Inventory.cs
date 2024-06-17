using UnityEngine;

namespace NOJUMPO
{
    public class Inventory : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [field: SerializeField] public ItemStack BreadStack { get; private set; }
        [field: SerializeField] public ItemStack DoughStack { get; private set; }


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            BreadStack.Initialize(gameObject);
            DoughStack.Initialize(gameObject);
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void AddDough(GameObject dough) {
            if (!BreadStack.IsStackEmpty)
                return;

            DoughStack.AddItem(dough);
        }

        public void AddBread(GameObject bread) {
            if (!DoughStack.IsStackEmpty)
                return;

            BreadStack.AddItem(bread);
        }
    }
}