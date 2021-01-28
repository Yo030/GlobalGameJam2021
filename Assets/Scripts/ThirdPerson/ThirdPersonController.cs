using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    [SerializeField] private CharacterController PlayerController;
    [SerializeField] private float PlayerSpeed;
    [SerializeField] private float TurnTime;
    private float TurnVelocity;

    private void Start()
    {
        PlayerController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float _horizontal = Input.GetAxisRaw("Horizontal");
        float _vertical = Input.GetAxisRaw("Vertical");
        Vector3 _direction = new Vector3(_horizontal, 0f, _vertical).normalized;

        if(_direction.magnitude >= 0.1f)
        {
            float _targetangle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;//ROTATE TO THE ANGLE YOU WANT TO LOOK AT
            float _angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetangle, ref TurnVelocity, TurnTime);
            transform.rotation = Quaternion.Euler(0, _angle, 0);
            PlayerController.Move(_direction * PlayerSpeed * Time.deltaTime);
        }
    }
}
