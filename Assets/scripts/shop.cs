using System.Collections;
using UnityEngine;

public class shop : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject ObjectShop;
    private void Awake()
    {
        StartCoroutine(sshop());
    }
    IEnumerator sshop()
    {
        ObjectShop.SetActive(true);
        yield return new WaitForEndOfFrame();
        ObjectShop.SetActive(false);
        Destroy(gameObject.GetComponent<shop>());
    }
}
