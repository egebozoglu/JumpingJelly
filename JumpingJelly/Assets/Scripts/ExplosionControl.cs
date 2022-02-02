using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionControl : MonoBehaviour
{
    public List<Sprite> explosionSprites = new List<Sprite>();
    SpriteRenderer spriteRenderer;
    float animTime = 0f;
    int spriteCounter = 0;
    float deneme = 0.5f;

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

    }

    private void FixedUpdate()
    {
        Explosion();
    }

    public void Explosion()
    {
        animTime += Time.deltaTime;
        if (animTime>deneme)
        {
            animTime = 0f;
            spriteCounter++;
            if (spriteCounter>2)
            {
                Destroy(this.gameObject, 0f);
            }
            else
            {
                spriteRenderer.sprite = explosionSprites[spriteCounter];
            }
        }
    }
}
