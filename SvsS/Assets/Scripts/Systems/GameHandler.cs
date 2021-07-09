using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public HealthSystem healthSystem;
    public Transform HpBar;
    void Start()
    {
        healthSystem = new HealthSystem(100);
        Debug.Log("Health = " + healthSystem.GetHp());
        Transform hpBarTransform =  Instantiate(HpBar, new Vector3(0, 1), Quaternion.identity);
        hpBarTransform.parent = transform.Find("Player");
        HealthBar healthBar = hpBarTransform.GetComponent<HealthBar>(); 
        healthBar.Setup(healthSystem);
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
