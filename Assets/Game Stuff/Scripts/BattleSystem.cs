using TMPro;
using UnityEngine;

public enum BattleState { START, PLAYER_TURN, ENEMY_TURN, WIN, LOSE }

public class BattleSystem : MonoBehaviour
{
    [SerializeField] BattleState state;

    [Space(3)]

    [SerializeField] Vector3[] spawnPoints;

    [Space]

    [SerializeField] GameObject player;
    [SerializeField] TextMeshProUGUI playerName;
    [SerializeField] GameObject[] enemies;

    private void Start()
    {
        state = BattleState.START;
        PrepareBattle();
    }

    void PrepareBattle()
    {
        player.transform.position = spawnPoints[0];
        Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPoints[1], Quaternion.identity);
    }
}
