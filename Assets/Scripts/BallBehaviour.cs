using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
	[SerializeField] Paddle paddle1;
	private Vector2 paddleToBallVector;

	private void Start() {
		CalculateOffsetToPaddle();
	}

	private void Update() {
		FollowPaddle();
	}

	private void CalculateOffsetToPaddle() {
		paddleToBallVector = transform.position - paddle1.transform.position;
	}

	private void FollowPaddle() {
		Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
		transform.position = paddlePos + paddleToBallVector;
	}
	  
}
