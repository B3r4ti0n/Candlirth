using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;
    private void LateUpdate() {
        if (Player != null) {
            Vector3 desiredPosition = Player.position + offset;

            Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            transform.position = smoothPosition;
        }
    }
}
