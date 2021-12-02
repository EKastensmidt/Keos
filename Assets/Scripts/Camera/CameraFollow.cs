using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float moveRange = 0.125f;
    [SerializeField] private Vector3 offset = new Vector3(0, 0, 0);
    [SerializeField] private GameObject player;
    private Vector3 mousePosition;
    private Vector3 playerPosition;
    [SerializeField] private float deadZone;
    [SerializeField] private float smoothSpeed = 0.125f;

    public GameObject Player { get => player; set => player = value; }

    private PixelPerfectCamera pixelPerfectCamera;
    private int currentPixels = 0;

    void Start()
    {
        pixelPerfectCamera = GetComponent<PixelPerfectCamera>();
        currentPixels = pixelPerfectCamera.assetsPPU;
    }

    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (player == null)
        {
            return;
        }

        playerPosition = player.transform.position;
        Vector3 segment = mousePosition - playerPosition;
        if (segment.magnitude < deadZone)
            mousePosition = playerPosition;
        Vector3 newPos = FollowMouse(mousePosition, playerPosition);

        transform.position = Vector3.Lerp(transform.position, Vector3.Lerp(newPos, playerPosition + offset, moveRange), smoothSpeed);

        if (GameManager.IsEarthUnlocked && !GameManager.IsBossFight)
        {
            if(Input.GetAxis("Mouse ScrollWheel") > 0f && currentPixels < 32)
            {
                currentPixels++;
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0f && currentPixels > 20)
            {
                currentPixels--;
            }
        }
        pixelPerfectCamera.assetsPPU = currentPixels;
    }

    private Vector3 FollowMouse(Vector3 a, Vector3 b) {
        Vector3 c = (a + b)/2;
        Vector3 newPos = new Vector3((b.x + c.x) / 2, (b.y + c.y) / 2, transform.position.z);
        return newPos;
    }
}
