using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithMouse : MonoBehaviour
{
    private float screenWidthToGameplayUnitRatio;
    private float mousePosition;
    private Vector3 wantedPosition;


    void Update()
    {
        UpdatePaddlePosition();
    }

	public void UpdatePaddlePosition() {
        screenWidthToGameplayUnitRatio = 11.7f / Screen.width;
        mousePosition = Input.mousePosition.x * screenWidthToGameplayUnitRatio;
        wantedPosition = new Vector3(mousePosition, 0f, 0f);
        transform.SetPositionAndRotation(wantedPosition, transform.rotation);
    }
}
