using System.Collections;
using System.Collections.Generic;

public class Player
{
    //---[ Constructors ]---
    public Player() { achievements = new List<int>(); }
    public Player(int id_arg, 
                  string username_arg, 
                  string password_arg, 
                  string name_arg, 
                  int score_arg, 
                  int games_played_arg, 
                  List<int> achievements_arg): this() 
    {
        this.ID = id_arg;
        this.Username = username_arg;
        this.password = password_arg; //psw
        this.Name = name_arg;
        this.Score = score_arg;
        this.Games_played = games_played_arg;
        this.Achievements = achievements_arg;
    }

    //---[ Variables ]---
    private int id;
    private string username;
    private string password;
    private string name;
    //private image profile_picture;
    private int score;
    private int games_played;
    private List<int> achievements; // by achievement id

    //---[ Getters - Setters]---
    public int ID { get { return this.id; } set { this.id = value; } }
    public string Username { get { return this.username; } set { this.username = value; } }
    public string Password { get { return this.password; } /*set { this.password = value; }*/ }
    public string Name { get { return this.name; } set { this.name = value; } }
    public int Score { get { return this.score; } set { this.score = value; } }
    public int Games_played { get { return this.games_played; } set { this.games_played = value; } }
    public List<int> Achievements { get { return this.achievements; } set { this.achievements = value; } }
}
