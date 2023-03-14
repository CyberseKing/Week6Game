using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed;
    
    public TMP_Text scoreText;
    int score = 0;
    bool letMove = true;
    public GameObject gameOverText;
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    public GameManager myManager;
    // Start is called before the first frame update
    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(letMove);
       if(letMove)
        {
            groundedPlayer = controller.isGrounded;
            if (groundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }

            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            controller.Move(move * Time.deltaTime * playerSpeed);

            if (move != Vector3.zero)
            {
                gameObject.transform.forward = move;
            }
            if (Input.GetKey(KeyCode.Space))
            {
                for (int i = 0; i < myManager.enemyNum; i++)
                {
                    if (Vector3.Distance(transform.position, myManager.enemies[i].transform.position) < 5f)
                    {
                        Vector3 enemyPos = myManager.enemies[i].transform.position;
                        Vector3 resetPos = new Vector3(Random.Range(-2, 20), enemyPos.y, Random.Range(-2, 15));
                        myManager.enemies[i].transform.position = resetPos;
                        Debug.Log("near an enemy!!!");
                    }
                }
            }

            // Changes the height position of the player..
            if (Input.GetButtonDown("Jump") && groundedPlayer)
            {
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            }

            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collect") ;
        {
            score++;
            scoreText.text = score.ToString();
            Destroy(other.gameObject);
        }
        for (int i = 0; i < myManager.enemyNum; i++)
        {
            Debug.Log("loop on " + i);
            if (other.gameObject == myManager.enemies[i])
            {
                letMove = false;
                Debug.Log("hit!");
            }
        }
    }
}
