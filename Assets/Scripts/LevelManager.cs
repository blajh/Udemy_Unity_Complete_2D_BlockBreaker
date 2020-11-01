using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	[SerializeField] private int _blockCount;
	private SceneLoader _sceneLoader;

	private void Start() {
		_sceneLoader = FindObjectOfType<SceneLoader>();
	}

	public void AddBlock() {
		_blockCount++;
	}

	public void BlockDestroyed() {
		_blockCount--;
		CheckBlocks();
	}

	private void CheckBlocks() {
		if (_blockCount <= 0) {
			_sceneLoader.LoadNextScene();
		}
	}
}
