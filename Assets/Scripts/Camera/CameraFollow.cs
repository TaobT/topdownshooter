using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private Vector2 limit;
    public Vector3 position;

    private void Update()
    {
        position = Vector3.Lerp(InputManager.MousePos, playerTransform.position, 0.9f);
        position.x = Mathf.Clamp(position.x, playerTransform.position.x - limit.x, playerTransform.transform.position.x + limit.x);
        position.y = Mathf.Clamp(position.y, playerTransform.position.y - limit.y, playerTransform.transform.position.y + limit.y);
        transform.position = new Vector3(position.x, position.y, -10);
    }
}
