using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    // 오브젝트 풀
    // 최초 용량 8, 용량을 넘으면 addedvalue만큼 더함
    // 생성된 오브젝트는 유효시간만큼 활성화, 이후 비활성화
    //   ㄴ> 어디서 판단할까? 메인에서 체크해보자

    public static ObjectPool instance;

    [SerializeField] int capacity = 8;
    [SerializeField] int addedCapaValue = 4;
    [SerializeField] float validTime = 10;

    Coroutine validCoHandle;
    void Awake()
    {
        instance = this;
    }

    public static void InstantiateOP(
        GameObject original, Vector3 position, Quaternion rotation) 
    {
        var newGo = Instantiate(original, position, rotation);

    }
}
