//Author: Richard Pieterse
//Latest Update: Xu Wang

using UnityEngine;
using System.Collections;

namespace GamepadInput
{

    public static class GamePad
    {

        public enum Button { A, B, Y, X, RightShoulder, LeftShoulder, RightStick, LeftStick, Back, Start }
        public enum Trigger { LeftTrigger, RightTrigger }
        public enum Axis { LeftStick, RightStick, Dpad }
        public enum PlayerIndex { Any, One, Two, Three, Four }

        public static bool GetButtonDown(Button button, PlayerIndex controlPlayerIndex)
        {
            KeyCode code = GetKeycode(button, controlPlayerIndex);
            return Input.GetKeyDown(code);
        }

        public static bool GetButtonUp(Button button, PlayerIndex controlPlayerIndex)
        {
            KeyCode code = GetKeycode(button, controlPlayerIndex);
            return Input.GetKeyUp(code);
        }

        public static bool GetButton(Button button, PlayerIndex controlPlayerIndex)
        {
            KeyCode code = GetKeycode(button, controlPlayerIndex);
            return Input.GetKey(code);
        }

        /// <summary>
        /// returns a specified axis
        /// </summary>
        /// <param name="axis">One of the analogue sticks, or the dpad</param>
        /// <param name="controlPlayerIndex">The controller number</param>
        /// <param name="raw">if raw is false then the controlPlayerIndex will be returned with a deadspot</param>
        /// <returns></returns>
        public static Vector2 GetAxis(Axis axis, PlayerIndex controlPlayerIndex, bool raw = false)
        {

            string xName = "", yName = "";
            switch (axis)
            {
                case Axis.Dpad:
                    xName = "DPad_XAxis_" + (int)controlPlayerIndex;
                    yName = "DPad_YAxis_" + (int)controlPlayerIndex;
                    break;
                case Axis.LeftStick:
                    xName = "L_XAxis_" + (int)controlPlayerIndex;
                    yName = "L_YAxis_" + (int)controlPlayerIndex;
                    break;
                case Axis.RightStick:
                    xName = "R_XAxis_" + (int)controlPlayerIndex;
                    yName = "R_YAxis_" + (int)controlPlayerIndex;
                    break;
            }

            Vector2 axisXY = Vector3.zero;

            try
            {
                if (raw == false)
                {
                    axisXY.x = Input.GetAxis(xName);
                    axisXY.y = -Input.GetAxis(yName);
                }
                else
                {
                    axisXY.x = Input.GetAxisRaw(xName);
                    axisXY.y = -Input.GetAxisRaw(yName);
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError(e);
                Debug.LogWarning("Have you set up all axes correctly? \nThe easiest solution is to replace the InputManager.asset with version located in the GamepadInput package. \nWarning: do so will overwrite any existing input");
            }
            return axisXY;
        }

        public static float GetTrigger(Trigger trigger, PlayerIndex controlPlayerIndex, bool raw = false)
        {
            //
            string name = "";
            if (trigger == Trigger.LeftTrigger)
                name = "TriggersL_" + (int)controlPlayerIndex;
            else if (trigger == Trigger.RightTrigger)
                name = "TriggersR_" + (int)controlPlayerIndex;

            //
            float axis = 0;
            try
            {
                if (raw == false)
                    axis = Input.GetAxis(name);
                else
                    axis = Input.GetAxisRaw(name);
            }
            catch (System.Exception e)
            {
                Debug.LogError(e);
                Debug.LogWarning("Have you set up all axes correctly? \nThe easiest solution is to replace the InputManager.asset with version located in the GamepadInput package. \nWarning: do so will overwrite any existing input");
            }
            return axis;
        }


        static KeyCode GetKeycode(Button button, PlayerIndex controlPlayerIndex)
        {
            switch (controlPlayerIndex)
            {
                case PlayerIndex.One:
                    switch (button)
                    {
                        case Button.A: return KeyCode.Joystick1Button0;
                        case Button.B: return KeyCode.Joystick1Button1;
                        case Button.X: return KeyCode.Joystick1Button2;
                        case Button.Y: return KeyCode.Joystick1Button3;
                        case Button.RightShoulder: return KeyCode.Joystick1Button5;
                        case Button.LeftShoulder: return KeyCode.Joystick1Button4;
                        case Button.Back: return KeyCode.Joystick1Button6;
                        case Button.Start: return KeyCode.Joystick1Button7;
                        case Button.LeftStick: return KeyCode.Joystick1Button8;
                        case Button.RightStick: return KeyCode.Joystick1Button9;
                    }
                    break;
                case PlayerIndex.Two:
                    switch (button)
                    {
                        case Button.A: return KeyCode.Joystick2Button0;
                        case Button.B: return KeyCode.Joystick2Button1;
                        case Button.X: return KeyCode.Joystick2Button2;
                        case Button.Y: return KeyCode.Joystick2Button3;
                        case Button.RightShoulder: return KeyCode.Joystick2Button5;
                        case Button.LeftShoulder: return KeyCode.Joystick2Button4;
                        case Button.Back: return KeyCode.Joystick2Button6;
                        case Button.Start: return KeyCode.Joystick2Button7;
                        case Button.LeftStick: return KeyCode.Joystick2Button8;
                        case Button.RightStick: return KeyCode.Joystick2Button9;
                    }
                    break;
                case PlayerIndex.Three:
                    switch (button)
                    {
                        case Button.A: return KeyCode.Joystick3Button0;
                        case Button.B: return KeyCode.Joystick3Button1;
                        case Button.X: return KeyCode.Joystick3Button2;
                        case Button.Y: return KeyCode.Joystick3Button3;
                        case Button.RightShoulder: return KeyCode.Joystick3Button5;
                        case Button.LeftShoulder: return KeyCode.Joystick3Button4;
                        case Button.Back: return KeyCode.Joystick3Button6;
                        case Button.Start: return KeyCode.Joystick3Button7;
                        case Button.LeftStick: return KeyCode.Joystick3Button8;
                        case Button.RightStick: return KeyCode.Joystick3Button9;
                    }
                    break;
                case PlayerIndex.Four:

                    switch (button)
                    {
                        case Button.A: return KeyCode.Joystick4Button0;
                        case Button.B: return KeyCode.Joystick4Button1;
                        case Button.X: return KeyCode.Joystick4Button2;
                        case Button.Y: return KeyCode.Joystick4Button3;
                        case Button.RightShoulder: return KeyCode.Joystick4Button5;
                        case Button.LeftShoulder: return KeyCode.Joystick4Button4;
                        case Button.Back: return KeyCode.Joystick4Button6;
                        case Button.Start: return KeyCode.Joystick4Button7;
                        case Button.LeftStick: return KeyCode.Joystick4Button8;
                        case Button.RightStick: return KeyCode.Joystick4Button9;
                    }

                    break;
                case PlayerIndex.Any:
                    switch (button)
                    {
                        case Button.A: return KeyCode.JoystickButton0;
                        case Button.B: return KeyCode.JoystickButton1;
                        case Button.X: return KeyCode.JoystickButton2;
                        case Button.Y: return KeyCode.JoystickButton3;
                        case Button.RightShoulder: return KeyCode.JoystickButton5;
                        case Button.LeftShoulder: return KeyCode.JoystickButton4;
                        case Button.Back: return KeyCode.JoystickButton6;
                        case Button.Start: return KeyCode.JoystickButton7;
                        case Button.LeftStick: return KeyCode.JoystickButton8;
                        case Button.RightStick: return KeyCode.JoystickButton9;
                    }
                    break;
            }
            return KeyCode.None;
        }

        public static GamepadState GetState(PlayerIndex controlPlayerIndex, bool raw = false)
        {
            GamepadState state = new GamepadState();

            state.A = GetButton(Button.A, controlPlayerIndex);
            state.B = GetButton(Button.B, controlPlayerIndex);
            state.Y = GetButton(Button.Y, controlPlayerIndex);
            state.X = GetButton(Button.X, controlPlayerIndex);

            state.RightShoulder = GetButton(Button.RightShoulder, controlPlayerIndex);
            state.LeftShoulder = GetButton(Button.LeftShoulder, controlPlayerIndex);
            state.RightStick = GetButton(Button.RightStick, controlPlayerIndex);
            state.LeftStick = GetButton(Button.LeftStick, controlPlayerIndex);

            state.Start = GetButton(Button.Start, controlPlayerIndex);
            state.Back = GetButton(Button.Back, controlPlayerIndex);

            state.LeftStickAxis = GetAxis(Axis.LeftStick, controlPlayerIndex, raw);
            state.rightStickAxis = GetAxis(Axis.RightStick, controlPlayerIndex, raw);
            state.dPadAxis = GetAxis(Axis.Dpad, controlPlayerIndex, raw);

            state.Left = (state.dPadAxis.x < 0);
            state.Right = (state.dPadAxis.x > 0);
            state.Up = (state.dPadAxis.y > 0);
            state.Down = (state.dPadAxis.y < 0);

            state.LeftTrigger = GetTrigger(Trigger.LeftTrigger, controlPlayerIndex, raw);
            state.RightTrigger = GetTrigger(Trigger.RightTrigger, controlPlayerIndex, raw);

            return state;
        }

    }

    public class GamepadState
    {
        public bool A = false;
        public bool B = false;
        public bool X = false;
        public bool Y = false;
        public bool Start = false;
        public bool Back = false;
        public bool Left = false;
        public bool Right = false;
        public bool Up = false;
        public bool Down = false;
        public bool LeftStick = false;
        public bool RightStick = false;
        public bool RightShoulder = false;
        public bool LeftShoulder = false;

        public Vector2 LeftStickAxis = Vector2.zero;
        public Vector2 rightStickAxis = Vector2.zero;
        public Vector2 dPadAxis = Vector2.zero;

        public float LeftTrigger = 0;
        public float RightTrigger = 0;

    }

}