using UnityEngine;

public class PlayerAppearance : MonoBehaviour
{

    private PlayerController controller;

    [Header("Hair")]
    public Hair hair;
    public Color hairColor;
    public SpriteRenderer hairRenderer;
    [Space(5)]
    [Header("Eyes")]
    public Color eyesColor;
    public SpriteRenderer eyesRenderer;
    [Space(5)]
    [Header("Shirt")]
    public Shirt shirt;
    public SpriteRenderer shirtRenderer;
    [Space(5)]
    [Header("Pants")]
    public Color pantsColor;
    public SpriteRenderer pantsRenderer;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateApperance();
    }

    private void UpdateApperance()
    {
        //Hair
        hairRenderer.sprite = hair.frontSprite;
        hairRenderer.color = hairColor;

        //Eyes
        eyesRenderer.color = eyesColor;

        //Shirt
        shirtRenderer.sprite = shirt.frontSprite;

        //Pants
        pantsRenderer.color = pantsColor;
    }
}
