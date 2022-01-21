using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    Rigidbody PlayerRigidBody;

    // Score //
    public Text txtScore;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        PlayerRigidBody = GetComponent<Rigidbody>();
        
        txtScore.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        PlayerRigidBody.AddForce(movement * speed * Time.deltaTime);

        // Win Condition //
        if (score >= 4)
        {
            SceneManager.LoadScene("GameWin");
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coin")
        {
            score += 1;
            txtScore.text = "Score: " + score.ToString();
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Hazard")
        {
            SceneManager.LoadScene("GameLose");
        }
    }
}
