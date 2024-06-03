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

        public bool PlayerInCollectRange { get; private set; } = false;

        DoughStack _doughStack = new DoughStack();

        BreadStack _breadStack = new BreadStack();


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
                if (!_doughStack.IsStackEmpty && !_breadStack.IsStackFull)
                {
                    await UniTask.WaitForSeconds(breadBakeInterval);
                    GameObject bread = InstantiateBread();
                    _breadStack.AddBread(bread);
                }
                else
                {
                    await UniTask.Yield();
                }
            }
        }
    }
}