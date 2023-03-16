using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    // Player stats
    [SerializeField] private float speed = 7f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float dashForce = 20f;
    [SerializeField] private float dashCD = 5f;
    private int health;
    private int power;
    private int level;


    public Player(){}

    public Player(int health, int power, int level)
    {
        this.health = health;
        this.power = power;
        this.level = level;
    }


    // Getters
    public int GetHealth(){
        return this.health;
    }
    public int GetPower(){
        return this.power;
    }
    public int GetLevel(){
        return this.level;
    }
    public float GetSpeed(){
        return this.speed;
    }
    public float GetjumpForce(){
        return this.jumpForce;
    }
    public float GetDashForce(){
        return this.dashForce;
    }
    public float GetDashCD(){
        return this.dashCD;
    }


    //Setters
    public void SetHealth(int health){
        this.health = health;
    }
    public void SetPower(int power){
        this.power = power;
    }
    public void SetLevel(int level){
        this.level = level;
    }
    public void SetSpeed(int speed){
        this.speed = speed;
    }
    public void SetJumpForce(int jumpForce){
        this.jumpForce = jumpForce;
    }
    public void SetDashForce(int dashForce){
        this.dashForce = dashForce;
    }
    public void SetDashCD(int dashCD){
        this.dashCD = dashCD;
    }

} // Class
