using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


public class CameraBobbing : MonoBehaviour
{
    public float walkingBobbingSpeed = 0.18f;
    public float walkingBobbingAmount = 0.2f;
    public float runningBobbingSpeed = 0.3f;
    public float runningBobbingAmount = 0.3f;
    public float midpoint = 2.0f;

    private float timer = 0.0f;
    private FirstPersonControllerCustom playerController;

    void Start()
    {
        playerController = FindObjectOfType<FirstPersonControllerCustom>();
    }

    void Update() //Calculates camera movement in sine
    {
        float waveslice = 0.0f;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (Mathf.Abs(horizontal) == 0 && Mathf.Abs(vertical) == 0)
        {
            timer = 0.0f;
        }
        else
        {
            float bobbingSpeed = playerController._staminaController.weAreSprinting ? runningBobbingSpeed : walkingBobbingSpeed;
            waveslice = Mathf.Sin(timer);
            timer += bobbingSpeed;
            if (timer > Mathf.PI * 2)
            {
                timer -= Mathf.PI * 2;
            }
        }

        //Calculates camera movement and applies it to Y position of the camera
        Vector3 newPos = transform.localPosition;
        if (waveslice != 0)
        {
            float bobbingAmount = playerController._staminaController.weAreSprinting ? runningBobbingAmount : walkingBobbingAmount;
            float translateChange = waveslice * bobbingAmount;
            float totalAxes = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
            totalAxes = Mathf.Clamp(totalAxes, 0.0f, 1.0f);
            translateChange = totalAxes * translateChange;
            newPos.y = midpoint + translateChange;
        }
        else
        {
            newPos.y = midpoint;
        }

        transform.localPosition = newPos;
    }

}