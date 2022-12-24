using UnityEngine;
using TMPro;

public class S_CtrlMonedas : MonoBehaviour
{
    [SerializeField] private GameObject[] Monedas;
    [SerializeField] private TextMeshProUGUI TextoMonedas;

    int MonedasARecoger;

    void Start()
    {
        Monedas = GameObject.FindGameObjectsWithTag("Coin");
        MonedasARecoger = Monedas.Length;
    }

    private void Update()
    {
        int MonedasRecogidas = MonedasARecoger - GameObject.FindGameObjectsWithTag("Coin").Length;
        TextoMonedas.text = $"{MonedasRecogidas}/{MonedasARecoger}";
    }

}
