using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public PlatformMovement platform;
    [SerializeField] Sprite[] sprites;
    SpriteRenderer sprite;
    public int spriteToPick;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        platform = FindObjectOfType<PlatformMovement>();
        if (platform != null)
        {
            sprite = platform.GetComponent<SpriteRenderer>();
            sprite.sprite = sprites[spriteToPick];
        }
    }



    public void LoadScene(int spriteNum)
    {
        spriteToPick = spriteNum;
        SceneManager.LoadScene(1);
    }
}
