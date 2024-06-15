using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace NOJUMPO
{
    public class DoughMachine : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] GameObject doughPrefab;
        [SerializeField] float doughGiveInterval;
        [SerializeField] Image progressBarImage;
        public bool IsPlayerInRange { get; private set; } = false;

        Tween _progressBarFillAmountTween;


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void SetPlayerCollectRangeState(bool state) {
            IsPlayerInRange = state;
        }


        public async UniTaskVoid GiveDoughTask(Inventory playerInventory) {

            while (IsPlayerInRange && !playerInventory.DoughStack.IsStackFull)
            {
                FillProgressBar();
                await UniTask.WaitForSeconds(doughGiveInterval);
                GameObject dough = GetDough();
                playerInventory.AddDough(dough);
                progressBarImage.fillAmount = 0;
            }
        }

        public void FillProgressBar() {
            _progressBarFillAmountTween = progressBarImage.DOFillAmount(1, doughGiveInterval).SetEase(Ease.Linear);
        }

        public void StopProgressBar() {
            _progressBarFillAmountTween.Kill();
            progressBarImage.fillAmount = 0;
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        GameObject GetDough() {
            return Instantiate(doughPrefab, Vector3.zero, Quaternion.identity);
        }
    }
}