using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class Battle : MonoBehaviour
{
    public BattleState state;

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    public Animator animator;

    private int levelToLoad;


    // Start is called before the first frame update
    void Start()
    {

        state = BattleState.START;
        StartCoroutine(SetupBattle());

    }

    IEnumerator SetupBattle()
    {
        Instantiate(playerPrefab, playerBattleStation);
        Instantiate(enemyPrefab, enemyBattleStation);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {
        yield return new WaitForSeconds(2f);
        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    IEnumerator EnemyTurn()
    {
        Debug.Log("It is enemy's turn");
        int randomNumber = Random.Range(1, 4);
        if (randomNumber == 1)
        {
            OnPunch();
        }
        else if (randomNumber == 2)
        {
            OnKick();
        }
        else
        {
            OnBlock();
        }
        yield return new WaitForSeconds(1f);
        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    void PlayerTurn()
    {
        Debug.Log("It is player's turn");
    }
    public void OnFlee()
    {
        FadeToLevel(1);
        Debug.Log("Loaded World Scene");
    }

    public void OnPunch()
    {
        if (state == BattleState.PLAYERTURN)
        {
            StartCoroutine(PlayerAttack());
            Debug.Log("Using Punch");
            return;
        }
        if (state == BattleState.ENEMYTURN)
        {
            Debug.Log("Enemy using Punch");
            return;
        }
    }
    public void OnKick()
    {
        if (state == BattleState.PLAYERTURN)
        {
            StartCoroutine(PlayerAttack());
            Debug.Log("Using Kick");
            return;
        }
        if (state == BattleState.ENEMYTURN)
        {
            Debug.Log("Enemy using Kick");
            return;
        }
    }
    public void OnBlock()
    {
        if (state == BattleState.PLAYERTURN)
        {
            StartCoroutine(PlayerAttack());
            Debug.Log("Using Block");
            return;
        }
        if (state == BattleState.ENEMYTURN)
        {
            Debug.Log("Enemy using Block");
            return;
        }
    }

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
