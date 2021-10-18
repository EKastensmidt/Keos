using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject _player;
    private PlayerManager _playerManager;
    private PlayerController _playerController;
    private CharacterDialogManager dialogueManager;

    private static bool isBossFight = false;
    private static bool isWaterUnlocked = false;
    private static bool isEarthUnlocked = false;


    private Vector3 currCheckpoint;
    private string currScene;

    public Vector3 CurrCheckpoint { get => currCheckpoint; set => currCheckpoint = value; }
    public static bool IsWaterUnlocked { get => isWaterUnlocked; set => isWaterUnlocked = value; }
    public static bool IsEarthUnlocked { get => isEarthUnlocked; set => isEarthUnlocked = value; }
    public static bool IsBossFight { get => isBossFight; set => isBossFight = value; }

    void Start()
    {
        currScene = SceneManager.GetActiveScene().name;
        StageCheck.Check(currScene);
        _player = GameObject.Find("Maguito");
        _playerManager = _player.GetComponent<PlayerManager>();
        _playerController = _player.GetComponent<PlayerController>();
        currCheckpoint = _player.transform.position;
        GameObject newDialogueManager = GameObject.Find("NewDialogueManager");
        if (newDialogueManager != null)
            dialogueManager = newDialogueManager.GetComponent<CharacterDialogManager>();
    }

    void Update()
    {
        if (dialogueManager.IsInDialogue)
            _playerController.IsAbleMove = false;
        else
            _playerController.IsAbleMove = true;

        if (Input.GetKeyDown(KeyCode.F))
        {
            dialogueManager.PlayNextSentence();
        }
        
        StageCheck.SceneInputs();

        if (_playerManager.CurrentHealth <= 0 && !isBossFight)
        {
            _player.transform.position = new Vector3(currCheckpoint.x, currCheckpoint.y, 0);
            _playerManager.CurrentHealth = _playerManager.MaxHealth;
            _playerManager.HealthBar.SetHealth(_playerManager.CurrentHealth);
        }
        else if (_playerManager.CurrentHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
