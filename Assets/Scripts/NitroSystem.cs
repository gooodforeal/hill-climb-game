using UnityEngine;
using System.Collections;

public class NitroSystem : MonoBehaviour
{
    public float maxNitro = 100f;
    public float currentNitro;
    public float nitroConsumption = 25f;
    public float nitroRecoveryRate = 10f;
    public float recoveryDelay = 2f;
    public bool isRecovering = false;
    public bool flag;
    void Start()
    {
        currentNitro = maxNitro;
    }
    void Update() 
    {
        if (flag == true) {
            UseNitro();
        }
    }

    public void UseNitro()
    {
        if (currentNitro > 0){
            currentNitro -= nitroConsumption * Time.deltaTime;

            if (currentNitro < 0)
                currentNitro = 0;
        }
    }

    public float GetNitro()
    {
        return currentNitro;
    }

    public void StartNitroRecover()
    {
        if (currentNitro < maxNitro && isRecovering == false)
            StartCoroutine(RecoverNitro());
    }

    IEnumerator RecoverNitro()
    {
        isRecovering = true;
        yield return new WaitForSeconds(recoveryDelay);

        while (currentNitro < maxNitro)
        {
            currentNitro += nitroRecoveryRate * Time.deltaTime;
            yield return null;
        }

        currentNitro = maxNitro;
        isRecovering = false;
    }
}