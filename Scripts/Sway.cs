using UnityEngine;

public class Sway : MonoBehaviour
{
    [SerializeField]
    float _intensity;
    [SerializeField]
    public float _smooth;

    Animator anim;

    private Quaternion origin_rotation;

    private void Start()
    {
        origin_rotation = transform.localRotation;
        anim = GetComponent<Animator>();  
    }
    private void Update()
    {
        UpdateSway();
        Bobbing();
    }

    private void UpdateSway()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        Quaternion t_x_adj = Quaternion.AngleAxis(-_intensity * x, Vector3.up);
        Quaternion t_y_adj = Quaternion.AngleAxis(_intensity * y, Vector3.right);
        Quaternion target_rotation = origin_rotation * t_x_adj * t_y_adj;

        transform.localRotation = Quaternion.Lerp(transform.localRotation, target_rotation, Time.deltaTime * _smooth);
    }

    void Bobbing()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            anim.SetBool("IsWalking", true);
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }
    }
}
