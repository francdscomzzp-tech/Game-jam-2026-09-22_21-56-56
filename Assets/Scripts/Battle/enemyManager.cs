using UnityEngine;

public class enemyManager : MonoBehaviour
{
    public battleManager battleManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void think(){
        battleManager.setTarget(0);
        battleManager.setDamage(2);
        battleManager.attack();
    }
}
