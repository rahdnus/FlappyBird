using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]float force=10;
    [SerializeField] TextMeshProUGUI scoreUI;
    [SerializeField] GameObject deadScreen;
    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
                rb.AddForce(Vector2.up*force,ForceMode2D.Impulse);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.layer == LayerMask.NameToLayer("Pass"))
        {
            score += 1;
            scoreUI.text = score.ToString();
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Limit"))
        {
            deadScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
        private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pipe"))
        {
            deadScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
