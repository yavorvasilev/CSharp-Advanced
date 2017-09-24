namespace _04HospitalVer01
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Stratup
    {
        public static void Main()
        {
            string inputPatientInfo;
            while ((inputPatientInfo = Console.ReadLine()) != "Output")
            {
                var tokens = inputPatientInfo.Split(new char[] { ' '}, StringSplitOptions.RemoveEmptyEntries);
                var departement = new Departement(tokens[0]);
                var doctor = new Doctor(tokens[1] + " " + tokens[2]);
                var patient = new Patient(tokens[3]);
                
            }

            Console.WriteLine();
        }
    }

    public class Hospital
    {
    }

    public class Departement
    {
        private string name;
        private Dictionary<int, List<Patient>> rooms;

        public Departement(string name)
        {
            this.name = name;

            this.rooms = new Dictionary<int, List<Patient>>
            {
                { 1, new List<Patient>(3) },
                { 2, new List<Patient>(3) },
                { 3, new List<Patient>(3) },
                { 4, new List<Patient>(3) },
                { 5, new List<Patient>(3) },
                { 6, new List<Patient>(3) },
                { 7, new List<Patient>(3) },
                { 8, new List<Patient>(3) },
                { 9, new List<Patient>(3) },
                { 10, new List<Patient>(3) },
                { 11, new List<Patient>(3) },
                { 12, new List<Patient>(3) },
                { 13, new List<Patient>(3) },
                { 14, new List<Patient>(3) },
                { 15, new List<Patient>(3) },
                { 16, new List<Patient>(3) },
                { 17, new List<Patient>(3) },
                { 18, new List<Patient>(3) },
                { 19, new List<Patient>(3) },
                { 20, new List<Patient>(3) }
            };
        }

        public bool AddPatientInDepartement(Patient patient)
        {
            foreach (var room in this.rooms)
            {
                if (room.Value.Contains(null))
                {
                    room.Value.Add(patient);
                    return true;
                }
            }
            return false;
        }
    }

    public class Doctor
    {
        public string name;
        private List<Patient> patients;

        public Doctor(string name)
        {
            this.name = name;
            this.patients = new List<Patient>();
        }
        
        public void AddPatientInDoctor(Patient patient)
        {
            this.patients.Add(patient);
        }
    }

    public class Patient
    {
        string name;

        public Patient(string name)
        {
            this.name = name;
        }
    }
}
