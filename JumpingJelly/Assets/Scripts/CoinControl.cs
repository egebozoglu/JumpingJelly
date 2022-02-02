using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinControl : MonoBehaviour
{
    public List<Sprite> spriteList;
    int spriteCounter = 0;
    SpriteRenderer spriteRenderer;
    float animTime = 0f;

    private void Awake()
    {
        spriteRenderer = transform.GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CoinAnimation();
    }

    public void CoinAnimation()
    {
        animTime += Time.deltaTime;
        if (animTime>0.1f)
        {
            animTime = 0f;
            spriteCounter++;
            if (spriteCounter > 15)
            {
                spriteCounter = 0;
            }
            spriteRenderer.sprite = spriteList[spriteCounter];
        }
        
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.transform.tag == "character")
        {
            UIManager.instance.coinCollision++;
            Destroy(this.gameObject, 0f);
        }
    }
}
