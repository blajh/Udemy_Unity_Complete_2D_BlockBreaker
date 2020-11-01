using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
	[SerializeField]
	private AudioClip _destroyedAudioClip;

	private void OnCollisionEnter2D(Collision2D collision) {
		AudioSource.PlayClipAtPoint(_destroyedAudioClip, Camera.main.transform.position);
		Destroy(gameObject);
	}
}
