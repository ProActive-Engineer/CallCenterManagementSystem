namespace PbxHub.Admin.App.Helpers
{
    public enum AuthLevel 
    { 
        Administrator = 1, 
        CustomerService = 2, 
        CustomerAdmin = 3, 
        User = 4 
    }

    public class Constant
    {
        public static string APP_NAME = "Cdyne PBX";
        public static string CLAIM_AUTH_TYPE = "Administrator";
        public static string STORAGE_ITEM_USER_KEY = "User";
        public static string STORAGE_ITEM_NOTIFICATION_KEY = "Notifications";        
    }
}
