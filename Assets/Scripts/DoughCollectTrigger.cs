using UnityEngine;

namespace NOJUMPO
{
    public class DoughCollectTrigger : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] Light collectPointLight;
        DoughMachine _doughMachine;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            _doughMachine = GetComponentInParent<DoughMachine>();
        }

        void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Player"))
            {
                collectPointLight.color = Color.green;
                Inventory playerInventory = other.GetComponent<Inventory>();
                _doughMachine.GiveDough(playerInventory);
            }
        }

        void OnTriggerExit(Collider other) {
            if (other.CompareTag("Player"))
            {
                collectPointLight.color = Color.yellow;
                _doughMachine.StopGivingDough();
            }
        }
    }
}