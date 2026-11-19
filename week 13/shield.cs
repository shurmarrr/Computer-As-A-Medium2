using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using static Player;


public class shield : MonoBehaviour
{
    private float shieldSway = 0f;
    private float timer = 0f;


    // Start is called before the first frame update
    void Start()
    {

        transform.localScale = new Vector3(0.4f, 0.4f, 0.2f);

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        transform.Translate(new Vector3(shieldSway, -1, 0) * Time.deltaTime * 0.3f);
        if (timer >= 6.0f)
        {
            int randomNum = Random.Range(-1, 1);

            shieldSway = randomNum;
            timer = 0f;
            if (transform.position.x >= 5f || transform.position.x <= -5f)
                shieldSway = shieldSway * -1;
        }
        if (transform.position.y < -6.5f)
        {
            Destroy(this.gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().ActivateShield();
        }

        Destroy(this.gameObject);
        
    }
}
