using UnityEngine;

namespace NOJUMPO
{
    public class Stand : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [field: SerializeField] public ItemStack BreadStack { get; private set; }

        void Awake() {
            BreadStack.Initialize(gameObject);
        }
    }
}