using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
	[SerializeField, Range(0.1f, 10f)]
	private float _gameSpeed = 1f;

	[SerializeField] private int _pointsPerDestroyedBlock = 42;
	[SerializeField] private int _currentScore = 0;

	private void Update() {
		Time.timeScale = _gameSpeed;
	}

	public void AddPointsToScore() {
		_currentScore += _pointsPerDestroyedBlock;
	}
}
