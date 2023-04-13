using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private CapsuleCollider col;
    private Animator anim;
    private Score score;
    private Vector3 dir;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity;
    [SerializeField] private int coins;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject scoreText;
    [SerializeField] private Text coinsText;
    [SerializeField] private Score scoreScript;
    
   
    public AudioSource audioSource;
    public AudioClip audioClipArray;

    public GameObject TwoX_image;
    public GameObject shield_image;
    public AudioClip CoinSound;

    private bool isSliding;
    private bool isImmortal;

    private int lineToMove = 1;
    public float lineDistance = 4; 
    private float maxSpeed = 110;

    public GameObject ShieldGame;
    public GameObject StarGame;
    public GameObject BonusParticle; 
    public GameObject PlayerParticle; 
    public AudioClip Steam;
    public Transform Player;

    public InterstitialAds ad;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        controller = GetComponent<CharacterController>();
        col = GetComponent<CapsuleCollider>();
        score = scoreText.GetComponent<Score>();
        score.scoreMultiplier = 1;
        Time.timeScale = 1;
        coins = PlayerPrefs.GetInt("coins");
        coinsText.text = coins.ToString();
        StartCoroutine(SpeedIncrease());
        isImmortal = false;
    }

    private void Update()
    {
        if (SwipeController.swipeRight)
        {
            if (lineToMove < 2)
                lineToMove++;
        }

        if (SwipeController.swipeLeft)
        {
            if (lineToMove > 0)
                lineToMove--;
        }

        if (SwipeController.swipeUp)
        {
            if (controller.isGrounded)
                Jump();
        }

        if (SwipeController.swipeDown)
        {
            StartCoroutine(Slide());
        }


        if (controller.isGrounded && !isSliding)
            anim.SetBool("isRunning", true);
        else
            anim.SetBool("isRunning", false);

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (lineToMove == 0)
            targetPosition += Vector3.left * lineDistance;
        else if (lineToMove == 2)
            targetPosition += Vector3.right * lineDistance;

        if (transform.position == targetPosition)
            return;

        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;

        if (moveDir.sqrMagnitude < diff.sqrMagnitude)
            controller.Move(moveDir);
        else
            controller.Move(diff);

        

    }

    private void Jump()
    {
        dir.y = jumpForce;
        anim.SetTrigger("isJumping");
    }

    void FixedUpdate()
    {
        dir.z = speed;
        dir.y += gravity * Time.fixedDeltaTime;
        controller.Move(dir * Time.fixedDeltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "obstacle")
        {
            if (isImmortal)
                Destroy(hit.gameObject);
            else
            {
                anim.SetTrigger("Died");
                audioSource.PlayOneShot(audioClipArray);
                losePanel.SetActive(true);
                int lastRunScore = int.Parse(scoreScript.scoreText.text.ToString());
                PlayerPrefs.SetInt("lastRunScore", lastRunScore);
                speed = 0;
                Time.timeScale = 0;
                ad.ShowAd();
            }
        }    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            coins++;
            audioSource.PlayOneShot(CoinSound);
            PlayerPrefs.SetInt("coins", coins);
            coinsText.text = coins.ToString();
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "BonusStar")
        {
            StartCoroutine(StarBonus());
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "BonusShield")
        {
            StartCoroutine(ShieldBonus());
            Destroy(other.gameObject);
        }
    }

    private IEnumerator SpeedIncrease()
    {
        yield return new WaitForSeconds(1);
        if (speed < maxSpeed)
        {
            speed += 1;
            StartCoroutine(SpeedIncrease());
        }
    }

    private IEnumerator Slide()
    {
        col.center = new Vector3(0, -0.4f, 5f);
        col.height = 2;
        isSliding = true;
        anim.SetBool("isRunning", false);
        anim.SetTrigger("isSliding");

        yield return new WaitForSeconds(1);

        col.center = new Vector3(0, 0.108f, 0);
        col.height = 4.420422f;
        isSliding = false;
    }

    private IEnumerator StarBonus()
    {
        if(!GameObject.FindGameObjectWithTag("StarGame") | GameObject.FindGameObjectWithTag("ShieldGame")){
            Instantiate(StarGame, Player);
            Instantiate(BonusParticle, Player);
            Instantiate(PlayerParticle, Player);
            audioSource.PlayOneShot(Steam);
            score.scoreMultiplier = 2;
            //TwoX_image.SetActive(true);

            yield return new WaitForSeconds(5);

            Destroy(GameObject.FindGameObjectWithTag("StarGame"));
            Destroy(GameObject.FindGameObjectWithTag("PlayerParticle"));
           
            //TwoX_image.SetActive(false);
            score.scoreMultiplier = 1;
        }
        
    }

    private IEnumerator ShieldBonus()
    {
        if(!GameObject.FindGameObjectWithTag("ShieldGame") | GameObject.FindGameObjectWithTag("StarGame")){
            Instantiate(ShieldGame, Player);
            Instantiate(BonusParticle, Player);
            Instantiate(PlayerParticle, Player);
            audioSource.PlayOneShot(Steam);
            isImmortal = true;
            //shield_image.SetActive(true);

            yield return new WaitForSeconds(5);

            Destroy(GameObject.FindGameObjectWithTag("ShieldGame"));
            Destroy(GameObject.FindGameObjectWithTag("PlayerParticle"));
            //shield_image.SetActive(false);
            isImmortal = false;
        }
    }
}