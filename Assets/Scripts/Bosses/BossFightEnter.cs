using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
public class BossFightEnter : MonoBehaviour
{
    [SerializeField] private GameObject gate, gate2;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private Enemy Boss;
    [SerializeField] private GameObject BGMusic;
    private Collider2D collider;
    private static bool isStarted;
    private PixelPerfectCamera pp;
    private GameObject cam;
    private CameraFollow camFoll;
    private GameObject _player;

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

    private void Update()
    {
        if (isStarted)
        {
            healthBar.SetHealth(Boss.CurrHealth);
        }
    }

    private void FixedUpdate()
    {
        if (isStarted && pp.assetsPPU > 24) pp.assetsPPU--;
        else if (!isStarted && pp.assetsPPU < 32) pp.assetsPPU++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            gate.transform.position = new Vector3(gate.transform.position.x, gate.transform.position.y - 2f, gate.transform.position.z);
            gate2.transform.position = new Vector3(gate2.transform.position.x, gate2.transform.position.y - 2f, gate2.transform.position.z);
            collider.enabled = false;
            isStarted = true;
            healthBar.gameObject.SetActive(isStarted);
        }
    }
    public void ReOpenGates(float time)
    {
        StartCoroutine(ReOpenGatesTimer(time));
    }
    public IEnumerator ReOpenGatesTimer (float time)
    {
        yield return new WaitForSeconds(time);
        camFoll.Player = _player;
        gate.SetActive(false);
        gate2.SetActive(false);
        isStarted = false;
        healthBar.gameObject.SetActive(false);
    }
    public void QueueMusic()
    {
        BGMusic.gameObject.GetComponent<AudioSource>().Play();
    }
}
