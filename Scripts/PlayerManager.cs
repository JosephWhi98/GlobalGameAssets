﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    [SerializeField] GameObject[] Caravans;
    public int caravansCollected;

    [SerializeField] GameObject explosionEffect;

    [SerializeField] GameManager gameManager;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            activateCaravan();
        }

        caravansCollected = Mathf.Clamp(caravansCollected, 0, Caravans.Length);
    }

    public void activateCaravan()
    {
        if (caravansCollected < Caravans.Length - 1)
        {
            Caravans[caravansCollected].GetComponent<MeshRenderer>().enabled = true;
            Caravans[caravansCollected].GetComponent<Collider>().enabled = true;
            caravansCollected += 1;
            UIManager.Instance.FlashTimer(Color.green);
        }
    }

    public void DestroyCaravans(int startIndex)
    {
        for (int i = startIndex; i < Caravans.Length; i++)
        {
            if (Caravans[i].GetComponent<MeshRenderer>().enabled == true)
            {
                Caravans[i].GetComponent<MeshRenderer>().enabled = false;
                Caravans[i].GetComponent<Collider>().enabled = false;
                Instantiate(explosionEffect, Caravans[i].transform.position, Quaternion.identity);
                caravansCollected -= 1;

                GameManager.Instance.timeLeft -= 2;
                UIManager.Instance.FlashTimer(Color.red);
            }
            //TODO INSTANTIATE EXPLOSION AT POSITION!
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Instantiate(explosionEffect, collision.transform.position, Quaternion.identity);
            collision.gameObject.GetComponent<EnemyCar>().Boom();
            activateCaravan();
            if (gameManager.timeLeft <= 50)
                gameManager.timeLeft += 10;
            else
                gameManager.timeLeft = 60;
        }
    }



}
