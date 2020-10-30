using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	public void LoadNextScene () {
		int sceneIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(sceneIndex + 1);
	}

	public void LoadMenuScene() {
		SceneManager.LoadScene(0); 
	}

	public void QuitApplication() {
		Application.Quit();
	}
}
