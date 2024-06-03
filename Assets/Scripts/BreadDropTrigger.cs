using UnityEngine;

namespace NOJUMPO
{
    public class BreadDropTrigger : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] Stand stand;

        bool _isPlayerInRange = false;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Player"))
            {
                _isPlayerInRange = true;
                Inventory playerInventory = other.GetComponent<Inventory>();

                while (!playerInventory.BreadStack.IsStackEmpty && _isPlayerInRange)
                {
                    stand.BreadStack.AddItem(playerInventory.BreadStack.TakeItem());
                }
            }
        }

        void OnTriggerExit(Collider other) {
            if (other.CompareTag("Player"))
            {
                _isPlayerInRange = false;
            }
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
    }
}