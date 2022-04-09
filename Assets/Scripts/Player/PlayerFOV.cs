using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFOV : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;

    private void Update() => SetPositionAndRotation();

    private void SetPositionAndRotation()
    {
        transform.position = playerTransform.position;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, PlayerLook.rotationZ);
    }
}
