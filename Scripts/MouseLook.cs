using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField]
    Transform player;
    [SerializeField]
    float _mouseSensitivity = 1000f;

    float _xRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        
        float _mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        float _mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

        _xRotation -= _mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        player.Rotate(Vector3.up * _mouseX);

    }
}
