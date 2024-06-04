namespace Forum.Core.Common.Exceptions
{
    public class CommentNotFoundException : Exception
    {
        public CommentNotFoundException() : base("Comment not found in database")
        {
        }
    }
}
