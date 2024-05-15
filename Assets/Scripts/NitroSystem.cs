using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NitroSystem : MonoBehaviour
{
    public static NitroSystem instance;
    [SerializeField] private Image _nitroImage;
    [SerializeField] private float maxNitro = 100f;
    public float currentNitro;
    public float nitroConsumption = 25f;
    public float nitroRecoveryRate = 10f;
    public float recoveryDelay = 2f;
    public bool isRecovering = false;
    public bool flag;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }
    void Start()
    {
        currentNitro = maxNitro;
        UpdateUI();
    }
    void Update() 
    {
        if (flag == true) {
            UseNitro();
        }
        UpdateUI();
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
    
    public bool GetIsrecovering()
    {
        return isRecovering;
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

    private void UpdateUI() {
        _nitroImage.fillAmount = (currentNitro / maxNitro);
    }
}