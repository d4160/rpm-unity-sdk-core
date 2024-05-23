using UnityEngine;
using UnityEngine.InputSystem;

namespace ReadyPlayerMe.AvatarCreator
{
    /// <summary>
    /// This class handles avatar rotation based on mouse input.
    /// </summary>
    public class MouseRotationHandler : MonoBehaviour, IAvatarRotatorInput
    {
        private const int MOUSE_BUTTON_INDEX = 0;
        private float lastPosX;
        private bool rotate;

        /// <summary>
        /// Checks if mouse input is detected for avatar rotation.
        /// </summary>
        /// <returns>True if mouse input is detected; otherwise, false.</returns>
        public bool IsInputDetected()
        {
            Mouse mouse = Mouse.current;
            if (mouse.leftButton.wasPressedThisFrame)
            {
                lastPosX = mouse.position.x.value;
                rotate = true;
            }
            // Input.GetMouseButtonUp(MOUSE_BUTTON_INDEX)
            else if (mouse.leftButton.wasReleasedThisFrame)
            {
                rotate = false;
            }

            return rotate;
        }

        public void SetRotate(bool rotate)
        {
            this.rotate = rotate;
        }

        /// <summary>
        /// Gets the rotation amount based on mouse input.
        /// </summary>
        /// <returns>The rotation amount as a float value.</returns>
        public float GetRotationAmount()
        {
            Mouse mouse = Mouse.current;
            var rotationAmount = lastPosX - mouse.position.x.value;
            lastPosX = mouse.position.x.value;
            return rotationAmount;
        }
    }
}
