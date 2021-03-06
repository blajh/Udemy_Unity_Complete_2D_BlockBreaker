﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
	[SerializeField, Range(0.1f, 10f)]
	private float _gameSpeed = 1f;

	[SerializeField] private int _pointsPerDestroyedBlock = 42;
	[SerializeField] private int _currentScore = 0;

	public TMP_Text scoreText;

	[SerializeField] private bool _isAutoPlayEnabled;

	private void Awake() {
		int gameStatusCount = FindObjectsOfType<GameSession>().Length;
		if (gameStatusCount > 1) {
			gameObject.SetActive(false);
			Destroy(gameObject);
		}

		else {
			DontDestroyOnLoad(gameObject);
		}
	}

	private void Start() {
		UpdateScoreUI();
	}

	private void Update() {
		Time.timeScale = _gameSpeed;
	}

	public void AddPointsToScore() {
		_currentScore += _pointsPerDestroyedBlock;
		UpdateScoreUI();
	}

	private void UpdateScoreUI() {
		scoreText.text = _currentScore.ToString();
	}

	public void ResetGame() {
		Destroy(gameObject);
	}

	public bool IsAutoPlayEnabled() {
		return _isAutoPlayEnabled;
	}
}
