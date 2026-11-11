using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;


public class Coin1 : MonoBehaviour
{
    private float coinSway = 0f;
    private float timer = 0f;


    // Start is called before the first frame update
    void Start()
    {
     
        transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        
}

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        transform.Translate(new Vector3(coinSway, -1, 0) * Time.deltaTime * 0.3f);
        if (timer >= 2.2f) 
        {
            int randomNum = Random.Range(-1, 1);

            coinSway = randomNum;
            timer = 0f;
            if (transform.position.x >= 5f || transform.position.x <= -5f)
               coinSway = coinSway * -1;
        }
        if (transform.position.y < -6.5f) 
        {
            Destroy(this.gameObject);
        }
        
    }

}
