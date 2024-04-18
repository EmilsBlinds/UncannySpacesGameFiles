using UnityEngine;
using UnityEngine.SceneManagement;

public class defeatscreen : MonoBehaviour
{
	private void Update()
	{
		if (Input.GetKey(KeyCode.R))
		{
			SceneManager.LoadScene(0);
		}
		if (Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
}
