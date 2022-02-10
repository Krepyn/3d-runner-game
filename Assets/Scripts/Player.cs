using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Stats
    public int maxHealth = 3;
    public static int health = 3;
    public static int coins = 0;
    public static int currentLevel = 1;
    public static int maxLevel = 3;

    // Movement
    public CharacterController controller;
    public Joystick joystick;
    public bool playerOnGround;
    public float speed = 3f;
    public float gravity = -9f;
    public float jump = 1f;

    private Vector3 velocity;
    private float maxYRot = -70f;
    private float minYRot = -110f;
    private float horizontalMove;
    // private float currentRotation = -90f;

    // Checks
    public static bool isLevelStart = true;

    private bool isMenuOpen = false;
    private bool levelEnd = false;

    // Rotation
    public float rotationSpeed = 5f;

    private Transform playerTransform;


    void Start() {
        playerTransform = GetComponent<Transform>();
        isLevelStart = true;

        if(MainMenuButtons.loadGame || MenuButtons.nextLevel)
            LoadPlayerPrefs();
    }

    void Update() {
        if(health == 0)
            Die();
        PlayerMovement();
    }

    private void PlayerMovement() {
        if(!levelEnd && !isLevelStart){
            if(!isMenuOpen){
                playerOnGround = controller.isGrounded;
                if (playerOnGround && velocity.y < 0)
                velocity.y = 0f;

                // Forward Movement
                // horizontalMove = Input.GetAxis("Horizontal"); // Keyboard
                horizontalMove = joystick.Horizontal;

                Vector3 move = new Vector3(-speed, 0, horizontalMove);
                controller.Move(move * Time.deltaTime * speed);

                // Jump
                // if(Input.GetButtonDown("Jump") && playerOnGround)
                //     velocity.y += Mathf.Sqrt(jump * -3f * gravity);

                // Gravity
                velocity.y += gravity * Time.deltaTime;
                controller.Move(velocity * Time.deltaTime);

                // Rotation
                transform.Rotate(0, horizontalMove, 0);
                LimitRotation();

                // Rotate Back to forward position
                if(Input.GetAxis("Horizontal") == 0){
                    Quaternion target = Quaternion.Euler(0f, -90f, 0f);
                    playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, target, rotationSpeed * Time.deltaTime);
                }
            }
        } else {
            if(joystick.Horizontal != 0f){
                Debug.Log("Start Level");
                isLevelStart = false;
                GetComponent<Animator>().enabled = true;
            }
        }
    }

    private void LimitRotation() {
        Vector3 playerEulerAngles = playerTransform.rotation.eulerAngles;

        playerEulerAngles.y = (playerEulerAngles.y > -90) ? playerEulerAngles.y - 360 : playerEulerAngles.y;
        playerEulerAngles.y = Mathf.Clamp(playerEulerAngles.y, minYRot, maxYRot);

        playerTransform.rotation = Quaternion.Euler(playerEulerAngles);
    }

    private void Die() {
        SceneManager.LoadScene(currentLevel);
        LoadPlayerPrefs();
    }

    // Public functions
    public IEnumerator LevelEnd() {
        yield return new WaitForSeconds(1);
        levelEnd = true;
        GetComponent<Animator>().enabled = false;
    }

    public void NextLevel() {
        currentLevel++;
        SavePlayerPrefs();
        SceneManager.LoadScene(currentLevel);
        levelEnd = false;
    }

    public void CoinPickup(int amount) {
        coins += amount;
    }

    public void HealthPickup() {
        if(health < maxHealth)
            health++;
    }

    public void GetHit(){
        health--;
    }

    public void Stop() {
        isMenuOpen = true;
        GetComponent<Animator>().enabled = false;
    }

    public void Continue() {
        isMenuOpen = false;
        if(!levelEnd && !isLevelStart)
                GetComponent<Animator>().enabled = true;
    }

    public void SavePlayerPrefs() {
        PlayerPrefs.SetInt("Health", health);
        PlayerPrefs.SetInt("Coins", coins);
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);
        PlayerPrefs.Save();
    }

    public void LoadPlayerPrefs() {
        health = PlayerPrefs.GetInt("Health");
        coins = PlayerPrefs.GetInt("Coins");
        currentLevel = PlayerPrefs.GetInt("CurrentLevel");
    }

    // public void LeftTurn() {
    //     float rotation = currentRotation - 90f;
    //     minYRot -= 90f;
    //     maxYRot -= 90f;
    //
    //     Quaternion target = Quaternion.Euler(0f, rotation, 0f);
    //     playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, target, Time.deltaTime);
    //
    //     if(rotation == -360f)
    //         rotation = 0f;
    // }

}
