using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Camera cam;

    [SerializeField]
    private float moveSpeed = 5.0f;
    [SerializeField]
    private Rigidbody2D rb;

    Vector2 movement;

    Animator myAnimator;

    private void Start()
    {
        cam = Camera.main;
        myAnimator = GetComponent<Animator>();
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
    }
}
