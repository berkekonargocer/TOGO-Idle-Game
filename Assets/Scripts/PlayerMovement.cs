using UnityEngine;
using UnityEngine.Splines;

namespace NOJUMPO
{
    public class PlayerMovement : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        SplineAnimate _splineAnimate;

        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            _splineAnimate = GetComponent<SplineAnimate>();
        }

        void OnEnable() {
        }

        void OnDisable() {
        }

        void Start() {

        }

        void Update() {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                _splineAnimate.Play();
            }
            if(Input.GetKeyUp(KeyCode.Mouse0))
            {
                _splineAnimate.Pause();
            }

        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
    }
}