using UnityEngine;

public class PlayonW : MonoBehaviour
{
	public AudioSource Walk;

	private void Start()
	{
	}

	private void Update()
	{
		if (Input.GetKeyDown("w") && !Walk.isPlaying)
		{
			Walk.Play();
		}
		if (Input.GetKeyUp(KeyCode.W))
		{
			Walk.Stop();
		}
	}
}
