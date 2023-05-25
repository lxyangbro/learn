using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 玩家当前的数据
/// </summary>
public class PlayerModel:SingletonPatternBase<PlayerModel>
{
    









    public int money=666;//玩家的金钱

    public int diamond = 8888;//玩家的钻石

    public void Show()
    {
        Debug.Log(money);
        Debug.Log(diamond);
    }




}
