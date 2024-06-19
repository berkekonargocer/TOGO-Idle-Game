using DG.Tweening;
using System.Collections;
using UnityEngine;

namespace NOJUMPO
{
    public class CountingFloat : CountTowards
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] float initialValue = 0;

        public float Value { get { return _value; } private set { UpdateText(value); _value = value; } }
        float _value;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        protected override void Awake() {
            base.Awake();
            _value = initialValue;
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void SetValue(float newValue) {
            Value = newValue;
        }

        public void AddValue(float addAmount) {
            Value += addAmount;
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void UpdateText(float newValue) {
            if (_countCoroutine != null)
            {
                StopCoroutine(_countCoroutine);
            }

            if (playScaleAnimation)
            {
                ScaleUpAndDownAnim();
            }

            _countCoroutine = StartCoroutine(Count(newValue));
        }

        void ScaleUpAndDownAnim() {
            transform.DOScale(1.2f, 0.25f).OnComplete(() => transform.DOScale(1.0f, 0.25f)).SetEase(Ease.InOutSine);
        }

        IEnumerator Count(float newValue) {
            float previousValue = _value;
            int stepAmount;

            if (newValue - previousValue < 0)
            {
                stepAmount = Mathf.FloorToInt((newValue - previousValue) / (countFPS * duration));
            }
            else
            {
                stepAmount = Mathf.CeilToInt((newValue - previousValue) / (countFPS * duration));
            }

            if (previousValue < newValue)
            {
                while (previousValue < newValue)
                {
                    previousValue += stepAmount;

                    if (previousValue > newValue)
                    {
                        previousValue = newValue;
                    }

                    _numberText.SetText($"<color=\"{prefixTextColorCode}\">{prefixText}</color>" +
                        $"<color=\"{numberTextColorCode}\">{previousValue.ToString("F0")}</color>" +
                        $"<color=\"{suffixTextColorCode}\">{suffixText}</color>");

                    yield return _waitTime;
                }
            }
            else
            {
                while (previousValue > newValue)
                {
                    previousValue += stepAmount;

                    if (previousValue < newValue)
                    {
                        previousValue = newValue;
                    }

                    _numberText.SetText($"<color=\"{prefixTextColorCode}\">{prefixText}</color>" +
                        $"<color=\"{numberTextColorCode}\">{previousValue.ToString("F0")}</color>" +
                        $"<color=\"{suffixTextColorCode}\">{suffixText}</color>");

                    yield return _waitTime;
                }
            }
        }
    }
}