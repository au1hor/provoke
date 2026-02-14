using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera CameraFigth;
    public float duration = 0.2f;
    public float magnitude = 0.3f;
    Vector3 originalPosition;
    
    public static CameraManager Instance{get;private set;}
    private void Awake() {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }else
        {
            Instance = this;
        }
    }
    private void Start() {
        originalPosition = CameraFigth.transform.position;
    }
    public void shake()
    {
        StartCoroutine(ShakeCoroutine());
    }
    IEnumerator ShakeCoroutine()
    {
        float timer = 0f;
        while (timer < duration)
        {
            float x = Random.Range(-1f,1f) * magnitude;
            float y = Random.Range(-1f,1f) * magnitude;
            CameraFigth.transform.localPosition = originalPosition + new Vector3(x,y,0);
            timer += Time.deltaTime;
            yield return null;
        }
        CameraFigth.transform.localPosition = originalPosition;
    }
}
