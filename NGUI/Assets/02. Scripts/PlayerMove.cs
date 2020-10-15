using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public UISprite hpSprite;
    public GM gm;

    float maxHp = 100.0f;
    float hp = 100.0f;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        float V = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(0, V, 0);
        transform.Translate(dir * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        hp -= 10.0f;
        hpSprite.fillAmount = hp * 0.01f;

        if(hp <= 0)
        {
            gm.GameOver();
        }
    }

}
