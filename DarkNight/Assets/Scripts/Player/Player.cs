using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{

    // Stats of the player
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

} // Class
