using Cysharp.Threading.Tasks;
using UnityEngine;

namespace NOJUMPO
{
    public class Oven : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] GameObject breadPrefab;

        [SerializeField] float breadBakeInterval = 1.0f;
        [field: SerializeField] public ItemStack DoughStack { get; private set; }
        [field: SerializeField] public ItemStack BreadStack { get; private set; }


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            DoughStack.Initialize(gameObject);
            BreadStack.Initialize(gameObject);
        }

        void Start() {
            BakeBreadTask().Forget();
        }


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