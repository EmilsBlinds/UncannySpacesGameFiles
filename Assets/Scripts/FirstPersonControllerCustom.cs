using UnityEngine;

namespace UnityStandardAssets.Characters.FirstPerson
{
    public class FirstPersonControllerCustom : MonoBehaviour
    {
        public float walkingSpeed = 9f;
        public float runningSpeed = 112.5f;
        public float jumpSpeed = 8f;
        public float gravity = 20f;
        public Camera playerCamera;
        public float lookSpeed = 2f;
        public float lookXLimit = 45f;

        private CharacterController characterController;
        private Vector3 moveDirection = Vector3.zero;
        private float rotationX;

        [HideInInspector]
        public bool canMove = true;

        [HideInInspector]
        public StaminaController _staminaController;

        public AudioClip walkingSound;
        private AudioSource audioSource;


        private void Start()
        {
            _staminaController = GetComponent<StaminaController>();
            characterController = GetComponent<CharacterController>();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
            audioSource.spatialBlend = 0.0f;
        }

        public void SetRunSpeed(float speed)
        {
            runningSpeed = speed;
        }

        private void Update()
        {
            Vector3 vector = transform.TransformDirection(Vector3.forward);
            Vector3 vector2 = transform.TransformDirection(Vector3.right);
            bool key = Input.GetKey(KeyCode.LeftShift);

            if (!key)
            {
                _staminaController.weAreSprinting = false;
            }

            if (key && _staminaController.playerStamina > 0f)
            {
                _staminaController.weAreSprinting = true;
                _staminaController.Sprinting();
            }

            float num = (canMove ? ((key ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical")) : 0f);
            float num2 = (canMove ? ((key ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal")) : 0f);
            float y = moveDirection.y;

            moveDirection = vector * num + vector2 * num2;

            if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
            {
                moveDirection.y = jumpSpeed;
            }
            else
            {
                moveDirection.y = y;
            }

            if (!characterController.isGrounded)
            {
                moveDirection.y -= gravity * Time.deltaTime;
            }

            characterController.Move(moveDirection * Time.deltaTime);

            if (canMove)
            {
                rotationX += (-Input.GetAxis("Mouse Y")) * lookSpeed;
                rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
                playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
                transform.rotation *= Quaternion.Euler(0f, Input.GetAxis("Mouse X") * lookSpeed, 0f);
            }

            bool isWalking = characterController.velocity.magnitude > 0.01f;

            if (isWalking)
            {
                audioSource.clip = walkingSound;
                audioSource.Play();
            }
            else if (!isWalking)
            {
                audioSource.Stop();
            }
        }
    }
}
