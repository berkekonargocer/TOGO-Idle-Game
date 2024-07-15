using UnityEngine;
using UnityEngine.UI;

namespace NOJUMPO
{
    public class BreadDropTrigger : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] Stand stand;
        [SerializeField] Image progressBarImage;
        [SerializeField] Light dropPointLight;

        bool _isPlayerInRange = false;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Player"))
            {
                _isPlayerInRange = true;
                dropPointLight.color = Color.green;
                progressBarImage.fillAmount = 1;
                Inventory playerInventory = other.GetComponent<Inventory>();

                while (!playerInventory.BreadStack.IsStackEmpty && !stand.BreadStack.IsStackFull && _isPlayerInRange)
                {
                    stand.BreadStack.AddItem(playerInventory.BreadStack.TakeItem());
                }
            }
        }

        void OnTriggerExit(Collider other) {
            if (other.CompareTag("Player"))
            {
                _isPlayerInRange = false;
                dropPointLight.color = Color.yellow;
                progressBarImage.fillAmount = 0;
            }
        }
    }
}