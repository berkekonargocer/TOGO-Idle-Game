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
            BreadStack.Initialize();
            DoughStack.Initialize();
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
    }
}