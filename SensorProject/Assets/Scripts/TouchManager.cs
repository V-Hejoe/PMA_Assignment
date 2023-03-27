using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchManager : MonoBehaviour
{
    //Based on "How to use TOUCH with the Input System in Unity" by samyam: https://www.youtube.com/watch?v=4MOOitENQVg
    public GameObject dataManager;
    DataManager dm;
    
    private PlayerInput playerInput;
    private InputAction touchPressAction;

    private void Awake()
    {
        dm = dataManager.GetComponent<DataManager>();
        playerInput = GetComponent<PlayerInput>();
        touchPressAction = playerInput.actions["TouchPress"];
    }

    private void OnEnable()
    {
        touchPressAction.performed += TouchPressed;
    }

    private void OnDisable()
    {
        touchPressAction.performed -= TouchPressed;
    }

    private void TouchPressed(InputAction.CallbackContext context)
    {
        dm.UpdateTextFile();
    }
}
