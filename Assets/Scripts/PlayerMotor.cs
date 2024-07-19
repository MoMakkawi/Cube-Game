using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    public float speed = 5f;
    public float gravity = -9.8f;
    private bool isGrounded;
    private float jumbHight = 150f;

    private bool lerpCrouch;
    private bool crouching;
    private bool sprinting;

    public float crouchTimer = 1;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;

        if (lerpCrouch)
        {
            crouchTimer += Time.deltaTime;
            float p = crouchTimer / 1;
            p *= p;

            if (crouching) controller.height = Mathf.Lerp(controller.height, 1, p);
            else controller.height = Mathf.Lerp(controller.height, 2, p);

            if (p > 1)
            {
                lerpCrouch = false;
                crouchTimer = 0f;
            }
        }
    }

    public void Crouch()
    {
        crouching = !crouching;
        crouchTimer = 0f;
        lerpCrouch = true;
    }

    public void Sprint()
    {
        sprinting = !sprinting;
        speed = sprinting ? 8 : 5;
    }
    //recive input from inputmanager controller then apply them to our Character Controller
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;

        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);

        playerVelocity.y += gravity + Time.deltaTime;

        //if (playerVelocity.y < -150f)
        //{ 
        //die
        //}

        if (isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;


        controller.Move(playerVelocity * Time.deltaTime);


    }

    public void Jumb()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumbHight * -3.0f * gravity);
        }
    }
}