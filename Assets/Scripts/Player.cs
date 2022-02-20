using System.Collections;
using System.Collections.Generic;

public class Player
{
    //---[ Constructors ]---
    public Player() { achievements = new List<int>(); }
    public Player(string username_arg, string password_arg): this() 
    {
        this.Username = username_arg;
        this.password = password_arg;
        this.Score = 0; //DEFAULT
    }

    //---[ Variables ]---
    private int id;
    private string username;
    private string password;
    private int score;
    private List<int> achievements; // by achievement id

    //---[ Getters - Setters]---
    public int ID { get { return this.id; } set { this.id = value; } }
    public string Username { get { return this.username; } set { this.username = value; } }
    public string Password { get { return this.password; } set { this.password = value; } }  
    public int Score { get { return this.score; } set { this.score = value; } }
    public List<int> Achievements { get { return this.achievements; } set { this.achievements = value; } }

}
