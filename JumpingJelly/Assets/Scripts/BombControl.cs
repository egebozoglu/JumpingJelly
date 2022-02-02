using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class BombControl : MonoBehaviour
{
    public GameObject explosionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject explosion;
        if (collision.gameObject.transform.tag == "character")
        {
            collision.gameObject.SetActive(false);
            Destroy(this.gameObject, 0f);
            explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            GameControl.instance.EndGame();
        }
    }
}
