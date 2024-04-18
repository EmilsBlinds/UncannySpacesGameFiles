using UnityEngine;
using UnityEngine.SceneManagement;

public class exitgame : MonoBehaviour
{
	private void Update()
	{
		if (Input.GetKey(KeyCode.Escape))
		{
			SceneManager.LoadScene(0);
		}
	}
}
