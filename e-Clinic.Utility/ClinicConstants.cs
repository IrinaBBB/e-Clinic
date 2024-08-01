namespace e_Clinic.Utility
{
    public static class ClinicConstants
    {
        static ClinicConstants() 
        {
            DeathlyHallowRace = new Dictionary<string, int>();
            DeathlyHallowRace.Add(Wand, 0);
            DeathlyHallowRace.Add(Stone, 0);
            DeathlyHallowRace.Add(Cloack, 0);
        }

        public const string ROLE_ADMIN = "admin";
        public const string ROLE_MANAGER = "manager";
        public const string ROLE_DOCTOR = "doctor";
        public const string ROLE_PATIENT = "patient";
        public const string ROLE_STAFF = "staff";


        // SignalR
        public const string Wand = "wand";
        public const string Stone = "stone";
        public const string Cloack = "cloack";

        public static Dictionary<string, int> DeathlyHallowRace;
    }
}
