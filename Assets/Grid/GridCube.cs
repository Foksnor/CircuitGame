using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCube : MonoBehaviour
{
    [SerializeField] private TextMesh textMeshGridNumber;
    [SerializeField] private TextMesh textMeshCharacterRef;
    [SerializeField] private TextMesh textMeshSimulationRef;
    [SerializeField] private float highestElevation;
    [SerializeField] private float lowestElevation;
    [SerializeField] private SpriteRenderer floorSprite;
    [SerializeField] private Sprite[] randomFloorSprite;
    [HideInInspector] public float Height;
    [SerializeField] private GameObject visualElevation = null;
    public Character CharacterOnThisGrid { private set; get; }
    public Character SimulationOnThisGrid { private set; get; }
    public GameObject MovementIndicator, DamageIndicator;

    private void Awake()
    {
        floorSprite.sprite = randomFloorSprite[Random.Range(0, randomFloorSprite.Length)];
        floorSprite.transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 3) * 90);
    }

    public void SetGridReferenceNumber(int numberInGrid)
    {
        textMeshGridNumber.text = numberInGrid.ToString();
    }

    public void SetHeight(Vector3 gridPosition)
    {
        Height = Random.Range(lowestElevation, highestElevation);
        visualElevation.transform.position = gridPosition + new Vector3(0, 0, Height);
    }

    public GameObject GetIndicatorVisual(CardScriptableObject cardScriptable)
    {
        GameObject indicatorvisual;
        switch (cardScriptable.CardType)
        {
            default:
            case CardScriptableObject._CardType.Movement:
                indicatorvisual = MovementIndicator;
                break;
            case CardScriptableObject._CardType.Attack:
                indicatorvisual = DamageIndicator;
                break;
        }
        return indicatorvisual;
    }

    public void SetCharacterOnGrid(Character character)
    {
        if (character.CharacterSimulation != null)
        {
            CharacterOnThisGrid = character;
            textMeshCharacterRef.text = character.name;
        }
        else
        {
            SimulationOnThisGrid = character;
            textMeshSimulationRef.text = character.name;
        }
    }

    public void RemoveCharacterOnGrid(Character character)
    {
        if (CharacterOnThisGrid == character)
        {
            CharacterOnThisGrid = null;
            if (textMeshCharacterRef != null)
                textMeshCharacterRef.text = "";
        }
        else if (SimulationOnThisGrid == character)
        {
            SimulationOnThisGrid = null;
            if (textMeshSimulationRef != null)
                textMeshSimulationRef.text = "";
        }
    }
}
