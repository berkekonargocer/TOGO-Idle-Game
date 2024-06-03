using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;

namespace NOJUMPO
{
    public class Oven : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] GameObject breadPrefab;

        [SerializeField] float breadBakeInterval = 1.0f;


        //[SerializeField] DoughDropTrigger doughDropTrigger;
        //[SerializeField] BreadCollectTrigger breadCollectTrigger;
        [field: SerializeField] public ItemStack DoughStack { get; private set; }
        [field: SerializeField] public ItemStack BreadStack { get; private set; }

        //[SerializeField] ItemStack _breadStack;
        //[SerializeField] ItemStack _doughStack;

        public bool PlayerInCollectRange { get; private set; } = false;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
        }

        void OnEnable() {
        }

        void OnDisable() {
        }

        void Start() {
            BakeBreadTask().Forget();
        }

        void Update() {
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void SetPlayerCollectRangeState(bool state) {
            PlayerInCollectRange = state;
        }



        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        GameObject InstantiateBread() {
            return Instantiate(breadPrefab, Vector3.zero, Quaternion.identity);
        }

        async UniTaskVoid BakeBreadTask() {

            //await UniTask.SwitchToThreadPool();

            while (true)
            {
                if (!DoughStack.IsStackEmpty && !BreadStack.IsStackFull)
                {
                    await UniTask.WaitForSeconds(breadBakeInterval);
                    DoughStack.RemoveItem();
                    GameObject bread = InstantiateBread();
                    BreadStack.AddItem(bread);
                }
                else
                {
                    await UniTask.Yield();
                }
            }
        }
    }
}