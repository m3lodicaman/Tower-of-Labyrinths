﻿using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerTestScript : MonoBehaviour
{
    Rigidbody rb3d;
    public Camera MoveCam, BattleCam;
    public Transform EnemySpot; 
    public float attackerID = 000f;
    public float charID = 000f;
    public float mana;
    public float hp;
    public float element;
    public float classType;
    public float dodgeChance;
    public float attackPower;
    public float magicPower;
    public float defense;
    public float[] attackID;
    public float[] items;
    public float[] enemyMoves;
    // Start is called before the first frame update
    void Start()
    {
        BattleCam.gameObject.SetActive(false);
        MoveCam.gameObject.SetActive(true);
        BattleCam.enabled = false;
        MoveCam.enabled = true;
        Time.timeScale = 1f;
        rb3d = GetComponent<Rigidbody>();
        BattleCam.enabled = false; 
        MoveCam.enabled = true;
    }
    public string AddItem(){
        int index = Array.IndexOf(items, 0);
        if(index == -1){
            return "Inventory is full!";
        }else{
            int choice = UnityEngine.Random.Range(1,8);
            items[index] = choice;
            return GameObject.FindGameObjectWithTag("BattleManager").GetComponent<BattleManager>().itemNames[choice];
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Enemy"){
            Debug.Log("Enter Battle");
            Time.timeScale = 0f;
            SwitchCameras();
            Destroy(other.gameObject.GetComponent<Rigidbody>());
            other.gameObject.GetComponent<NavMeshAgent>().enabled = false;
            attackerID = other.gameObject.GetComponent<AIMovement>().enemyID;
            enemyMoves = other.gameObject.GetComponent<AIMovement>().enemyAttackID;
            other.gameObject.GetComponent<AIMovement>().enabled = false;
            other.gameObject.transform.position = EnemySpot.position;
            GameObject.FindGameObjectWithTag("BattleManager").GetComponent<BattleManager>().NewBattle();
        }
    }
    public void SwitchCameras(){
        BattleCam.gameObject.SetActive(true);
        MoveCam.gameObject.SetActive(false);
        BattleCam.enabled = true;
        MoveCam.enabled = false;
    }
}
