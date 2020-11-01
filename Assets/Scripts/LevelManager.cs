using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	private GameObject[] _blocks;
	private int _blockCount;

	private void Update() {
		CheckBoxes();
	}

	private void CheckBoxes() {
		CountBlocks();
		if (_blockCount <= 0) {
			int sceneIndex = SceneManager.GetActiveScene().buildIndex;
			SceneManager.LoadScene(sceneIndex + 1);
		}
	}

	private void CountBlocks() {
		_blocks = GameObject.FindGameObjectsWithTag("Block");
		_blockCount = _blocks.Length;
	}
}
