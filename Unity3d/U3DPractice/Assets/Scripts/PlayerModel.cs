using UnityEngine;

public class PlayerModel
{
    // 构造函数私有化，保证外部不能new
    private PlayerModel()
    {
    }

    private static PlayerModel instance;

    public int coin = 1000;
    public int diamond = 0;
    public void Show()
    {
        Debug.Log("coin = " + coin);
        Debug.Log("diamond = " + diamond);
    }

    public void Add()
    {
        coin = coin + 500;
        diamond = diamond + 100;
    }

    public static PlayerModel Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new PlayerModel();
            }

            return instance;
        }
    }
}
