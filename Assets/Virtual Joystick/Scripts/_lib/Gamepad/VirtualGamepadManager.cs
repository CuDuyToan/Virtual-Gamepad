using UnityEngine;
using System.Linq;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;

namespace VirtualGamepad
{
    public class VirtualGamepadManager : MonoBehaviour
    {
        public static VirtualGamepadDevice device;
        private static bool initialized;

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoad]
#endif
        public static class VirtualGamepadRegistration
        {
            static VirtualGamepadRegistration()
            {
                InputSystem.RegisterLayout<VirtualGamepadDevice>(
                    matches: new InputDeviceMatcher()
                        .WithInterface("VirtualGamepad"));
            }

            [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
            private static void Init()
            {
                if (InputSystem.GetDevice<VirtualGamepadDevice>() == null)
                {
                    InputSystem.AddDevice<VirtualGamepadDevice>();
                }
            }
        }

        void Awake()
        {
            Init();
        }

        private void Init()
        {
            if (initialized) return;
            initialized = true;

            if (!InputSystem.ListLayouts().Contains(nameof(VirtualGamepadDevice)))
            {
                InputSystem.RegisterLayout<VirtualGamepadDevice>(
                    matches: new InputDeviceMatcher()
                        .WithInterface("VirtualGamepad"));
            }

            device = InputSystem.GetDevice<VirtualGamepadDevice>();
            if (device == null)
            {
                device = InputSystem.AddDevice<VirtualGamepadDevice>();
            }
        }

        public static void SetStick(Vector2 value)
        {
            if (device != null)
            {
                InputSystem.QueueDeltaStateEvent(device.stick, value);
            }
        }

        public static void SetAction(bool pressed)
        {
            if (device != null)
            {
                InputSystem.QueueDeltaStateEvent(device.action, (byte)(pressed ? 1 : 0));
            }
        }

        public static void SetInteract(bool pressed)
        {
            if (device != null)
            {
                InputSystem.QueueDeltaStateEvent(device.interact, (byte)(pressed ? 1 : 0));
            }
        }
    }


}
