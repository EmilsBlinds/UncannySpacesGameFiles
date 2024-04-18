using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public Text PlayText;

	public AudioSource hover;

	public void OnPointerEnter(PointerEventData eventData)
	{
		PlayText.color = Color.white;
		hover.Play();
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		PlayText.color = Color.grey;
	}
}
