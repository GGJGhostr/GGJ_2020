//Author: Xu Wang
//Latest Update: Xu Wang

public enum PLAYER_INPUT_TYPE
{
    GamePad = 0,
    KeyBoard = 1
}

public static class PlayerConfig
{
    public const int PLAYER_NUM = 2;
    public static PLAYER_INPUT_TYPE INPUT_TYPE = PLAYER_INPUT_TYPE.GamePad;
}


