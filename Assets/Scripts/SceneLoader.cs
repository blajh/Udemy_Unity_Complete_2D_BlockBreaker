using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	private GameStatus _gameStatus;

	private void Awake() {
		_gameStatus = FindObjectOfType<GameStatus>();
	}

	public void LoadNextScene () {
		int sceneIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(sceneIndex + 1);
	}

	public void LoadMenuScene() {
		SceneManager.LoadScene(0);
		_gameStatus.ResetScore();
	}

	public void QuitApplication() {
		Application.Quit();
	}
}
