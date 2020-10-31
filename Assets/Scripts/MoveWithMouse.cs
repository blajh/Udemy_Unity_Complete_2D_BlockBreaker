using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithMouse : MonoBehaviour
{
	[SerializeField]
	private float screenWidthInUnits = 11.7f;

    void Update()
    {
        UpdatePaddlePosition();
    }

	public void UpdatePaddlePosition() {
        float mousePositionInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
		float mousePostionClamped = Mathf.Clamp(mousePositionInUnits, 0f, screenWidthInUnits);
        Vector3 mousePositionFinal = new Vector3(mousePostionClamped, 0f, 0f);
        transform.position = mousePositionFinal;
    }
} 
