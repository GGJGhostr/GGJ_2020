using UnityEngine;

[CreateAssetMenu(menuName = "UI/Sprites", fileName = "Sprite")]

public class SpriteScriptable : ScriptableObject
{
    [SerializeField] private Sprite[] _sprites = null;

    public Sprite[] sprites => _sprites;
}

[CreateAssetMenu(menuName = "UI/String", fileName = "String")]

public class StringScriptable : ScriptableObject
{
    [SerializeField] private string[] _strings = null;

    public string[] strings => _strings;
}
