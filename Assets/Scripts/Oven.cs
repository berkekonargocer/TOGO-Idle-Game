using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;

namespace NOJUMPO
{
    public class Oven : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] GameObject breadPrefab;

        [SerializeField] Transform bakedBreadsStackPosTransform;

        [SerializeField] float bakedBreadStackOffset = 0.1f;

        [SerializeField] float breadBakeInterval = 1.0f;

        public bool PlayerInCollectRange { get; private set; } = false;

        DoughStack _doughStack = new DoughStack();

        Stack<GameObject> bakedBreads = new Stack<GameObject>();
        public int DoughCount { get; private set; } = 0;

        const int MAX_BREAD_COUNT = 5;


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

        void BakeBread() {
            GameObject bread = InstantiateBread();
            bread.transform.SetParent(bakedBreadsStackPosTransform);

            if (bakedBreads.Count == 0)
            {
                bread.transform.localPosition = Vector3.zero;
            }
            else
            {
                bread.transform.localPosition = new Vector3(0, 0, bakedBreads.Peek().transform.position.z + bakedBreadStackOffset);
            }

            bakedBreads.Push(bread);
        }

        async UniTaskVoid BakeBreadTask() {

            //await UniTask.SwitchToThreadPool();

            while (true)
            {
                if (_doughStack.DoughCount > 0 && bakedBreads.Count < MAX_BREAD_COUNT)
                {
                    await UniTask.WaitForSeconds(breadBakeInterval);
                    BakeBread();
                    DoughCount--;
                }
                else
                {
                    await UniTask.Yield();
                }
            }
        }
    }
}