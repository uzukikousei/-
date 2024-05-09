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
        // ֻ����һ�Σ�����ֻ����һֻ������ԲŷŽ�whileѭ��
        StartCoroutine(SpawnedMonster());
    }

    // Update is called once per frame
    IEnumerator SpawnedMonster()
    {
        while (true) {
            // ���ʱ��
            yield return new WaitForSeconds(Random.Range(1,5));

            // �������
            randomIndex = Random.Range(0, monsterReference.Length);
            // ������Ҳ�����
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
