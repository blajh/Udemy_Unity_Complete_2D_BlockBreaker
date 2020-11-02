﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
	[SerializeField] private AudioClip _destroyedAudioClip;
	[SerializeField] private LevelManager _levelManager;
	[SerializeField] private GameSession gameSession;

	private void Start() {
		_levelManager = FindObjectOfType<LevelManager>();
		_levelManager.AddBlock();
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		AudioSource.PlayClipAtPoint(_destroyedAudioClip, Camera.main.transform.position);
		_levelManager.BlockDestroyed();
		gameSession = FindObjectOfType<GameSession>();
		gameSession.AddPointsToScore();
		Destroy(gameObject);
	}
}
