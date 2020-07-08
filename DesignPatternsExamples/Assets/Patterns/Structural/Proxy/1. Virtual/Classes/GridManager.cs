using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private Match2Card match2CardPrefab;
    [SerializeField] private Vector2Int gridSize;

    public static int numberOfCards = 1;
    public const int ID_MODIFIER = 3;

    public static Action<Match2Card> SelectCard;

    private void OnEnable()
    {
        SelectCard += Select;
    }

    private void OnDisable()
    {
        SelectCard -= Select;
    }

    private void Start()
    {
        numberOfCards = gridSize.x * gridSize.y;
        numberOfCards = numberOfCards % 2 == 0 ? numberOfCards : numberOfCards - 1;

        var idsNumber = numberOfCards / 2;
        List<int> idsToAssign = new List<int>();

        for(int i = 0; i < idsNumber; i++)
        {
            var idToAdd = i * ID_MODIFIER;

            idsToAssign.Add(idToAdd);
            idsToAssign.Add(idToAdd);
        }

        for (int i = 0; i < numberOfCards; i++)
        {
            int randomIdToSetup = UnityEngine.Random.Range(0, idsToAssign.Count - 1);

            var newCard = Instantiate(match2CardPrefab, transform);
            newCard.Setup(idsToAssign[randomIdToSetup]);

            idsToAssign.RemoveAt(randomIdToSetup);
        }
    }

    private Match2Card selectedBuf;
    private void Select(Match2Card newSelected)
    {
        if(selectedBuf == null)
        {
            selectedBuf = newSelected;
            selectedBuf.Lookup();
            return;
        }

        newSelected.Lookup();

        StartCoroutine(newSelected.Hide());
        StartCoroutine(selectedBuf.Hide());

        if (selectedBuf.GetID() == newSelected.GetID() && selectedBuf != newSelected)
        {
            selectedBuf.HighLight();
            newSelected.HighLight();

            Destroy(selectedBuf.gameObject, 2f);
            Destroy(newSelected.gameObject, 2f);
        }
        selectedBuf = null;
    }
}
