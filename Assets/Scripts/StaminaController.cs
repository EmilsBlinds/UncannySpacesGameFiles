using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class StaminaController : MonoBehaviour
{
	[Header("Stamina Main Parameters")]
	public float playerStamina = 100f;

	[SerializeField]
	private float maxStamina = 100f;

	[SerializeField]
	private float jumpCost = 20f;

	[HideInInspector]
	public bool hasRegenerated = true;

	[HideInInspector]
	public bool weAreSprinting;

	[Header("Stamina Regen Parameters")]
	[Range(0f, 50f)]
	[SerializeField]
	private float staminaDrain = 0.5f;

	[Range(0f, 50f)]
	[SerializeField]
	private float staminaRegen = 0.5f;

	[Header("Stamina Speed Parameters")]
	[SerializeField]
	private int slowedRunSpeed = 4;

	[SerializeField]
	private int normalRunSpeed = 8;

	[Header("Stamina UI Elements")]
	[SerializeField]
	private Image staminaProgressUI;

	[SerializeField]
	private CanvasGroup sliderCanvasGroup;

	private FirstPersonControllerCustom playerController;

	private void Start()
	{
		playerController = GetComponent<FirstPersonControllerCustom>();
	}

	private void Update()
	{
		if (!weAreSprinting && (double)playerStamina <= (double)maxStamina - 0.01)
		{
			playerStamina += staminaRegen * Time.deltaTime;
			UpdateStamina(1);
			if (playerStamina >= maxStamina)
			{
				playerController.SetRunSpeed(normalRunSpeed);
				sliderCanvasGroup.alpha = 0f;
				hasRegenerated = true;
			}
		}
	}

	public void Sprinting()
	{
		if (hasRegenerated)
		{
			weAreSprinting = true;
			playerStamina -= staminaDrain * Time.deltaTime;
			UpdateStamina(1);
			if (playerStamina == 0f)
			{
				hasRegenerated = false;
				sliderCanvasGroup.alpha = 0f;
			}
		}
		if (playerStamina <= 1f)
		{
			playerController.SetRunSpeed(slowedRunSpeed);
		}
		else
		{
			playerController.SetRunSpeed(normalRunSpeed);
		}
	}

	private void UpdateStamina(int value)
	{
		staminaProgressUI.fillAmount = playerStamina / maxStamina;
		if (value == 0)
		{
			sliderCanvasGroup.alpha = 0f;
		}
		else
		{
			sliderCanvasGroup.alpha = 1f;
		}
	}
}
