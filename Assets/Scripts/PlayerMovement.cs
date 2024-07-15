using UnityEngine;
using UnityEngine.Splines;

namespace NOJUMPO
{
    public class PlayerMovement : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] AudioClip[] footstepAudios;

        SplineAnimate _splineAnimate;
        AudioSource _audioSource;
        Animator _animator;

        int lastPlayedFootstepIndex;

        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            _splineAnimate = GetComponent<SplineAnimate>();
            _audioSource = GetComponent<AudioSource>();
            _animator = GetComponent<Animator>();
        }

        void Update() {
            Move();
        }



        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        void PlayFootstepSound() {
            int randomNumber = Random.Range(0, footstepAudios.Length); ;

            while (randomNumber == lastPlayedFootstepIndex) 
            {
                randomNumber = Random.Range(0, footstepAudios.Length);
            }

            _audioSource.PlayOneShot(footstepAudios[randomNumber]);
            lastPlayedFootstepIndex = randomNumber;
        }

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