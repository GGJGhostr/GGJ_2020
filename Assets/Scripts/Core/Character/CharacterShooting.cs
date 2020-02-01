using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShooting : MonoBehaviour
{
    [SerializeField] Transform m_bulletSpawnerTransform = null;
    [SerializeField] GameObject m_bulletPrefab = null;

    private void Awake()
    {
        
    }

    public void ShootBullet(Vector2 dir)
    {
        if (dir == Vector2.zero)
            dir = new Vector2(transform.right.x, 0f);

        float angle = Vector2.Angle(new Vector2(transform.right.x, 0f), dir);
        Quaternion quat = Quaternion.AngleAxis(angle, Vector3.forward);
        GameObject clone = Instantiate(m_bulletPrefab, m_bulletSpawnerTransform.transform.position, quat);
        clone.GetComponent<Bullet>().Fire(dir);
        //bullet.Fire(dir);
    }
}
