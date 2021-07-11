using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    // 오브젝트 풀
    // 최초 용량 8, 용량을 넘으면 addedvalue만큼 더함
    // 생성된 오브젝트는 유효개수, 유효시간만큼 활성화, 이후 비활성화
    //   ㄴ> 어디서 판단할까? 메인에서 체크해보자
    // 오브젝트를 관리할 자료구조가 하나 필요

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
