using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
	[SerializeField]
	private float screenWidthInUnits = 11.7f;

    void Update()
    {
        UpdatePaddlePosition();
    }

	public void UpdatePaddlePosition() {
        float mousePositionInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
		currentPosition.x = Mathf.Clamp(mousePositionInUnits, 0f, screenWidthInUnits);
        transform.position = currentPosition; 
    }
} 
