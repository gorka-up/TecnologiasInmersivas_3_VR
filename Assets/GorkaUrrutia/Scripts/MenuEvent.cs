using UnityEngine;
using UnityEngine.InputSystem;

public class MenuEvent : MonoBehaviour
{
    [SerializeField] private InputActionReference menuActionReference;

    private void OnEnable()
    {
        // Suscribirse al evento 'performed' (cuando se pulsa el bot�n)
        menuActionReference.action.performed += OnMenuButtonPressed;
    }

    private void OnDisable()
    {
        // Desuscribirse para evitar errores de memoria
        menuActionReference.action.performed -= OnMenuButtonPressed;
    }

    private void OnMenuButtonPressed(InputAction.CallbackContext context)
    {
        print("Pulso");
        if (GameManager.instance.pausaActive)
        {
            GameManager.instance.Reanudar();
        }
        else
        {
            GameManager.instance.Pausar();
        }
    }
}
