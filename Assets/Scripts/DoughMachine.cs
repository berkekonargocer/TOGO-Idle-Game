using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;
using System.Threading;
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

        Tween _progressBarFillAmountTween;

        CancellationTokenSource _cancellationTokenSource;


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public async UniTask GiveDoughTask(Inventory playerInventory, CancellationToken token) {
            try
            {
                while (!playerInventory.DoughStack.IsStackFull && playerInventory.BreadStack.IsStackEmpty)
                {
                    FillProgressBar();
                    await UniTask.WaitForSeconds(doughGiveInterval, cancellationToken: token);
                    GameObject dough = GetDough();
                    playerInventory.AddDough(dough);
                    progressBarImage.fillAmount = 0;
                }
            }
            catch (OperationCanceledException)
            {

            }
        }

        public void GiveDough(Inventory playerInventory) {
            _cancellationTokenSource = new CancellationTokenSource();
            GiveDoughTask(playerInventory, _cancellationTokenSource.Token).Forget();
        }

        public void StopGivingDough() {
            if (_cancellationTokenSource == null)
                return;

            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();
            _cancellationTokenSource = null;

            StopProgressBar();
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