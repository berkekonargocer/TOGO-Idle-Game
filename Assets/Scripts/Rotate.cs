using DG.Tweening;
using UnityEngine;

namespace NOJUMPO
{
    public class Rotate : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] Vector3 rotateVector;
        [SerializeField] float rotateDuration = 2.5f;

        Tween rotateTween;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            rotateTween = transform.DOLocalRotate(rotateVector, rotateDuration, RotateMode.LocalAxisAdd).SetEase(Ease.Linear).SetLoops(-1);
        }

        void OnDestroy() {
            rotateTween.Kill();
        }
    }
}