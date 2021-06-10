using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float smoothSpeed = 0.125f;
    [SerializeField] private Vector3 offset = new Vector3(0, 0, -1);
    [SerializeField] private GameObject player;
    private Vector3 mousePosition;
    private Vector3 playerPosition;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        //transform.position = Vector3.Lerp(transform.position, target.position + offset, smoothSpeed);
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        playerPosition = player.transform.position;
        Vector3 newPos = FollowMouse(mousePosition, playerPosition);

        transform.position = Vector3.Lerp(newPos, playerPosition + offset, smoothSpeed);
    }

    private Vector3 FollowMouse(Vector3 a, Vector3 b) {
        Vector3 c = (a + b)/2;
        Vector3 newPos = new Vector3((b.x + c.x) / 2, (b.y + c.y) / 2, transform.position.z);
        return newPos;
    }
}
