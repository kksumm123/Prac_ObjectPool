using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    // ������Ʈ Ǯ
    // ���� �뷮 8, �뷮�� ������ addedvalue��ŭ ����
    // ������ ������Ʈ�� ��ȿ����, ��ȿ�ð���ŭ Ȱ��ȭ, ���� ��Ȱ��ȭ
    //   ��> ��� �Ǵ��ұ�? ���ο��� üũ�غ���
    // ������Ʈ�� ������ �ڷᱸ���� �ϳ� �ʿ�

    public static ObjectPool instance;

    [SerializeField] int capacity = 8;
    [SerializeField] int addedCapaValue = 4;
    [SerializeField] int curGoCount;
    [SerializeField] int totalGoCount;
    [SerializeField] int validGoCount = 10;
    [SerializeField] float validGoTime = 10;
    [SerializeField] static List<GameObject> opGoList = new List<GameObject>();

    Coroutine validChkCoHandle;
    void Awake()
    {
        instance = this;
    }

    public void InstantiateOP(
        GameObject original, Vector3 position, Quaternion rotation)
    {
        var newGo = Instantiate(original, position, rotation);
        totalGoCount = opGoList.Count;
        if (totalGoCount >= capacity)
            capacity += addedCapaValue;
        
        opGoList.Add(newGo);
        curGoCount++;
        totalGoCount++;

        if (totalGoCount > validGoCount)
        {
            StopCo(validChkCoHandle);
            validChkCoHandle = StartCoroutine(validChkCo(totalGoCount));
        }
    }

    void StopCo(Coroutine handle)
    {
        if (handle != null)
            StopCoroutine(handle);
    }
    private IEnumerator validChkCo(int objCount)
    {
        yield return new WaitForSeconds(validGoTime);
        for (int i = 0; i < objCount - validGoCount; i++)
        {
            opGoList[i].transform.parent = transform;
            opGoList[i].SetActive(false);
        }
        curGoCount = validGoCount;
        totalGoCount = objCount;
    }
}
