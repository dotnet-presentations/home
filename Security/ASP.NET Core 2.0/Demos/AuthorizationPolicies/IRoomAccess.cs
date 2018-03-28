namespace AuthorizationPolicies
{
    public interface IRoomAccess
    {
        bool CanEnter(string building, string room, string badge);
    }
}
