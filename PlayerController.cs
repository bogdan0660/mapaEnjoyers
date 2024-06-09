using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sprintSpeed = 10f;
    public float jumpForce = 5f;
    private bool isJumping = false;
    private bool isFacingLeft = false;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private AudioSource audioSource;
    public AudioClip[] footstepClips;
    private int currentFootstepIndex = 0;
    public float footstepDelay = 0.2f;
    private float nextFootstepTime = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 2f;

        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        // Sprawdzenie, czy klawisz Shift jest wciśnięty
        bool isSprinting = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        // Ustalenie aktualnej prędkości ruchu w zależności od wciśnięcia klawisza Shift
        float currentMoveSpeed = isSprinting ? sprintSpeed : moveSpeed;

        Vector2 movement = new Vector2(moveHorizontal * currentMoveSpeed, rb.velocity.y);
        rb.velocity = movement;

        if (moveHorizontal < 0 && !isFacingLeft)
        {
            Flip();
        }
        else if (moveHorizontal > 0 && isFacingLeft)
        {
            Flip();
        }

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = true;

            // Odtwarzanie animacji skoku
            animator.SetTrigger("Jump");
        }

        // Ustawianie parametru animacji "Speed" w zależności od prędkości ruchu
        animator.SetFloat("Speed", Mathf.Abs(moveHorizontal * currentMoveSpeed));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    private void Flip()
    {
        isFacingLeft = !isFacingLeft;

        // Obrócenie obrazka gracza
        spriteRenderer.flipX = isFacingLeft;
    }

    private void PlayFootstepSound()
    {
        if (footstepClips.Length > 0)
        {
            AudioClip footstepClip = footstepClips[currentFootstepIndex];
            audioSource.PlayOneShot(footstepClip);

            // Zwiększenie indeksu odtwarzanego dźwięku kroku
            currentFootstepIndex = (currentFootstepIndex + 1) % footstepClips.Length;

            // Ustawienie czasu następnego odtworzenia dźwięku
            nextFootstepTime = Time.time + footstepDelay;
        }
    }

    private bool CanPlayFootstepSound()
    {
        return Time.time >= nextFootstepTime;
    }

    private void FixedUpdate()
    {
        if (!isJumping && rb.velocity.magnitude > 0.1f && CanPlayFootstepSound())
        {
            PlayFootstepSound();
        }
    }
}
