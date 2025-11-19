using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractUI : MonoBehaviour
{
    public static InteractUI instance;
    public bool MenuOpenCloseInput { get; private set; }
    public bool PauseGameInput { get; private set; }
    private PlayerInput _playerInput;
    private InputAction _menuOpenCloseAction;
    private InputAction _pauseGameAction;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.Log("instance == null");
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        _playerInput = GetComponent<PlayerInput>();
        if (_playerInput == null)
        {
            Debug.Log("Missing PlayerInput component!");
            return;
        }

        _menuOpenCloseAction = _playerInput.actions["Menu"];
        _pauseGameAction = _playerInput.actions["Pause"];
    }
    private void Update()
    {
        if (_menuOpenCloseAction != null)
            MenuOpenCloseInput = _menuOpenCloseAction.WasPressedThisFrame();

        if (_pauseGameAction != null)
            PauseGameInput = _pauseGameAction.WasPressedThisFrame();
    }
}
