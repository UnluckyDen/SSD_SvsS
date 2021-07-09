using UnityEngine;
using Players;
public class GameHandler : MonoBehaviour
{
    public Player playerController;
    public HealthSystem healthSystem;
    void Start()
    {
        healthSystem = playerController.healthSystem;
        Debug.Log("Health = " + healthSystem.GetHp());
    }
    public void BtnDamage(int amount)
    {
        healthSystem.Damage(amount);
        Debug.Log("Health = " + healthSystem.GetHp()); 
    }
    public void BtnHeal(int amount)
    {
        healthSystem.Heal(amount);
        Debug.Log("Health = " + healthSystem.GetHp());
    }

}
