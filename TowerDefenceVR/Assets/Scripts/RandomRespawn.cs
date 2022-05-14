using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRespawn : MonoBehaviour
{
    public GameObject rangeObject;
    BoxCollider rangeCollider;

    [Header("ImageManager")]
    public GameObject sign;

    private List<GameObject> images;
    private List<Hands> imageHands;

    private void Awake()
    {
        images = new List<GameObject>();
        imageHands = new List<Hands>();
        rangeCollider = rangeObject.GetComponent<BoxCollider>();
    }

    Vector3 Return_RandomPosition()
    {
        Vector3 originPosition = rangeObject.transform.position;
        float range_X = rangeCollider.bounds.size.x;
        float range_Z = rangeCollider.bounds.size.z;
        range_X = Random.Range((range_X / 2) * -1, range_X / 2);
        range_Z = Random.Range((range_Z / 2) * -1, range_Z / 2);
        Vector3 RandomPostion = new Vector3(range_X, 0f, range_Z);

        Vector3 respawnPosition = originPosition + RandomPostion;
        return respawnPosition;
    }

    private void Start()
    {
        // StartCoroutine(RandomRespawn_Coroutine());
    }

    IEnumerator RandomRespawn_Coroutine()
    {
        for (int i=0; i<4; i++)
        {
            yield return new WaitForSeconds(0.8f);
            
            // ���� ��ġ �κп� ������ ���� �Լ� Return_RandomPosition() �Լ� ����
            // GameObject instantCapsul = Instantiate(sign, Return_RandomPosition(), Quaternion.identity);

            GameObject temp = Instantiate(sign, Return_RandomPosition(), Quaternion.identity);
            images.Add(temp);
            // temp.GetComponent<ImageManager>().RandomImage()
        }
    }

}
