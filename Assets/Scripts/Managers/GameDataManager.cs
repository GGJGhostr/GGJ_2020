using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    static private GameDataManager instance = null;
    static public GameDataManager Instance
    {
        get
        {
            if (!instance)
                instance = new GameDataManager();
            return instance;
        }
    }

    public Bullet_Data BulletData { get; private set; }
    public Wall_Data WallData { get; private set; }
    public Character_Data CharacterData { get; private set; }

    private void Awake()
    {
        if (FindObjectsOfType<GameDataManager>().Length > 1)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        instance = this;

        CreateDatas();
    }

    public void CreateDatas()
    {
        BulletData = new Bullet_Data();
        WallData = new Wall_Data();
        CharacterData = new Character_Data();
    }

    public void ResetDatas()
    {
        BulletData.Reset();
        WallData.Reset();
        CharacterData.Reset();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class Bullet_Data
{
    private const float speed = 250f;
    private const float size = 1f;
    private const bool ricochet = false;
    private const bool visible = true;

    public float uSpeed = 250f;
    public float uSize = 1f;
    public bool uRicochet = false;
    public bool uVisible = true;

    public void Reset()
    {
        uSpeed = speed;
        uSize = size;
        uRicochet = ricochet;
        uVisible = visible;
    }
}

public class Wall_Data
{
    private const bool visible = true;

    public bool uVisible = true;

    public void Reset()
    {
        uVisible = visible;
    }
}

public class Character_Data
{
    private const bool visible = true;
    private const float speed = 13f;

    public bool uVisible = true;
    public float uSpeed = 13f;

    public void Reset()
    {
        uVisible = visible;
        uSpeed = speed;
    }
}