using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ProjPool : MonoBehaviour
{
    public bool useObjectPooling = true;

    public Projectiles projPrefab;

    public int projActive;
    public int projInactive;

    public ObjectPool<Projectiles> projPoolOne;

    private void Start()
    {
        projPoolOne = new ObjectPool<Projectiles>(createFunc: InstantiatePoolProj, actionOnGet: GetProjFromPool, actionOnRelease: ReturnProjToPool);
        /*InvokeRepeating(nameof(InstantiateProj), 1.0f, 1.0f);*/
    }

    private void Update()
    {
        projActive = projPoolOne.CountActive;
        projInactive = projPoolOne.CountInactive;
    }

    private Projectiles InstantiatePoolProj()
    {
        return Instantiate(projPrefab);
    }

    private void GetProjFromPool(Projectiles proj)
    {
        proj.transform.position = transform.position;
        proj.transform.rotation = transform.rotation;
        proj.SetPool(projPoolOne);
        proj.gameObject.SetActive(true);
    }

    private void ReturnProjToPool(Projectiles proj)
    {
        proj.gameObject.SetActive(false);
    }

    public void InstantiateProj()
    {
        if (useObjectPooling)
        {
            projPoolOne.Get();
        }
        else { Instantiate(projPrefab, transform.position, transform.rotation);
        }
    }
}
