using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    CharacterController controller;
    [SerializeField]
    Transform groundCheck;
    [SerializeField]
    LayerMask groundMask;
    [SerializeField]
    float _speed = 10f;
    [SerializeField]
    float _jumpHeight = 3f;

    float groundDis = 0.4f;
    public bool isGrounded;
    float _gravity = -9.81f * 2;
    Vector3 velocity;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDis, groundMask);

        if(isGrounded && velocity.y <0 )
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * _speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
        }

        velocity.y += _gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
