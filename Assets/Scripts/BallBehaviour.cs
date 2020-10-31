﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
	[SerializeField] Paddle paddle1;
	[SerializeField] float xPushForce = 2f;
	[SerializeField] float yPushForce = 10f;
	private Vector2 paddleToBallVector;
	private bool hasBeenLaunched = false;

	[SerializeField] AudioClip[] audioClips;

	private void Start() {
		CalculateOffsetToPaddle();
	}

	private void Update() {
		if (!hasBeenLaunched) {
			LockBallToPaddle();
			LaunchOnMouseClick();
		}
	}

	private void CalculateOffsetToPaddle() {
		paddleToBallVector = transform.position - paddle1.transform.position;
	}

	private void LockBallToPaddle() {
		Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
		transform.position = paddlePos + paddleToBallVector;
	}
	  
	private void LaunchOnMouseClick() {
		if (Input.GetMouseButtonDown(0)) {
			hasBeenLaunched = true;
			GetComponent<Rigidbody2D>().velocity = new Vector2(xPushForce, yPushForce);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		if (hasBeenLaunched) {
			AudioClip audioClip = audioClips[UnityEngine.Random.Range(0, audioClips.Length)];
			GetComponent<AudioSource>().PlayOneShot(audioClip);
		}
	}
}
