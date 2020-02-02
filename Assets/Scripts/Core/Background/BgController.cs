using UnityEngine;

public class BgController : MonoBehaviour
{
    public GameObject[] cloud_prefab;
    public int fix_start_pos;
    public int cloud_num_scale = 2;
    private GameObject[] cloud_obj;
    public Vector2 cloud_random_range_Y;
    public Vector2 cloud_random_range_X;
    public Vector2 cloud_random_range_speed;

    private Vector3[] startPos;
    public float speed = -10.0f;
    public float cycle_length = 30.0f;
    public float smoothTime = 0.3F;

    private Vector3 velocity = Vector3.zero;

    private void RandCloudPos(int idx)
    {
        float random_seed = Random.Range(cloud_random_range_speed.x, cloud_random_range_speed.y);
        float cloud_x = Random.Range(cloud_random_range_X.x, cloud_random_range_X.y);
        float cloud_y = Random.Range(cloud_random_range_Y.x, cloud_random_range_Y.y);
        startPos[idx] = new Vector3(cloud_x, cloud_y, 0.0f);
        cloud_obj[idx].transform.position = startPos[idx];
    }

    private void init()
    {
        cloud_obj = new GameObject[cloud_prefab.Length * cloud_num_scale];
        startPos = new Vector3[cloud_prefab.Length * cloud_num_scale];
        for (int i = 0; i < cloud_prefab.Length * cloud_num_scale; i++)
        {
            cloud_obj[i] = GameObject.Instantiate(cloud_prefab[i % cloud_prefab.Length], Vector3.zero, Quaternion.identity);
            RandCloudPos(i);
        }
    }
    void Awake()
    {
        init();
    }

    private void UpdateCloudPos()
    {
        if (cloud_obj[0] == null)
        {
            init();
        }

        for (int i = 0; i < cloud_obj.Length; i++)
        {
            float random_seed = Random.Range(cloud_random_range_speed.x, cloud_random_range_speed.y);
            Vector3 target = new Vector3(cloud_obj[i].transform.position.x + speed * random_seed, cloud_obj[i].transform.position.y, 0.0f);
            cloud_obj[i].transform.position = Vector3.SmoothDamp(cloud_obj[i].transform.position, target, ref velocity, smoothTime);
            float move_length = Mathf.Abs(cloud_obj[i].transform.position.x - startPos[i].x);
            if (move_length > cycle_length + (startPos[i].x - fix_start_pos))
            {
                RandCloudPos(i);
            }
        }
    }

    void Update()
    {
        UpdateCloudPos();
    }
}
