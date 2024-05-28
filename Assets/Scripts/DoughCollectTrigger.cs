using System.Collections;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Unity.VisualScripting;

namespace NOJUMPO
{
    public class DoughCollectTrigger : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] GameObject doughPrefab;
        [SerializeField] float doughGiveInterval;

        bool playerInCollectRange = false;

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

        void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Player"))
            {
                playerInCollectRange = true;
                Inventory playerInventory = other.GetComponent<Inventory>();
                GiveDoughTask(playerInventory).Forget();
            }
        }

        void OnTriggerExit(Collider other) {
            if (other.CompareTag("Player"))
            {
                playerInCollectRange = false;
            }
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------

        GameObject GetDough() {
            return Instantiate(doughPrefab, Vector3.zero, Quaternion.identity);
        }

        async UniTaskVoid GiveDoughTask(Inventory playerInventory) {
            while (playerInCollectRange && !playerInventory.IsDoughFull)
            {
                GameObject dough = GetDough();
                playerInventory.AddDough(dough);
                await UniTask.WaitForSeconds(doughGiveInterval);
            }
        }
    }
}