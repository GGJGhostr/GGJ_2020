﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IHackable
{
    private SpriteRenderer m_spriteRenderer = null;

    [SerializeField] float m_projectileSpeed = 50f;
    [SerializeField] float m_projectileSize = 1f;
    [SerializeField] float m_timer = 10f;
    [SerializeField] bool m_ricochet = false;
    [SerializeField] bool m_traverse = false;

    private Vector2 m_dir = Vector2.zero;
    private Rigidbody2D m_rigidbody2D = null;
    private bool is_fired = false;

    private Character m_owner = null;

    private Bullet_Data bData = null;

    public GameObject explosion_prefab;

    private void Awake()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();

        bData = GameDataManager.Instance.BulletData;

        m_projectileSize = bData.uSize;
        m_projectileSpeed = bData.uSpeed;
        m_spriteRenderer.enabled = bData.uVisible;
        m_ricochet = bData.uRicochet;
        m_traverse = bData.uTraverse;
        if (m_traverse)
            gameObject.layer = LayerMask.NameToLayer("ThroughWall");
        else
            gameObject.layer = LayerMask.NameToLayer("Bullet");
    }

    public void ComputeHackFromString(string data, dynamic value)
    {

        switch(data)
        {
            case "visible":
                if (value == null)
                    m_spriteRenderer.enabled = !m_spriteRenderer.enabled;
                else
                    m_spriteRenderer.enabled = value;

                bData.uVisible = m_spriteRenderer.enabled;

                break;

            case "speed":
                m_projectileSpeed = value;
                bData.uSpeed = value;
                break;


            case "traverse":
                if(value == null)
                {
                    m_traverse = !m_traverse;
                    bData.uTraverse = m_traverse;
                }
                else
                {
                    m_traverse = value;
                    bData.uTraverse = value;
                }
                if (m_traverse)
                    gameObject.layer = LayerMask.NameToLayer("ThroughWall");
                else
                    gameObject.layer = LayerMask.NameToLayer("Bullet");
                break;

            default:
                break;
        }

    }

    public void Fire(Vector2 dir, Character owner)
    {
        m_owner = owner;
        m_dir = dir;
        m_rigidbody2D.AddForce(m_dir * m_projectileSpeed);
        is_fired = true;
    }


    private void Update()
    {
        //if(is_fired)
        //{
        //    Vector2 position = new Vector2(transform.position.x, transform.position.y);
        //    position = position + (m_dir * m_projectileSize * Time.deltaTime);
        //    transform.position = new Vector3(position.x, position.y, 0.0f);
        //}
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject != m_owner.gameObject)
        {
            if(collision.gameObject.tag == "player")
            {
                CharacterScoring scoring = m_owner.GetComponent<CharacterScoring>();
                scoring.incrementScore();
            }
        }

        //Instance prefab for explosion
        Instantiate(explosion_prefab, transform.position, Random.rotation );

        Destroy(gameObject);
    }

}
