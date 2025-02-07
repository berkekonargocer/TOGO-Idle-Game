using UnityEngine;
using UnityEngine.UI;

namespace NOJUMPO
{
    public class BreadCollectTrigger : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] Oven oven;
        [SerializeField] Image progressBarImage;
        [SerializeField] Light collectPointLight;

        Inventory _playerInventory;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Player"))
            {
                collectPointLight.color = Color.green;
                _playerInventory = other.GetComponent<Inventory>();
                progressBarImage.fillAmount = 1;
            }
        }

        void OnTriggerStay(Collider other) {
            if (other.CompareTag("Player"))
            {
                if (!oven.BreadStack.IsStackEmpty && !_playerInventory.BreadStack.IsStackFull)
                {
                    _playerInventory.AddBread(oven.BreadStack.TakeItem());
                }
            }
        }

        void OnTriggerExit(Collider other) {
            progressBarImage.fillAmount = 0;
            collectPointLight.color = Color.yellow;
        }

        // ------------------------- CUSTOM PUBLIC METHODS -------------------------


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
    }
}