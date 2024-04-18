using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonOption : MonoBehaviour
{
	private void Start()
	{
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}

	public void MapSelect()
	{
		SceneManager.LoadScene(1);
	}

	public void MainMenu()
	{
		SceneManager.LoadScene(0);
	}

	public void Map1()
	{
		SceneManager.LoadScene(2);
	}

	public void Map2()
	{
		SceneManager.LoadScene(3);
	}

	public void Map3()
	{
		SceneManager.LoadScene(4);
	}

	public void Controls()
	{
		SceneManager.LoadScene(7);
	}

	public void Exit()
	{
		Application.Quit();
	}
}
