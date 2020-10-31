using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithMouse : MonoBehaviour
{
    private float screenWidthToGameplayUnitRatio;
    private float mousePosition;
    private float clampedPoition;
    private Vector3 wantedPosition;


    void Update()
    {
        UpdatePaddlePosition();
    }

	public void UpdatePaddlePosition() {
        screenWidthToGameplayUnitRatio = 11.7f / Screen.width;
        mousePosition = Input.mousePosition.x * screenWidthToGameplayUnitRatio;
        clampedPoition = Mathf.Clamp(mousePosition, 0f, 11.7f);
        wantedPosition = new Vector3(clampedPoition, 0f, 0f);
        transform.SetPositionAndRotation(wantedPosition, transform.rotation);
    }
}
