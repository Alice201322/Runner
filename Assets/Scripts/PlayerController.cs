using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 5f;
    public GameManager gameManager;
    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Debug.Log("Coin");
            gameManager.coins++;
            gameManager.coinText.text = "Coins: " + gameManager.coins;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Up"))
        {
            transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
        }

        if (other.CompareTag("Down"))
        {
            transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Finish"))
        {
            gameOver.SetActive(true);
            speed = 0;
        }
    }
}
