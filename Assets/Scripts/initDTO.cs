using System;

[Serializable]
public class initDTO 
{
    public String nickname;
    public int score;
    public bool islogin;

    public initDTO(string nickname, int score, bool islogin)
    {
        this.nickname = nickname;
        this.score = score;
        this.islogin = islogin;
    }

    public string Nickname
    {
        get => nickname;
        set => nickname = value;
    }

    public int Score
    {
        get => score;
        set => score = value;
    }

    public bool Islogin
    {
        get => islogin;
        set => islogin = value;
    }
}
