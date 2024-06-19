using DG.Tweening;
using System.Collections;
using UnityEngine;

namespace NOJUMPO
{
    public class CountingFloat : CountTowards
    {
        // -------------------------------- FIELDS ---------------------------------
        public float Value { get { return _value; } set { UpdateText(value); _value = value; } }
        float _value;


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
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


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
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