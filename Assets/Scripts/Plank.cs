using UnityEngine;

public class Plank : MonoBehaviour
{
	public GameObject plank_unplaced;

	public GameObject plank_placed;

	public GameObject intText;

	public GameObject lockedtext;

	public AudioSource open;

	public AudioSource close;

	public bool opened;

	public bool locked;

	public static bool keyfound;

	private void Start()
	{
		keyfound = false;
	}

	private void OnTriggerStay(Collider other)
	{
		if (!other.CompareTag("MainCamera") || opened)
		{
			return;
		}
		if (!locked)
		{
			intText.SetActive(value: true);
			if (Input.GetKey(KeyCode.E))
			{
				plank_unplaced.SetActive(value: false);
				plank_placed.SetActive(value: true);
				intText.SetActive(value: false);
				open.Play();
				opened = true;
			}
		}
		if (locked)
		{
			lockedtext.SetActive(value: true);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("MainCamera"))
		{
			intText.SetActive(value: false);
			lockedtext.SetActive(value: false);
		}
	}

	private void Update()
	{
		if (keyfound)
		{
			locked = false;
		}
	}
}
