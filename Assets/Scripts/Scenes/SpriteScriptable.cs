using UnityEngine;

[CreateAssetMenu(menuName = "UI/Sprites", fileName = "Sprite")]

public class SpriteScriptable : ScriptableObject
{
    [SerializeField] private Sprite[] _sprites = null;

    public Sprite[] sprites => _sprites;
}


