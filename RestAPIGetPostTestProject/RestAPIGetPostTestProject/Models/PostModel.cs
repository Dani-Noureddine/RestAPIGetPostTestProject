public class PostModel
{
    public int UserId { get; set; }
    public int? Id { get; set; }
    public string? Title { get; set; }
    public string? Body { get; set; }

    public static bool IsInAscendingOrder(List<PostModel> posts)
    {
        bool isInAscendingOrder = true;
        for (int i = 1; i <= posts.Count; i++)
        {
            var user = posts[i - 1];
            if (user.Id != i)
            {
                isInAscendingOrder = false;
                break;
            }
        }
        return isInAscendingOrder;
    }
}

