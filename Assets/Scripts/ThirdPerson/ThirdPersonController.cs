using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    [SerializeField] private CharacterController PlayerController;
    [HideInInspector] public float PlayerSpeed;
    [HideInInspector] public bool CanMove;
    public float TurnTime;
    private float TurnVelocity;


    public Transform groundCheck;
    private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;

    Vector3 gravityVelocity;
    private float gravity = -9.81f;

    bool isGrounded;

    private Rigidbody rb;

    public Transform cam;

    public PlayerAnimationController PAC;

    private void Start()
    {
        CanMove = true;
        rb = gameObject.GetComponent<Rigidbody>();
        PlayerController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (CanMove)
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && gravityVelocity.y < 0)
            {
                gravityVelocity.y = -2f;
            }


            float _horizontal = Input.GetAxisRaw("Horizontal");
            float _vertical = Input.GetAxisRaw("Vertical");
            Vector3 _direction = new Vector3(_horizontal, 0f, _vertical).normalized;

            if (_direction.magnitude >= 0.1f)
            {
                float _targetangle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;//ROTATE TO THE ANGLE YOU WANT TO LOOK AT
                float _angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetangle, ref TurnVelocity, TurnTime);
                transform.rotation = Quaternion.Euler(0, _angle, 0);

                Vector3 moveDir = Quaternion.Euler(0f, _targetangle, 0f) * Vector3.forward;

                PlayerController.Move(moveDir.normalized * PlayerSpeed * Time.deltaTime);
            }

            gravityVelocity.y += gravity * Time.deltaTime;
            
            PlayerController.Move(gravityVelocity * Time.deltaTime);
        }

        
        
    }
    
}
