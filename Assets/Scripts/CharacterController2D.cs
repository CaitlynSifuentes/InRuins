using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    /** Variables **/
    // game start / over vars
    public bool hasGameStarted = false;
    public bool isGameOver = false;

    // moving mechanic vars
    private bool canDoubleJump;
    private float jumpForce = 9.5f;
    private bool isOnGround;
    private bool isSliding;
    private IEnumerator slideCoroutine;

    // audio vars
    public AudioClip[] jumpGravel;
    public AudioClip[] jumpRock;
    public AudioClip[] slide;
    private AudioSource _audioSource;

    // detection vars
    public LayerMask whatIsGround;
    public LayerMask whatIsObstacle;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private CircleCollider2D playerFeetCollider;
    private BoxCollider2D playerHeadCollider;

    // menu vars
    public GameObject mainMenu;
    public GameObject gameOverMenu;
    /** END **/


    // Start is called before the first frame update
    void Start()
    {
        // setting variables
        _audioSource = GetComponent<AudioSource>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        playerFeetCollider = GetComponent<CircleCollider2D>();
        playerHeadCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /** JUMP MECHANICS **/
        // seeing if the player is touching the ground
        isOnGround = Physics2D.IsTouchingLayers(playerFeetCollider, whatIsGround);

        // if the player presses "Space / w" call jumping function defined below
        if (Input.GetButtonDown("Jump"))
        {
            jumping();
        } // end if

        // Sets anim to start jumping if player is not grounded
        //      if player is falling it starts the fall anim
        _animator.SetBool("Jumping", !isOnGround);
        _animator.SetFloat("yVelocity", _rigidbody.velocity.y);
        /** END **/


        /** SLIDE MECHANICS **/
        // if the player presses "S or ctrl" call the slide func
        if (Input.GetButtonDown("Slide"))
        {
            slidingFunc();
        } // end if

        // Sets animation to start if player is sliding
        _animator.SetBool("Sliding", isSliding);
        /** END **/


        /** GAME OVER MECHANICS **/
        // if the players upper body touches any obstacles the game is over
        if (Physics2D.IsTouchingLayers(playerHeadCollider, whatIsObstacle))
        {
            isGameOver = true;
            gameOverMenuDisplay();
        }

        // sets the anim to death
        _animator.SetBool("Dead", isGameOver);
        /** END **/

    }


    /** SLIDE MECHANICS CONT **/
    public void slidingFunc()
    { 
        if (!isGameOver && isOnGround && hasGameStarted)
        {
            // plays the slide audio
            _audioSource.PlayOneShot(slide[Random.Range(0, slide.Length)], 0.5F);

            // disables playerHead Collision
            playerHeadCollider.enabled = !playerHeadCollider.enabled;
            isSliding = true;

            // enables and starts coutdown to stand
            slideCoroutine = slideCountDown();
            StartCoroutine(slideCoroutine);
        }
    }

    private IEnumerator slideCountDown()
    {
        // waits for .5 then enables the box colider and resets isSliding
        yield return new WaitForSeconds(0.5f);
        playerHeadCollider.enabled = !playerHeadCollider.enabled;
        isSliding = false;
    }
    /** END **/


    /** JUMP MECHANICS CONT **/
    public void jumping()
    {
        if (isOnGround && !isSliding && !isGameOver && hasGameStarted)
        {
            // pushes the player upwards
            _rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

            // starts the jumping animation
            _animator.SetBool("Jumping", true);

            // allows the player to now jump again even though they are not on the ground
            canDoubleJump = true;
        }
        else if (canDoubleJump && !isSliding && !isGameOver)
        {
            // the player cannot jump again until they are on the ground
            canDoubleJump = false;

            // pushes the player upwards
            _rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

        }
    }
    /** END **/


    /** COLLISION SOUND FUNCTIONALITY **/
    void OnCollisionEnter2D(Collision2D collision)
    {
        // if the ground is landed on play jumpGravel
        if (collision.gameObject.CompareTag("Ground"))
        {
            _audioSource.PlayOneShot(jumpGravel[Random.Range(0, jumpGravel.Length)], 0.5F);
        }

        // if the obstacle is landed on play jumpRock
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("ObstacleS"))
        {
            _audioSource.PlayOneShot(jumpRock[Random.Range(0, jumpRock.Length)], 0.5F);
        }
    }
    /** END **/


    /** START MENU MECHANICS **/
    public void startGame()
    {
        // Starts the game and hides the menu
        hasGameStarted = true;
        mainMenu.SetActive(false);

        // sets the character to run
        _animator.SetBool("GameStarted", true);
    }
    /** END **/


    /** GAMEOVER MENU MECHANICS **/
    public void gameOverMenuDisplay()
    {
        // if the game is over display menu to restart
        gameOverMenu.SetActive(true);
    }
    /** END **/
}
