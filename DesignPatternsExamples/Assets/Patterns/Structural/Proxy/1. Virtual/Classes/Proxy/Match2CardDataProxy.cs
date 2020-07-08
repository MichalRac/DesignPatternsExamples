using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ThirdPartyLibrary;

public class Match2CardDataProxy : IMatchable
{
    private int id;
    public int Id
    {
        get => id;
        set => id = value;
    }

    private Match2CardData match2CardData;
    private Match2CardData Match2CardData
    {
        get
        {
            if(match2CardData == null)
            {
                match2CardData = new Match2CardData(Id);
            }

            return match2CardData;
        }
    }

    public Match2CardDataProxy(int id)
    {
        Id = id;
    }

    public Color Color
    {
        get => Match2CardData.Color;
        set => Match2CardData.Color = value;
    }

    public string Text
    {
        get => Match2CardData.Text;
        set => Match2CardData.Text = value;
    }


}
