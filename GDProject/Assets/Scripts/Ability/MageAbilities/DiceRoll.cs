using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class DiceRoll : MonoBehaviour
{
    public float effectTimeHp;
    public float effectTimeArmor;
    public float effectTimeSpeed;
    public float hpAdd;
    public float hpRemove;
    public float armorAdd;
    public float armorRemove;
    public float speedAdd;
    public float speedRemove;

    public List<Color> sprites = new List<Color>();
    public float rollTime;
    public float waitTime;
    GameObject player;
    bool isRolling = true;
    bool isChangingFace = false;
    bool done = false;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!done)
        {
            if (isRolling)
            {
                if (!isChangingFace)
                {
                    StartCoroutine(ChangeFace());
                }
            }
            else
            {
                StartCoroutine(ChooseDiceFace());
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            StartCoroutine(Roll());
        }
    }

    IEnumerator ChangeFace()
    {
        isChangingFace = true;
        spriteRenderer.color = sprites[Random.Range(0, sprites.Count)];
        yield return new WaitForSeconds(0.1f);
        isChangingFace = false;
    }

    IEnumerator Roll()
    {
        yield return new WaitForSeconds(rollTime);
        isRolling = false;
    }

    IEnumerator ChooseDiceFace()
    {
        done = true;
        int choosenNumber = Random.Range(0, sprites.Count);
        ApplyEffect(choosenNumber);
        spriteRenderer.color = sprites[choosenNumber];
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }

    void ApplyEffect(int choosenNumber)
    {
        switch(choosenNumber)
        {
            case 0:
                player.GetComponent<HealthSystem>().HealthEffect(effectTimeHp, hpAdd);
                break;
            case 1:
                player.GetComponent<HealthSystem>().HealthEffect(effectTimeHp, -hpRemove);
                break;
            case 2:
                player.GetComponent<HealthSystem>().ArmorEffect(effectTimeArmor, armorAdd);
                break;
            case 3:
                player.GetComponent<HealthSystem>().ArmorEffect(effectTimeArmor, -armorRemove);
                break;
            case 4:
                player.GetComponent<PlayerMovementScript>().SpeedEffect(effectTimeSpeed, speedAdd);
                break;
            case 5:
                player.GetComponent<PlayerMovementScript>().SpeedEffect(effectTimeSpeed, -speedRemove);
                break;
        }
    }
}
