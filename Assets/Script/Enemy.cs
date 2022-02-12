using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Image UIHP,HPBG;
    public float currentHP,MaxHP,fill;

    public GameObject player;
    void Start()
    {
        MaxHP=10;
        currentHP=MaxHP;
    }

    private void Update() {
        fill=currentHP/MaxHP;
        UIHP.fillAmount=fill;

        Vector3 targetPosition = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z);
        UIHP.transform.LookAt(targetPosition);
        HPBG.transform.LookAt(targetPosition);

    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag=="PlyBullet"){
            currentHP=currentHP-1;

            if(currentHP<=0){
                Destroy(gameObject);
            }
        }
    }
}
