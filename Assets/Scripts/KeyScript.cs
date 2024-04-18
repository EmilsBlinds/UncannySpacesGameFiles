using UnityEngine;

public class KeyScript : MonoBehaviour
{
	public GameObject inticon_k, key, Icon;

	public AudioSource pickup;

	private void OnTriggerStay(Collider other)
	{
		if (other.CompareTag("MainCamera"))
		{
			inticon_k.SetActive(value: true);
			if (Input.GetKey(KeyCode.E))
			{
				key.SetActive(value: false);
				Door.keyfound = true;
				inticon_k.SetActive(value: false);
				Icon.SetActive(value: true);
				pickup.Play();
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("MainCamera"))
		{
			inticon_k.SetActive(value: false);
		}
	}
}
