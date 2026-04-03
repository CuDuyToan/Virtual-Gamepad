using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.Controls;

namespace VirtualGamepad
{
    [InputControlLayout(displayName = "Virtual Gamepad")]
    public class VirtualGamepadDevice : InputDevice
    {
        [InputControl(layout = "Vector2")]
        public Vector2Control stick { get; private set; }

        [InputControl(name = "action", layout = "Button")]
        public ButtonControl action { get; private set; }

        [InputControl(name = "interact", layout = "Button")]
        public ButtonControl interact { get; private set; }

        protected override void FinishSetup()
        {
            base.FinishSetup();
            stick = GetChildControl<Vector2Control>("stick");
            action = GetChildControl<ButtonControl>("action");
            interact = GetChildControl<ButtonControl>("interact");

        }
    }
}