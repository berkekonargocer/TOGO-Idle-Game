using UnityEngine;

namespace NOJUMPO
{
    public class BreadCollectTrigger : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] Oven oven;

        Inventory _playerInventory;

        //bool _isPlayerInCollectRange = false;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Player"))
            {
                _playerInventory = other.GetComponent<Inventory>();
            }
        }

        private void OnTriggerStay(Collider other) {
            if (other.CompareTag("Player"))
            {
                if (!oven.BreadStack.IsStackEmpty && !_playerInventory.BreadStack.IsStackFull)
                {
                    _playerInventory.AddBread(oven.BreadStack.TakeItem());
                }
            }
        }

        // ------------------------- CUSTOM PUBLIC METHODS -------------------------


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
    }
}