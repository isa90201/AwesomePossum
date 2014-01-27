using System;

public class HumanPlayer
{
    // CONSTANTS
    private const int MIN_HEALTH = 1;
    private const int MIN_ATTACK = 1;
    private const int MIN_DEFENSE = 1;
    private const int MIN_EXPERIENCE = 0;
    private const int MIN_LEVEL = 1;

    private const int MAX_HEALTH = 99;
    private const int MAX_ATTACK = 99;
    private const int MAX_DEFENSE = 99;
    private const int MAX_EXPERIENCE = 99;
    private const int MAX_LEVEL = 99;

    // CLASS VARIABLES
    private string Name;
    private int Health;
    private int Attack;
    private int Defense;
    private int Experience;
    private int Level;


    public HumanPlayer(string name, int health, int attack, int defense, int experience, int level)
    {
        Name = name;
        Health = health;
        Attack = attack;
        Defense = defense;
        Experience = experience;
        Level = level;   
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }

    public void RecoverHealth(int health)
    {
        Health += health;
    }

    public void GainExperience(int experience)
    {
        Experience += experience;
    }

    public void LevelUp()
    {
        Level += 1;
    }
}
