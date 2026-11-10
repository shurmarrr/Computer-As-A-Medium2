using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThree: MonoBehaviour
{
	void Start()
	{

	}


	void Update()
	{
		transform.Translate(new Vector3(0, -3, 0) * Time.deltaTime * 4f);
		if (transform.position.y < -9f)
		{
			Destroy(this.gameObject);
		}
	}
}
