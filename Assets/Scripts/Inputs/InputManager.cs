using UnityEngine;

public class InputManager : MonoBehaviour
{
    public enum ButtonState
    {
        None,
        PressedDown,
        Released,
        Held
    }

    [SerializeField] TouchButton leftButton;
    [SerializeField] TouchButton rightButton;
    [SerializeField] TouchButton downButton;


    public float HorizontalInput
    {
        get
        {
            if (leftButton.CurrentState == ButtonState.Held || leftButton.CurrentState == ButtonState.PressedDown)
            {
                return -1;
                //print("moving");
            }
            else if (rightButton.CurrentState == ButtonState.Held || rightButton.CurrentState == ButtonState.PressedDown)
            {
                return 1;
            }
            return Input.GetAxisRaw("Horizontal");
        }
    }
    public float VerticalInput
    {
        get
        {
            if (downButton.CurrentState == ButtonState.Held || downButton.CurrentState == ButtonState.PressedDown)
            {
                return -1;
                //print("moving");
            }
            return Input.GetAxisRaw("Vertical");
        }
    }

    public Vector3 MovementInput
    {
        get
        {
            return new Vector3(HorizontalInput, VerticalInput, 0);
        }
    }
}