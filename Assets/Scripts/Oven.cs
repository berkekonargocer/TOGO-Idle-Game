using Cysharp.Threading.Tasks;
using UnityEngine;

namespace NOJUMPO
{
    public class Oven : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] GameObject breadPrefab;
        public bool PlayerInCollectRange { get; private set; } = false;


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


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void SetPlayerCollectRangeState(bool state) {
            PlayerInCollectRange = state;
        }


        public async UniTaskVoid GiveBreadTask(Inventory playerInventory) {
            while (PlayerInCollectRange && !playerInventory.IsBreadFull)
            {
                GameObject bread = GetBread();
                playerInventory.AddBread(bread);
                await UniTask.Yield();
            }
        }

        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        GameObject GetBread() {
            return Instantiate(breadPrefab, Vector3.zero, Quaternion.identity);
        }
    }
}