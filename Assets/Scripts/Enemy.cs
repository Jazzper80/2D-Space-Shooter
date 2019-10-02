using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField]
    private int speed = 4;

    [SerializeField]
    private GameObject _enemy;

	void Update () 
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if(transform.position.y < -5f)
        {
            transform.position = new Vector3(Random.Range(8f, -8f), 6.8f, 0);
        }
	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();

            if(player != null)
            {
                player.Damage();
            }
            Destroy(this.gameObject);
        }
        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
