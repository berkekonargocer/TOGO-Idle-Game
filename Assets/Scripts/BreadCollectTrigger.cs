using UnityEngine;

namespace NOJUMPO
{
    public class BreadCollectTrigger : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] Oven oven;

        bool _isPlayerInCollectRange = false;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Player"))
            {
                _isPlayerInCollectRange = true;
                Inventory playerInventory = other.GetComponent<Inventory>();

                while (!oven.BreadStack.IsStackEmpty && !playerInventory.BreadStack.IsStackFull)
                {
                    playerInventory.AddBread(oven.BreadStack.TakeItem()); 
                }
            }
        }

        void OnTriggerExit(Collider other) {
            if (other.CompareTag("Player"))
            {
                _isPlayerInCollectRange = false;
            }
        }

        // ------------------------- CUSTOM PUBLIC METHODS -------------------------


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
    }
}