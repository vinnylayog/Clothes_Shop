using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5.0f;
    [SerializeField]
    private Rigidbody2D rb;

    Vector2 movement;

    [SerializeField]
    private SpriteRenderer playerSpriteRenderer;
    public Animator myAnimator;
    public string[] animationNames;

    public Direction facing = 0;

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        HandleAnimation();
    }

    private void HandleMovement()
    {
        //Move player based on Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();
    }

    void HandleAnimation()
    {
        if (movement.x > 0.0f)
        {
            playerSpriteRenderer.flipX = false;
            facing = Direction.Right;
        }
        else if (movement.x < 0.0f) 
        {
            playerSpriteRenderer.flipX = true;
            facing = Direction.Left;
        }

        if (movement.y > 0.0f)
        {
            playerSpriteRenderer.flipX = false;
            facing = Direction.Up;
        }
        else if (movement.y < 0.0f)
        {
            playerSpriteRenderer.flipX = false;
            facing = Direction.Down;
        }

        if (movement == Vector2.zero)
        {
            switch (facing)
            {
                default:
                    break;
                case Direction.Up:
                    playerSpriteRenderer.flipX = false;
                    facing = Direction.UpIdle;
                    break;
                case Direction.Down:
                    playerSpriteRenderer.flipX = false;
                    facing = Direction.DownIdle;
                    break;
                case Direction.Left:
                    playerSpriteRenderer.flipX = true;
                    facing = Direction.LeftIdle;
                    break;
                case Direction.Right:
                    playerSpriteRenderer.flipX = false;
                    facing = Direction.RightIdle;
                    break;
            }
        }

        myAnimator.Play(animationNames[(int)facing]);

        int direction = (int)facing;
        if (direction > 3) direction -= 4;
        EquipmentManager.Instance.UpdateFacing(direction);
    }
}

public enum Direction { Up, Down, Left, Right, UpIdle, DownIdle, LeftIdle, RightIdle}