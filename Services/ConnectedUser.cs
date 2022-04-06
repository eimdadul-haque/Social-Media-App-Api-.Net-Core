namespace Social_Media_App_Api_.Net_Core.Services
{

    public class ConnectionModel
    {
        public string Id { get; set; }
        public string Name { get; set; }

    }
    public class ConnectedUser
    { 
        public static List<ConnectionModel> Ids = new List<ConnectionModel>();
    }
}
