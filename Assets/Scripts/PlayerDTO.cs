public class PlayerDTO
{
    private string nickname;
    private int score;
    private float pos_x;
    private float pos_y;
    private float pos_z;
    private float rot_x;
    private float rot_y;
    private float rot_z;
    private bool is_jump;
    private bool is_walk;
    private bool is_run;

    public string Nickname { get => nickname; set => nickname = value; }
    public int Score { get => score; set => score = value; }
    public float Pos_x { get => pos_x; set => pos_x = value; }
    public float Pos_y { get => pos_y; set => pos_y = value; }
    public float Pos_z { get => pos_z; set => pos_z = value; }
    public float Rot_x { get => rot_x; set => rot_x = value; }
    public float Rot_y { get => rot_y; set => rot_y = value; }
    public float Rot_z { get => rot_z; set => rot_z = value; }
    public bool Is_jump { get => is_jump; set => is_jump = value; }
    public bool Is_walk { get => is_walk; set => is_walk = value; }
    public bool Is_run { get => is_run; set => is_run = value; }
}
