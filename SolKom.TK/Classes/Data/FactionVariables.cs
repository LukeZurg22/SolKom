namespace SolKom.TK.Classes.Data
{
    public class PoliticalStatus
    {
        public Faction? MASTER;
        public bool CAN_DECLARE_WARS;
        public bool CAN_DECLARE_INDEPENDENCE;
        public bool CAN_ALLY_OTHER_FACTIONS;
        public bool CAN_JOIN_WARS;
        public bool CAN_DECLINE_WARS;
        public bool CAN_BUILD_FLEETS;
        public bool CAN_PIONEER;
    }


    public static class PoliticalStatuses
    {
        public static readonly PoliticalStatus INDEPENDENT = new()
        {
            CAN_DECLARE_WARS = true,
            CAN_DECLARE_INDEPENDENCE = false,
            CAN_ALLY_OTHER_FACTIONS = true,
            CAN_JOIN_WARS = true,
            CAN_DECLINE_WARS = false,
            CAN_BUILD_FLEETS= true,
            CAN_PIONEER = true,
        };
        public static readonly PoliticalStatus SUBORDINATE = new()
        {
            CAN_DECLARE_WARS = false,
            CAN_DECLARE_INDEPENDENCE = true,
            CAN_ALLY_OTHER_FACTIONS = false,
            CAN_JOIN_WARS = true,
            CAN_DECLINE_WARS = false,
            CAN_BUILD_FLEETS = true,
            CAN_PIONEER = true,
        };

    }

}
