using UnityEngine;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    private new Camera camera;

    private Vector2 velocity;
    private float inputAxis;

    public float moveSpeed = 8f;
    public float maxJumpHeight = 5f;
    public float maxJumpTime = 1f;

    public float JumpForce => (2f * maxJumpHeight) / (maxJumpTime / 2f);
    public float Gravity => (-2f * maxJumpHeight) / Mathf.Pow((maxJumpTime / 2f), 2);

    public bool Playergrounded { get; private set; }
    public bool Playerjumping { get; private set; }

    public bool Playerrunning => Mathf.Abs(velocity.x) > 0.25f || Mathf.Abs(inputAxis) > 0.25f;
    public bool PlayerSliding => (inputAxis > 0f && velocity.x < 0f) || (inputAxis < 0f && velocity.x > 0f);

    // Reference to the joystick and jump button
    public Joystick joystick;        // Assign this in the inspector
    public Button jumpButton;        // Assign this in the inspector

    private bool jumpPressed = false;

<<<<<<< HEAD
    private void Awake()
=======





  private void Awake()
  {
    rigidbody = GetComponent<Rigidbody2D>();
    camera = Camera.main;


  }

  private void Update()
  {
    HorizontalMovement();
    Playergrounded = rigidbody.Raycast(Vector2.down);

    if(Playergrounded){
      GroundedMovement();
    }

    ApplyGravity();

  }
  private void HorizontalMovement()
  {
    inputAxis = Input.GetAxis("Horizontal");
    velocity.x = Mathf.MoveTowards(velocity.x, inputAxis * moveSpeed, moveSpeed * Time.deltaTime);

    if(rigidbody.Raycast(Vector2.right * velocity.x)){
      velocity.x = 0f;
      
    }

    if(velocity.x > 0f){
      transform.eulerAngles = Vector3.zero;

    }else if (velocity.x < 0f){
      transform.eulerAngles = new Vector3(0f, 180f, 0f);
    }
  }



  private void GroundedMovement()
  {
    velocity.y = Mathf.Max(velocity.y, 0f);
    Playerjumping = velocity.y > 0f;

    if (Input.GetButtonDown("Jump"))
>>>>>>> parent of b0c1004 (complete first level but not polished yet)
    {
        rigidbody = GetComponent<Rigidbody2D>();
        camera = Camera.main;

<<<<<<< HEAD
        // Add an event listener for the jump button
        jumpButton.onClick.AddListener(OnJumpButtonPressed);
=======
    }
  }

  private void ApplyGravity()
  {
    bool falling = velocity.y < 0f || !Input.GetButton("Jump");
    float multiplier = falling ? 2f : 1f;

    velocity.y += Gravity * multiplier * Time.deltaTime;
    velocity.y = Mathf.Max(velocity.y, Gravity / 2f);


  }

  private void FixedUpdate()
  {
    Vector2 position = rigidbody.position;
    position += velocity * Time.fixedDeltaTime;

    Vector2 leftEdge = camera.ScreenToWorldPoint(Vector2.zero);
    Vector2 rightEdge = camera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

    position.x = Mathf.Clamp(position.x, leftEdge.x + 0.5f, rightEdge.x - 0.5f);




    rigidbody.MovePosition(position);

  }

  private void OnCollisonEnter2D(Collision2D collision){
    if(collision.gameObject.layer != LayerMask.NameToLayer("PowerUp")){
      if(transform.DotTest(collision.transform, Vector2.up)){
        velocity.y = 0f;

      }
>>>>>>> parent of b0c1004 (complete first level but not polished yet)
    }

    private void Update()
    {
        HorizontalMovement();
        Playergrounded = rigidbody.Raycast(Vector2.down);

        if (Playergrounded)
        {
            GroundedMovement();
        }

        ApplyGravity();
    }

    private void HorizontalMovement()
    {
        // Use joystick input for horizontal movement
        inputAxis = joystick.Horizontal;
        velocity.x = Mathf.MoveTowards(velocity.x, inputAxis * moveSpeed, moveSpeed * Time.deltaTime);

        if (rigidbody.Raycast(Vector2.right * velocity.x))
        {
            velocity.x = 0f;
        }

        if (velocity.x > 0f)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else if (velocity.x < 0f)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
    }

    private void GroundedMovement()
    {
        velocity.y = Mathf.Max(velocity.y, 0f);
        Playerjumping = velocity.y > 0f;

        // If jump button is pressed, initiate jump
        if (jumpPressed)
        {
            velocity.y = JumpForce;
            Playerjumping = true;
            jumpPressed = false; // Reset the jump button press flag
        }
    }

    private void ApplyGravity()
    {
        bool falling = velocity.y < 0f || !Input.GetButton("Jump");
        float multiplier = falling ? 2f : 1f;

        velocity.y += Gravity * multiplier * Time.deltaTime;
        velocity.y = Mathf.Max(velocity.y, Gravity / 2f);
    }

    private void FixedUpdate()
    {
        Vector2 position = rigidbody.position;
        position += velocity * Time.fixedDeltaTime;

        Vector2 leftEdge = camera.ScreenToWorldPoint(Vector2.zero);
        Vector2 rightEdge = camera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        position.x = Mathf.Clamp(position.x, leftEdge.x + 0.5f, rightEdge.x - 0.5f);

        rigidbody.MovePosition(position);
    }

    // Event handler for the jump button
    private void OnJumpButtonPressed()
    {
        // Set jumpPressed to true so the player can jump on the next update
        if (Playergrounded)
        {
            jumpPressed = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            if (transform.DotTest(collision.transform, Vector2.down))
            {
                velocity.y = JumpForce / 2f;
            }
        }
        else if (collision.gameObject.layer != LayerMask.NameToLayer("PowerUp"))
        {
            if (transform.DotTest(collision.transform, Vector2.up))
            {
                velocity.y = 0f;
            }
        }
    }
}