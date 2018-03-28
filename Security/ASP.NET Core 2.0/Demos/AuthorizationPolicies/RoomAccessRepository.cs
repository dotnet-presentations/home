using System.Collections.Generic;


namespace AuthorizationPolicies
{
    public class RoomAccessRepository : IRoomAccess
    {
        IDictionary<string, IDictionary<string, string>> _BuildingAccess = new Dictionary<string, IDictionary<string, string>>
        {
            { "18", new Dictionary<string, string> { { "911", "2300FL" }, { "999", "2300FL"} } },
            { "27", new Dictionary<string, string> { { "999", "1820A" } } }
        };

        public bool CanEnter(string building, string room, string badge)
        {
            if (_BuildingAccess.ContainsKey(building))
            {
                var badgeToRoom = _BuildingAccess[building];

                var lookup = new KeyValuePair<string, string>(badge, room);

                if (badgeToRoom.Contains(lookup))
                {
                    return true;
                }

            }

            return false;
        }
    }
}
