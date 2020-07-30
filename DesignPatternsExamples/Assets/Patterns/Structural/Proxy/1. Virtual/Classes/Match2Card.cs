using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ThirdPartyLibrary;
using UnityEngine.UI;

public class Match2Card : MonoBehaviour
{
    private IMatchable match2CardData;

    [SerializeField] private Image image;
    [SerializeField] private Text text;

    public void Setup(int id)
    {
        match2CardData = new Match2CardDataProxy(id);
        //match2CardData = new Match2CardData(id);
    }

    public int GetID()
    {
        return match2CardData.Id;
    }

    public void HighLight()
    {
        image.color = Color.yellow;
    }

    public void Select()
    {
        GridManager.SelectCard(this);
    }

    public void Lookup()
    {
        image.color = match2CardData.Color;
        text.text = match2CardData.Text;
    }

    public IEnumerator Hide()
    {
        yield return new WaitForSeconds(1.95f);

        image.color = Color.white;
        text.text = string.Empty;
    }
}
