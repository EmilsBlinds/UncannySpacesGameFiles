using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
	public GameObject door_closed;

	public GameObject door_opened;

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
				door_closed.SetActive(value: false);
				door_opened.SetActive(value: true);
				intText.SetActive(value: false);
				open.Play();
				StartCoroutine(repeat());
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

	private IEnumerator repeat()
	{
		yield return new WaitForSeconds(8f);
		opened = false;
		door_closed.SetActive(value: true);
		door_opened.SetActive(value: false);
		close.Play();
	}

	private void Update()
	{
		if (keyfound)
		{
			locked = false;
		}
	}
}
