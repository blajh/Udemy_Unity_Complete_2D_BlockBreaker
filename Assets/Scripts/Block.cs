using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
	[SerializeField] private AudioClip _destroyedAudioClip;
	[SerializeField] private LevelManager _levelManager;
	[SerializeField] private GameSession _gameSession;
	[SerializeField] private GameObject _blockSparklesVFX;

	private bool isBreakable;
	[SerializeField] private int _timesHit;
	[SerializeField] private Sprite[] _hitSprites;

	private void Start() {
		SetBreakability();
		CountBreakableBlocks();
	}

	private void CountBreakableBlocks() {
		if (isBreakable) {
			_levelManager = FindObjectOfType<LevelManager>();
			_levelManager.AddBlock();
		}
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		HandleHit();
	}

	private void HandleHit() {
		if (isBreakable) {
			_timesHit++;
			int _maxHits = _hitSprites.Length + 1;
			if (_timesHit >= _maxHits) {
				DestroyBlock();
			} else {
				ShowNextHitSprite();
			}
		}
	}

	private void ShowNextHitSprite() {
		int _spriteIndex = _timesHit - 1;
		if (_hitSprites[_spriteIndex] != null) {
			GetComponent<SpriteRenderer>().sprite = _hitSprites[_spriteIndex];
		} else {
			Debug.LogError("Block Sprite is missing from array: " + gameObject.name);
		}
	}

	private void DestroyBlock() {
		PlayBlockDestroySFX();
		_levelManager.BlockDestroyed();
		AddToScore();
		TriggerSparklesVFX();
		Destroy(gameObject);
	}

	private void PlayBlockDestroySFX() {
		AudioSource.PlayClipAtPoint(_destroyedAudioClip, Camera.main.transform.position);
	}

	private void AddToScore() {
		_gameSession = FindObjectOfType<GameSession>();
		_gameSession.AddPointsToScore();
	}

	private void TriggerSparklesVFX () {
		var _sparkles = Instantiate(_blockSparklesVFX, transform.position, transform.rotation);
		Destroy(_sparkles, 2f);
	}

	private void SetBreakability() {
		if (tag == "Breakable") {
			isBreakable = true;
		}
		else if (tag == "Unbreakable") {
			isBreakable = false;
		}
	}
}
