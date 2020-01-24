using UnityEngine;
using Interfaces;

public class CharacterLifeCycle : MonoBehaviour, IKillable
{
    //private PlayerData to know the player's data

    //private PlayerStats to know the player's data

    public KillableData killableData;
    public float Health { get; private set; }
    public bool IsDead { get; private set; }


    void Start()
    {
        Health = killableData.maxHealth;
    }


    public void Heal(float amount)
    {
        // Do some calculations
        // Like if it has buff heal amount, increase amount
        float newHealth = Health + amount;

        Health = newHealth > killableData.maxHealth ? killableData.maxHealth : newHealth;
    }

    public void Hit(float damage)
    {
        Debug.Log(damage + " hit damage");
        // Do some calculations
        // Like decrease the damage if using an armor
        // Like if it's fire damage, than it could get a burning status
        // And then...
        Health -= damage;
        if (Health <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        IsDead = true;
        // Do some Death Animations
        // Set a timer to Destroy the object and then...
        // TODO: put the float number into a Global variable (like a config or something)
        Destroy(gameObject, 10.0f);
    }

}
