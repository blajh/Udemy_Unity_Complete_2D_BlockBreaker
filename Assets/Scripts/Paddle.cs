using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
	[SerializeField]
	private float _screenWidthInUnits = 11.7f;
    private GameSession _gameSession;
	private BallBehaviour _ballBehaviour;

	private bool _isAutoPlayEnabled = false;

	private void Awake() {
		_gameSession = FindObjectOfType<GameSession>();
		_ballBehaviour = FindObjectOfType<BallBehaviour>();
	}

	void Update()
    {
		_isAutoPlayEnabled = _gameSession.IsAutoPlayEnabled();
		UpdatePaddlePosition();
    }

	public void UpdatePaddlePosition() {
        Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
		currentPosition.x = Mathf.Clamp(GetXPosition(), 0f, _screenWidthInUnits);
        transform.position = currentPosition; 
    }

	private float GetXPosition() {

		if (_isAutoPlayEnabled) {
			return _ballBehaviour.transform.position.x;
		}
		else {
			return Input.mousePosition.x / Screen.width * _screenWidthInUnits;
		}
	}

} 
