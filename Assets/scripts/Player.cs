using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    new Collider2D collider;
    SpriteRenderer sprite;

    public int health = 100;
    public float moveSpeed = 1500;
    public float jumpForce = 350;
    public float downCastDebugDistance = 0.5f;

    bool isOnGround;
    RaycastHit2D[] groundCastResult = new RaycastHit2D[10];
    int groundCastHit;

    public event Action<int> OnHealthChanged;

    int counter = 0;

    void Start()
    {
        this.rb = this.GetComponent<Rigidbody2D>();
        this.collider = this.GetComponent<BoxCollider2D>();
        this.sprite = this.GetComponent<SpriteRenderer>();

        this.rb.freezeRotation = true;
    }

    void Update()
    {
        this.GroundCheck();
        this.MovementManager();
        this.counter += 1;
    }

    void MovementManager()
    {
        var x_delta = Input.GetAxis("Horizontal");
        // var y_delta = Input.GetAxis("Vertical");
        var jump = Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W);

        this.AdjustFacing(x_delta);

        float x_velocity = x_delta * this.moveSpeed * Time.deltaTime;
        float y_velocity = this.rb.velocity.y;

        if (this.isOnGround && jump)
        {
            this.rb.AddForce(new Vector2(0, this.jumpForce));
            this.isOnGround = false;
        }

        this.rb.velocity = new Vector2(x_velocity, y_velocity);
    }

    void GroundCheck()
    {
        var isOnGround = false;

        Collider2D[] overlap_colliders = new Collider2D[10];
        int num_overlap = Physics2D.OverlapBox(
            this.collider.bounds.min,
            new Vector3(this.collider.bounds.size.x, 2),
            270,
            new ContactFilter2D().NoFilter(),
            overlap_colliders
        );

        for (int i = 0; i < num_overlap; i++)
        {
            if (overlap_colliders[i].tag == "Ground")
            {
                isOnGround = true;
            }
        }

        this.isOnGround = isOnGround;
    }

    void AdjustFacing(float x_delta)
    {
        if (x_delta > 0)
        {
            this.sprite.flipX = true;
        }
        else if (x_delta < 0)
        {
            this.sprite.flipX = false;
        }
    }

    void Log(string message)
    {
        if (this.counter % 10 == 0)
        {
            Debug.Log(message);
        }
    }

    public void ModifyHealth(int amount)
    {
        this.health += amount;
        this.OnHealthChanged?.Invoke(this.health);
        if (this.health <= 0)
        {
            SceneManager.LoadScene("Assets/Scenes/MainMenu.unity");
        }
    }

    public Bounds ColliderBounds()
    {
        return this.collider.bounds;
    }
}
