using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public static CharacterControl instance;
    public List<Sprite> CharSprites;
    Rigidbody2D rg;
    int force = 300;
    int spriteCounter = 0;
    SpriteRenderer spriteRenderer;
    public DynamicJoystick dynamicJoystick;
    float speed = 0.15f;
    float animTime = 0f;
    bool animate = false;
    float animRate = 0.03f;
    public GameObject jumpingSound;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
        rg = transform.GetComponent<Rigidbody2D>();
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
        HorizontalMovement();
        CharAnimation();
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Background")
        {
            animate = true;
        }
    }

    public void CharAnimation()
    {
        if (animate)
        {
            animTime += Time.deltaTime;
            if (animTime > animRate)
            {
                animTime = 0f;
                spriteCounter++;
                if (spriteCounter > 8)
                {
                    spriteCounter = 0;
                    animate = false;
                }
                spriteRenderer.sprite = CharSprites[spriteCounter];
                if (spriteCounter == 3)
                {
                    GameObject sound;
                    rg.AddForce(transform.up * force);
                    sound = Instantiate(jumpingSound, transform.position, Quaternion.identity);
                    Destroy(sound.gameObject, 3f);
                }
            }
        }
    }

    public void HorizontalMovement()
    {
        var horizontal = dynamicJoystick.Horizontal;

        if (horizontal<0)
        {
            if (transform.position.x>-4)
            {
                transform.Translate(horizontal*speed, 0f, 0f);
            }
        }
        else if (horizontal>0)
        {
            if (transform.position.x<4)
            {
                transform.Translate(horizontal*speed, 0f, 0f);
            }
        }
    }
}
