using UnityEngine;
using UnityEngine.Splines;

namespace NOJUMPO
{
    public class PlayerMovement : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        SplineAnimate _splineAnimate;
        Animator _animator;

        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            _splineAnimate = GetComponent<SplineAnimate>();
            _animator = GetComponent<Animator>();
        }

        void OnEnable() {
        }

        void OnDisable() {
        }

        void Start() {

        }

        void Update() {
            Move();
        }



        // ------------------------- CUSTOM PUBLIC METHODS -------------------------


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void Move() {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                _splineAnimate.Play();
                _animator.SetBool("isMoving", true);

            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                _splineAnimate.Pause();
                _animator.SetBool("isMoving", false);
            }
        }
    }
}