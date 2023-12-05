using System;


public class PlayerDTO 
{
    private String nickname; // 이름
    private int score; // 사용자의 최고 점수
    // 사용자의 위치
    private float pos_x;
    private float pos_y;
    private float pos_z;
    // 사용자의 회전 값
    private float rot_x;
    private float rot_y;
    private float rot_z;
    // 사용자 에니매이션 bool 값
    private bool is_jump;
    private bool is_walk;
    private bool is_run;

    public PlayerDTO(string nickname, int score, float posX, float posY, float posZ, float rotX, float rotY, float rotZ, bool isJump, bool isWalk, bool isRun)
    {
        this.nickname = nickname;
        this.score = score;
        pos_x = posX;
        pos_y = posY;
        pos_z = posZ;
        rot_x = rotX;
        rot_y = rotY;
        rot_z = rotZ;
        is_jump = isJump;
        is_walk = isWalk;
        is_run = isRun;
    }
    
    // 게터(Getter) 메서드
    public String getNickname() { return nickname; }

    public int getScore() { return score; }

    public float getPosX() { return pos_x; }

    public float getPosY() { return pos_y; }

    public float getPosZ() { return pos_z; }

    public float getRotX() { return rot_x; }
    
    public float getRotY() { return rot_y; }

    public float getRotZ() { return rot_z; }

    public bool isJump() { return is_jump; }

    public bool isWalk() { return is_walk; }

    public bool isRun() { return is_run; }

    // 세터(Setter) 메서드
    public void setNickname(String nickname) { this.nickname = nickname; }

    public void setScore(int score) { this.score = score; }

    public void setPosX(float pos_x) { this.pos_x = pos_x; }

    public void setPosY(float pos_y) { this.pos_y = pos_y; }

    public void setPosZ(float pos_z) { this.pos_z = pos_z; }

    public void setRotX(float rot_x) { this.rot_x = rot_x; }

    public void setRotY(float rot_y) { this.rot_y = rot_y; }

    public void setRotZ(float rot_z) { this.rot_z = rot_z; }

    public void setJump(bool isJump) { this.is_jump = isJump; }

    public void setWalk(bool isWalk) { this.is_walk = isWalk; }

    public void setRun(bool isRun) { this.is_run = isRun; }
}
