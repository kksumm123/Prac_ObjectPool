using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    // ������Ʈ Ǯ
    // ���� �뷮 8, �뷮�� ������ addedvalue��ŭ ����
    // ������ ������Ʈ�� ��ȿ�ð���ŭ Ȱ��ȭ, ���� ��Ȱ��ȭ
    //   ��> ��� �Ǵ��ұ�? ���ο��� üũ�غ���

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
