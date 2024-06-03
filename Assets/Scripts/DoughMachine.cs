using Cysharp.Threading.Tasks;
using UnityEngine;

namespace NOJUMPO
{
    public class DoughMachine : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] GameObject doughPrefab;
        [SerializeField] float doughGiveInterval;
        public bool IsPlayerInRange { get; private set; } = false;


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void SetPlayerCollectRangeState(bool state) {
            IsPlayerInRange = state;
        }


        public async UniTaskVoid GiveDoughTask(Inventory playerInventory) {
            while (IsPlayerInRange && !playerInventory.DoughStack.IsStackFull)
            {
                GameObject dough = GetDough();
                playerInventory.AddDough(dough);
                await UniTask.WaitForSeconds(doughGiveInterval);
            }
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        GameObject GetDough() {
            return Instantiate(doughPrefab, Vector3.zero, Quaternion.identity);
        }
    }
}