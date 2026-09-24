using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro; // per usare il Text

public class battleManager : MonoBehaviour
{
    // generali --------------
    public TextMeshProUGUI currentTargetText;

    List<int> health = new List<int>();

    int target_turn = 0; // il player è lo 0

    List<int> skip_turn = new List<int>();
    int skip_turn_len = 0;


    int damage = 0;
    int target = 1;

    // player ----------------
    public TextMeshProUGUI rageCounter;
    public Image rageMode;

    public TextMeshProUGUI playerHealth;

    public int max_rage = 10;
    int rage = 0;

    public int player_max_health = 20;

    // enemy -------------------
    public enemyManager enemyManager;

    public int enemy_max_health = 5;
    public int enemy_number = 3;

    public TextMeshProUGUI E1;
    public TextMeshProUGUI E2;
    public TextMeshProUGUI E3;

    List<TextMeshProUGUI> enemyHealth;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health.Add(player_max_health); // aggiungo il player alla lista dei target. Lui sarà sempre in health[0]

        for(int i=0; i<enemy_number; i++){
            health.Add(enemy_max_health);        // i nemici saranno target[1], target[2], ...
        }

        Debug.Log(health);

        // set dei testi del counter e della vita
        rageCounter.text = "Rage: " + rage.ToString() + "/" + max_rage.ToString();

        playerHealth.text = "Your Health: " + health[0].ToString() + "/" + player_max_health.ToString();

        currentTargetText.text = "Current Target: "+target.ToString();

        enemyHealth = new List<TextMeshProUGUI> {E1, E2, E3};
        for(int i=0; i<enemy_number; i++){
            enemyHealth[i].text = "Enemy"+i.ToString()+" Health: " + health[i+1].ToString() + "/" + enemy_max_health.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextTurn(){
        target_turn += 1;
        if(target_turn>=enemy_number+1){ //se si supera il numero di target (player + numero nemici), si ritorna al player
            target_turn = 0;
        }

        Debug.Log("Adesso è il turno di: "+target_turn.ToString());

        for(int i=0;i < skip_turn_len;i++){
            if(target_turn==skip_turn[i]){ 
                Debug.Log("Salta il turno");
                nextTurn();
                return; // se il nemico è morto la funzione si deve fermare qui
            }
        }

        if(target_turn==0){
            target = 1; // i nemici settano target=0, che è il player. questo evita che il player si colpisca da solo, se non sceglie nessun target
            return;
        }

        enemyManager.think();
    }

    public void increaseRage(int n = 0){
        rage += n;
        rage = Mathf.Max(0, rage);
        rageCounter.text = "Rage: " + rage.ToString() + "/" + max_rage.ToString();

        if(rage>max_rage){
            rageMode.gameObject.SetActive(true);
        }
    }

    public void attack(){
        health[target] -= damage;

        if(target==0 && health[target] <= 0){ // target == 0 è il player, se la sua vita scende sotto lo 0 è game over
            gameOver();
        }

        if(health[target] <= 0){ // se la vita di un nemico scende sotto lo zero, gli faccio sempre skippare il turno. di sicuro non può essere il player pk altrimenti sarebbe game over
            skip_turn.Add(target);
            skip_turn_len+=1;
        }

        playerHealth.text = "Your Health: " + health[0].ToString() + "/" + player_max_health.ToString(); // updatiamo la scritta della vita

        for(int i=0; i<enemy_number; i++){
            enemyHealth[i].text = "Enemy"+i.ToString()+" Health: " + health[i+1].ToString() + "/" + enemy_max_health.ToString();
        }


        nextTurn();
    }
    // ------------ per semplificare il lavoro con le ui, i target, damage, e rage acquisita li settiamo con funzioni separate -----------------
    public void setTarget(int t){
        target = t;

        currentTargetText.text = "Current Target: "+target.ToString();
    }

    public void setDamage(int d){
        damage = d;
    }

    void gameOver(){
        // non ci ho ancora messo niente
    }
}
