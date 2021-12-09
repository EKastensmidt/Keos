using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;


public class BossFight3Enter : MonoBehaviour
{
    [SerializeField] private GameObject gate;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private GameObject BGMusic;
    [SerializeField] private Enemy Boss;

    private static bool isStarted;
    private Collider2D collider;
    private PixelPerfectCamera pp;
    private GameObject cam;
    private GameObject _player;
    private CameraFollow camFoll;

    public static bool IsStarted { get => isStarted; set => isStarted = value; }

    void Start()
    {
        collider = GetComponent<Collider2D>();
        healthBar.SetMaxHealth(Boss.MaxHealth);
        isStarted = false;
        _player = GameObject.Find("Maguito");
        cam = GameObject.Find("Main Camera");
        pp = cam.GetComponent<PixelPerfectCamera>();
        camFoll = cam.GetComponent<CameraFollow>();
    }

    void Update()
    {
        if (isStarted)
        {
            healthBar.SetHealth(Boss.CurrHealth);
        }
    }

    private void FixedUpdate()
    {
        if (isStarted && pp.assetsPPU > 16) pp.assetsPPU--;
        else if (!isStarted && pp.assetsPPU < 32) pp.assetsPPU++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            gate.transform.position = new Vector3(gate.transform.position.x, gate.transform.position.y - 3f, gate.transform.position.z);
            BGMusic.SetActive(true);
            healthBar.gameObject.SetActive(true);
            collider.enabled = false;
            isStarted = true;
        }
    }
}
