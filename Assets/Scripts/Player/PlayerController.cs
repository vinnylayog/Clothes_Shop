using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Camera cam;

    [SerializeField]
    private float moveSpeed = 5.0f;
    [SerializeField]
    private Rigidbody2D rb;

    Vector2 movement;

    [SerializeField]
    private SpriteRenderer playerSpriteRenderer;
    public Animator myAnimator;
    public string[] animationNames;

    public Heading facing = 0;

    private void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //Move player based on Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();

        //On right click
        if (Input.GetMouseButtonDown(1))
        {
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        HandleAnimation();
    }

    void HandleAnimation()
    {
        if (movement.x > 0.0f) facing = Heading.Right;
        else if (movement.x < 0.0f) facing = Heading.Left;

        if (movement.y > 0.0f) facing = Heading.Up;
        else if (movement.y < 0.0f) facing = Heading.Down;

        if (movement == Vector2.zero) facing = Heading.Idle;

        switch ((int)facing)
        {
            default:
                break;
            case 0:
                myAnimator.Play(animationNames[0]);
                break;
            case 1:
                myAnimator.Play(animationNames[1]);
                break;
            case 2:
                playerSpriteRenderer.flipX = true;
                myAnimator.Play(animationNames[2]);
                break;
            case 3:
                playerSpriteRenderer.flipX = false;
                myAnimator.Play(animationNames[2]);
                break;
            case 4:
                myAnimator.Play(animationNames[3]);
                break;
        }
    }
}

public enum Heading { Up, Down, Left, Right, Idle }