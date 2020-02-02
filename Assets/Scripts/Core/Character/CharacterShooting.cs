using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShooting : MonoBehaviour
{
    [SerializeField] Transform m_frontBulletSpawner = null;
    [SerializeField] Transform m_backBulletSpawner = null;
    [SerializeField] GameObject m_bulletPrefab = null;

    CharacterMovementB  m_characterMovement = null;

    private void Awake()
    {
        m_characterMovement = GetComponent<CharacterMovementB>();
    }

    public void ShootBullet(Vector2 dir)
    {
        Vector3 spawner_pos = m_frontBulletSpawner.position;


        bool is_facing_right = m_characterMovement.facingRight;
        if(is_facing_right)
        {
            if (dir.x < 0f)
                spawner_pos = m_backBulletSpawner.position;
            else if (dir.x == 0)
                dir.x = 1f;
        }
        else if(!is_facing_right)
        {
            if (dir.x == 0)
                dir.x = -1f;
            else if (dir.x > 0)
                spawner_pos = m_backBulletSpawner.position;
        }

        //if (dir.x > 0 && !is_facing_right)
        //    spawner_pos = m_backBulletSpawner.position;
        //else if (dir.x < 0 && is_facing_right)
        //    spawner_pos = m_backBulletSpawner.position;


        //if(!m_characterController.m_FacingRight)
        //    dir.x *= -1;
        //if (dir == Vector2.zero)
        //{
        //    dir = new Vector2(transform.right.x, 0f);
        //    if (!m_characterController.m_FacingRight)
        //        dir *= -1f;
        //}

        Vector2 forward_vec = transform.right;
        if (!is_facing_right)
            forward_vec *= -1f;

        float angle = Vector2.Angle(forward_vec, dir);
        Quaternion quat = Quaternion.AngleAxis(angle, Vector3.forward);
        GameObject clone = Instantiate(m_bulletPrefab, spawner_pos, quat);
        clone.GetComponent<Bullet>().Fire(dir, GetComponent<Character>());

        PlayerSound pl_s = GetComponent<PlayerSound>();
        pl_s.playShoot();

        //bullet.Fire(dir);
    }
}
