using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IHackable
{
    [SerializeField] float m_projectileSpeed = 50f;
    [SerializeField] float m_projectileSize = 1f;
    [SerializeField] float m_timer = 10f;
    [SerializeField] bool m_ricochet = false;

    private Vector2 m_dir = Vector2.zero;
    private Rigidbody2D m_rigidbody2D = null;
    private bool is_fired = false;

    private void Awake()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void ComputeHackFromString(string data, dynamic value)
    {

    }

    public void Fire(Vector2 dir)
    {
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
        Debug.Log(collision.transform.name);
        Destroy(gameObject);
    }

}
