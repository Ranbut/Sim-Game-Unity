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
        switch (controller.playerOrientation)
        {
            case 0:
                hairRenderer.sprite = hair.frontSprite;
                break;
            case 1:
                hairRenderer.sprite = hair.rightSprite;
                break;
            case 2:
                hairRenderer.sprite = hair.leftSprite;
                break;
            case 3:
                hairRenderer.sprite = hair.backSprite;
                break;
        }
        hairRenderer.color = hairColor;

        //Eyes
        eyesRenderer.color = eyesColor;

        //Shirt
        switch (controller.playerOrientation)
        {
            case 0:
                shirtRenderer.sprite = shirt.frontSprite;
                break;
            case 1:
                shirtRenderer.sprite = shirt.rightSprite;
                break;
            case 2:
                shirtRenderer.sprite = shirt.leftSprite;
                break;
            case 3:
                shirtRenderer.sprite = shirt.backSprite;
                break;
        }

        //Pants
        pantsRenderer.color = pantsColor;
    }
}
