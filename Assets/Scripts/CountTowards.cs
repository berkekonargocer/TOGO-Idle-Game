using TMPro;
using UnityEngine;

namespace NOJUMPO
{

    [RequireComponent(typeof(TextMeshProUGUI))]
    public abstract class CountTowards : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] protected int countFPS = 30;
        [SerializeField] protected float duration = 1.0f;

        [SerializeField] protected bool playScaleAnimation = false;

        [SerializeField] protected string prefixText;

        [SerializeField] protected string suffixText;

        [SerializeField] protected string numberTextColorCode = "white";
        [SerializeField] protected string prefixTextColorCode = "white";
        [SerializeField] protected string suffixTextColorCode = "white";

        protected TextMeshProUGUI _numberText;
        protected Coroutine _countCoroutine;
        protected WaitForSeconds _waitTime;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        protected virtual void Awake() {
            _numberText = GetComponent<TextMeshProUGUI>();
            _waitTime = new WaitForSeconds(1.0f / countFPS);
        }
    }
}