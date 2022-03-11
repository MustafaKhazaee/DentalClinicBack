namespace DentalClinic.Domain.Static {
    public static class Permissions {
        public class AppUser {  // 1
            public const string Get = "r, 00";
            public const string Post = "r, 01";
            public const string Put = "r, 02";
            public const string Delete = "r, 03";
        }
        public class Doctor {  // 2
            public const string Get = "r, 10";
            public const string Post = "r, 11";
            public const string Put = "r, 12";
            public const string Delete = "r, 13";
        }
        public class Employee {  // 3
            public const string Get = "r, 20";
            public const string Post = "r, 21";
            public const string Put = "r, 22";
            public const string Delete = "r, 23";
        }
        public class Expense {  // 4
            public const string Get = "r, 30";
            public const string Post = "r, 31";
            public const string Put = "r, 32";
            public const string Delete = "r, 33";
        }
        public class Patient {  // 5
            public const string Get = "r, 40";
            public const string Post = "r, 41";
            public const string Put = "r, 42";
            public const string Delete = "r, 43";
        }
        public class Role {  // 6
            public const string Get = "r, 50";
            public const string Post = "r, 51";
            public const string Put = "r, 52";
            public const string Delete = "r, 53";
        }
        public class Visit {  // 7
            public const string Get = "r, 60";
            public const string Post = "r, 61";
            public const string Put = "r, 62";
            public const string Delete = "r, 63";
            public const string Live = "r, 64";
        }
        public class Report {  // 7
            public const string Get = "r, 70";
        }
    }
}