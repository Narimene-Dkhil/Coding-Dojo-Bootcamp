#pragma warning disable CS8618

namespace BeltExam.Models;

public class MyViewModel
{
    public User LoggedInUser { get; set; } 
    public User User { get; set; }
    public List<User> AllUsers { get; set; }
    public Post Post { get; set; }
    public List<Post> AllPosts { get; set; }

}