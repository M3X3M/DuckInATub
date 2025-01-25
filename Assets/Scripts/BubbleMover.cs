using System.Collections;
using UnityEngine;

public class BubbleMover : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private float _movementSpeed = 3f;
    [SerializeField] private float _borderPadding = 1f;
    [SerializeField] private int angle_range_half = 45;

    private Vector2 _camBounds;
    private bool in_motion = true;
    private enum Edge
    {
        Left,
        Top,
        Right,
        Bottom,
    }

    private struct SpawnPosition
    {
        public Vector2 Pos;
        public Quaternion Rot;
    }


    // Start is called before the first frame update
    void Start()
    {
        _camBounds = GameObject.Find("GameMaster").GetComponent<GameInfo>().GetCameraSizes();
        SpawnPosition props = CalcSpawnProperties();
        transform.position = new Vector3(props.Pos.x, 0f, props.Pos.y);
        transform.rotation = props.Rot;
    }

    // Update is called once per frame
    void Update()
    {
        // Moving the object
        // this assumes that the object faces left on rotation 0
        if(in_motion)
        {
            transform.position += _movementSpeed * Time.deltaTime * transform.forward;
        }

        if(
            transform.position.x > _camBounds.x ||
            transform.position.x < -_camBounds.x ||
            transform.position.z > _camBounds.y ||
            transform.position.z < -_camBounds.y
        )
        {
            Destroy(gameObject);
        }
    }

    private SpawnPosition CalcSpawnProperties()
    {
        SpawnPosition new_spawn_pos = new SpawnPosition();

        // picking on what "screen edge" the object will spawn
        int new_edge = Random.Range(0, 3);

        // cam_bounds gives us the whole width/height but we need to half it
        float half_cam_width = this._camBounds.x / 2f;
        float half_cam_height = this._camBounds.y / 2f;

        // new rotation that will be set
        int face_center;

        // The object will sometimes not go on screen because it could have
        // exactly 90 degress for example but we keep it like that to have another
        // element of randomness
        switch (new_edge)
        {
            case (int)Edge.Left:
            {
                new_spawn_pos.Pos.x = -(half_cam_width + this._borderPadding);
                new_spawn_pos.Pos.y = Random.Range(-half_cam_height, half_cam_height);
                face_center = 90;
                break;
            }

            case (int)Edge.Top:
            {
                new_spawn_pos.Pos.y = half_cam_height + this._borderPadding;
                new_spawn_pos.Pos.x = Random.Range(-half_cam_width, half_cam_width);
                face_center = 180;
                break;
            }

            case (int)Edge.Right:
            {
                new_spawn_pos.Pos.x = half_cam_width + this._borderPadding;
                new_spawn_pos.Pos.y = Random.Range(-half_cam_height, half_cam_height);
                face_center = 270;
                break;
            }

            case (int)Edge.Bottom:
            {
                new_spawn_pos.Pos.y = -(half_cam_height + this._borderPadding);
                new_spawn_pos.Pos.x = Random.Range(-half_cam_width, half_cam_width);
                face_center = 0;
                break;
            }

            default:
            {
                // should not be possible, moving the object far away
                new_spawn_pos.Pos.x = this._camBounds.x;
                new_spawn_pos.Pos.y = this._camBounds.y;
                face_center = 0;
                break;
            }
        }

        new_spawn_pos.Rot = Quaternion.Euler(new Vector3(0, Random.Range(face_center-angle_range_half, face_center+angle_range_half), 0));

        return new_spawn_pos;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bubble"))
        {
            in_motion = false;
        }
    }
}