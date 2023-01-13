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

    void Update()
    {
        HandleMovement();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        HandleAnimation();
    }

    //Move player based on Input (WASD or Arrow Keys)
    private void HandleMovement()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();
    }

    //Reads where the player is facing and updates the Animator
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

        //Up and Down directions override left and right
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

        //If player lets go of input, character is set to idle
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

        //Plays the animation
        myAnimator.Play(animationNames[(int)facing]);

        //Sends data to the Equipment Manager to handle direction of equipment sprites
        int direction = (int)facing;
        if (direction > 3) direction -= 4;
        EquipmentManager.Instance.UpdateFacing(direction);
    }
}

public enum Direction { Up, Down, Left, Right, UpIdle, DownIdle, LeftIdle, RightIdle}