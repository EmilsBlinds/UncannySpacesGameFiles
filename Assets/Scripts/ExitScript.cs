using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScript : MonoBehaviour
{
	public string scenename;

	public GameObject exittext;

	public GameObject player;

	private void OnTriggerStay(Collider other)
	{
		if (other.CompareTag("MainCamera"))
		{
			exittext.SetActive(value: true);
			if (Input.GetKey(KeyCode.E))
			{
				SceneManager.LoadScene(scenename);
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("MainCamera"))
		{
			exittext.SetActive(value: false);
		}
	}
}
