using System.Collections;
using UnityEngine;

namespace NOJUMPO
{
    public class DoughCollectPoint : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] GameObject doughPrefab;

        [SerializeField] float doughCreateInterval;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
        }

        void OnEnable() {
        }

        void OnDisable() {
        }

        void Start() {
        }

        void Update() {
        }

        private void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Player"))
            {
                Inventory playerInventory = other.GetComponent<Inventory>();
                
            }
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        GameObject GetDough() {
            return Instantiate(doughPrefab, Vector3.zero, Quaternion.identity);
        }

        IEnumerator GetDoughOverTime() {
            GetDough();

            yield return new WaitForSeconds(doughCreateInterval);
        }
    }
}