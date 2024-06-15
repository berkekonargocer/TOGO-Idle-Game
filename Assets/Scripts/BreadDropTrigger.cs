using UnityEngine;
using UnityEngine.UI;

namespace NOJUMPO
{
    public class BreadDropTrigger : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] Stand stand;
        [SerializeField] Image progressBarImage;

        bool _isPlayerInRange = false;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Player"))
            {
                _isPlayerInRange = true;
                progressBarImage.fillAmount = 1;
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
                progressBarImage.fillAmount = 0;
            }
        }
    }
}