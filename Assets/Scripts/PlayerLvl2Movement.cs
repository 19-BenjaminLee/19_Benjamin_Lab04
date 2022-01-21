using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLvl2Movement : MonoBehaviour
{
    public float speed;
    Rigidbody PlayerRigidBody;

    // Score //
    public Text txtScoreLvl2;
    private int scoreLvl2;

    public Text txtTimer;
    float Timer = 90f;

    // Start is called before the first frame update
    void Start()
    {
        PlayerRigidBody = GetComponent<Rigidbody>();

        txtScoreLvl2.text = "Score: " + scoreLvl2.ToString();
        txtTimer.text = "Timer: " + Timer.ToString("0");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        PlayerRigidBody.AddForce(movement * speed * Time.deltaTime);

        // Win Condition //
        if (scoreLvl2 >= 7)
        {
            SceneManager.LoadScene("GameWin");
        }
    }

    void Update()
    {
        //timer
        Timer -= Time.deltaTime;
        txtTimer.text = "Timer: " + Timer.ToString("0");
        if (Timer <= 0)
        {
            SceneManager.LoadScene("GameLose");
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            scoreLvl2 += 1;
            txtScoreLvl2.text = "Score: " + scoreLvl2.ToString();
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hazard")
        {
            SceneManager.LoadScene("GameLose");
        }
    }
}
