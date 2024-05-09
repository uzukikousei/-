using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject[] monsterReference;

    private GameObject spawnedMonster;

    [SerializeField]
    private Transform leftPos, rightPos;

    private int randomIndex;
    private int randomSide;

    void Start()
    {
        // 只调用一次，所以只产生一只怪物，所以才放进while循环
        StartCoroutine(SpawnedMonster());
    }

    // Update is called once per frame
    IEnumerator SpawnedMonster()
    {
        while (true) {
            // 随机时间
            yield return new WaitForSeconds(Random.Range(1,5));

            // 随机怪物
            randomIndex = Random.Range(0, monsterReference.Length);
            // 随机左右产卵器
            randomSide = Random.Range(0, 2);

            spawnedMonster = Instantiate(monsterReference[randomIndex]);

            if (randomSide == 0)
            {
                spawnedMonster.transform.position = leftPos.position;
                spawnedMonster.GetComponent<Monster>().speed = Random.Range(3, 10);
            }
            else
            {
                spawnedMonster.transform.position = rightPos.position;
                spawnedMonster.GetComponent<Monster>().speed = -Random.Range(3, 10);
                spawnedMonster.transform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }
}
