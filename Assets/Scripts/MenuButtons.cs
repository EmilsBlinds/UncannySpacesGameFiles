using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
	public GameObject PauseMenu;

	public void Resume() //Resumes game and lets player move again
	{
		Debug.Log("Resumed");
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
	}

	public void MapSelect()
	{
		SceneManager.LoadScene(1);
	}


	public void MainMenu()
	{
		SceneManager.LoadScene(0);
	}
}
