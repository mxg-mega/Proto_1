using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderControlManager : MonoBehaviour
{
    private Slider slider;
    [SerializeField] private GameObject player;


    void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void MovePlayer()
    {
        player.transform.position = new Vector3(player.transform.position.x + slider.value,
            player.transform.position.y, player.transform.position.z);
    }
}
