using UnityEngine;

namespace NOJUMPO
{
    public class DoughDropTrigger : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] Oven oven;

        bool _isPlayerInRange = false;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Player"))
            {
                _isPlayerInRange = true;
                Inventory playerInventory = other.GetComponent<Inventory>();

                while (!playerInventory.DoughStack.IsStackEmpty && _isPlayerInRange) 
                {
                    oven.DoughStack.AddItem(playerInventory.DoughStack.TakeItem());
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