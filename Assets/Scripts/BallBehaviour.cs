using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
	[SerializeField] Paddle _paddle1;
	[SerializeField] float _xPushForce = 2f;
	[SerializeField] float _yPushForce = 10f;

	private Vector2 _paddleToBallVector;
	private bool _hasBeenLaunched = false;

	[SerializeField]
	private AudioClip[] _ballAudioClips;
	private AudioSource _audioSource;

	[SerializeField]
	private float _randomDirectionChangeFactor = 0.5f;
	private Rigidbody2D _rigidbody2D;

	private void Start() {
		CalculateOffsetToPaddle();
		_audioSource = GetComponent<AudioSource>();
		_rigidbody2D = GetComponent<Rigidbody2D>();
	}

	private void Update() {
		if (!_hasBeenLaunched) {
			LockBallToPaddle();
			LaunchOnMouseClick();
		}
	}

	private void CalculateOffsetToPaddle() {
		_paddleToBallVector = transform.position - _paddle1.transform.position;
	}

	private void LockBallToPaddle() {
		Vector2 paddlePos = new Vector2(_paddle1.transform.position.x, _paddle1.transform.position.y);
		transform.position = paddlePos + _paddleToBallVector;
	}
	  
	private void LaunchOnMouseClick() {
		if (Input.GetMouseButtonDown(0)) {
			_hasBeenLaunched = true;
			_rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
			_rigidbody2D.velocity = new Vector2(_xPushForce, _yPushForce);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		TweakVelocity();
		if (_hasBeenLaunched) {
			AudioClip randomAudioClip = _ballAudioClips[UnityEngine.Random.Range(0, _ballAudioClips.Length)];
			_audioSource.PlayOneShot(randomAudioClip);
		}
	}

	private void TweakVelocity() {
		var _random = _randomDirectionChangeFactor;
		Vector2 _velocityTweak = new Vector2 (RandomFloatRange(_random), RandomFloatRange(_random));
		_rigidbody2D.velocity += _velocityTweak;
	}

	private float RandomFloatRange(float _randomFloat) {
		return Random.Range(0f, _randomFloat);
	}
}
