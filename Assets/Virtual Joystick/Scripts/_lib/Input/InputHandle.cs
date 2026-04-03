using UnityEngine;
using UnityEngine.InputSystem;

namespace VirtualGamepad.Input
{
    public class InputHandle : MonoBehaviour
    {
        private ControllerInput controls;
        private Vector2 moveInput;

        private void Awake()
        {
            controls = new ControllerInput();

            controls.Default.Movement.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
            //controls.Default.Movement.performed += ctx => Movement();
            controls.Default.Movement.canceled += ctx => moveInput = Vector2.zero;

            controls.Default.Action.started += ctx => Debug.Log("Bắt đầu nhảy!");
            controls.Default.Action.performed += ctx => Jump();
            controls.Default.Action.canceled += ctx => Debug.Log("Ngừng nhảy!");
        }

        private void OnEnable()
        {
            controls.Enable();
        }

        private void OnDisable()
        {
            controls.Disable();
        }

        private void Update()
        {
            // Di chuyển
            transform.Translate(moveInput * Time.deltaTime * 5f);
        }

        private void Movement()
        {
            Debug.Log("Di chuyển!");
        }

        private void Jump()
        {
            Debug.Log("Nhảy!");
        }
    }

}