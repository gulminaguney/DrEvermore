using UnityEngine;

public class MonsterTrigger : MonoBehaviour
{
    public GameObject monster;
    public AudioSource monsterAudio;
    public float visibleTime = 2f; // Kaç saniye görünür kalsın

    private void Start()
    {
        if (monster != null)
            monster.SetActive(false); // Başta gizli
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Canavar tetiklendi!");

            if (monster != null)
                monster.SetActive(true);

            if (monsterAudio != null)
                monsterAudio.Play();

            Invoke("HideMonster", visibleTime); // Belirli süre sonra kaybol
        }
    }

    void HideMonster()
    {
        if (monster != null)
            monster.SetActive(false);
    }
}
