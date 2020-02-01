//Author: Richard Pieterse
//Latest Update: Xu Wang

using UnityEngine;
using GamepadInput;

public class Debug_Inputs : MonoBehaviour
{


    void Examples()
    {
        GamePad.GetButtonDown (GamePad.Button.A, GamePad.PlayerIndex.One);
        GamePad.GetAxis(GamePad.Axis.LeftStick, GamePad.PlayerIndex.One);
        GamePad.GetTrigger(GamePad.Trigger.RightTrigger, GamePad.PlayerIndex.One);

        GamepadState state = GamePad.GetState(GamePad.PlayerIndex.One);

        print("A: " + state.A);
    }

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(0, 20, Screen.width, Screen.height));

        GUILayout.BeginHorizontal();

        GUILayout.FlexibleSpace();

        DrawLabels();

        for (int i = 0; i < 3; i++)
            DrawState((GamePad.PlayerIndex)i);
        GUILayout.FlexibleSpace();

        GUILayout.EndHorizontal();

        GUILayout.EndArea();

    }


    void DrawState(GamePad.PlayerIndex controller)
    {
        GUILayout.Space(45);

        GUILayout.BeginVertical();
        
        
        GamepadState state = GamePad.GetState(controller);

        // buttons
        GUILayout.Label("Gamepad " + controller);
        GUILayout.Label("" + state.A);
        GUILayout.Label("" + state.B);
        GUILayout.Label("" + state.X);
        GUILayout.Label("" + state.Y);
        GUILayout.Label("" + state.Start);
        GUILayout.Label("" + state.Back);
        GUILayout.Label("" + state.LeftShoulder);
        GUILayout.Label("" + state.RightShoulder);
        GUILayout.Label("" + state.Left);
        GUILayout.Label("" + state.Right);
        GUILayout.Label("" + state.Up);
        GUILayout.Label("" + state.Down);
        GUILayout.Label("" + state.LeftStick);
        GUILayout.Label("" + state.RightStick);

        GUILayout.Label("");

        // triggers
        GUILayout.Label("" + System.Math.Round(state.LeftTrigger, 2));
        GUILayout.Label("" +  System.Math.Round(state.RightTrigger, 2));

        GUILayout.Label("");

        // Axes
        GUILayout.Label("" + state.LeftStickAxis);
        GUILayout.Label("" + state.rightStickAxis);
        GUILayout.Label("" + state.dPadAxis);
        

        //GUILayout.EndArea();
        GUILayout.EndVertical();

    }

    void DrawLabels()
    {
        //GUILayout.BeginArea(new Rect(30, 0, width - 30, Screen.height));

        GUILayout.BeginVertical();
        // buttons
        GUILayout.Label(" ", GUILayout.Width(80));
        GUILayout.Label("A");
        GUILayout.Label("B");
        GUILayout.Label("X");
        GUILayout.Label("Y");
        GUILayout.Label("Start");
        GUILayout.Label("Back");
        GUILayout.Label("Left Shoulder");
        GUILayout.Label("Right Shoulder");
        GUILayout.Label("Left");
        GUILayout.Label("Right");
        GUILayout.Label("Up");
        GUILayout.Label("Down");
        GUILayout.Label("LeftStick");
        GUILayout.Label("RightStick");

        GUILayout.Label("");

        GUILayout.Label("LeftTrigger");
        GUILayout.Label("RightTrigger");

        GUILayout.Label("");

        GUILayout.Label("LeftStickAxis");
        GUILayout.Label("rightStickAxis");
        GUILayout.Label("dPadAxis");

        GUILayout.EndVertical();

    }
}
