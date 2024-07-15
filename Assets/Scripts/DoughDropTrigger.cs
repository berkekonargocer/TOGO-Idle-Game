using UnityEngine;
using UnityEngine.UI;

namespace NOJUMPO
{
    public class DoughDropTrigger : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] Oven oven;
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

                while (!playerInventory.DoughStack.IsStackEmpty && !oven.DoughStack.IsStackFull  && _isPlayerInRange) 
                {
                    oven.DoughStack.AddItem(playerInventory.DoughStack.TakeItem());
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

        // ------------------------- CUSTOM PUBLIC METHODS -------------------------


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
    }
}