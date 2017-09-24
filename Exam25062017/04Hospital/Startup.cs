namespace _04Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var doctorPations = new Dictionary<string, List<string>>();
            var departmentsRoom = new Dictionary<string, Dictionary<int, List<string>>>();
            //var pattern = @"([a-zA-Z]{1,100})\s+([a-zA-Z]{1,20} [a-zA-Z]{1,20})\s+(.{1,20})";
            var unickPationts = new HashSet<string>();

            var line = Console.ReadLine().Trim();
            var acceptedPatient = false;
            var unickPationt = false;

            while (line != "Output")
            {
                var tokens = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Count() == 4)
                {
                    //var tokens = Regex.Match(line, pattern);
                    var departement = tokens[0];
                    var doctor = tokens[1] + " " + tokens[2];
                    var patient = tokens[3];

                    if (!unickPationts.Contains(patient))
                    {
                        unickPationts.Add(patient);
                        unickPationt = true;
                    }
                    else
                    {
                        line = Console.ReadLine();
                        continue;
                    }

                    if (!departmentsRoom.ContainsKey(departement))
                    {
                        departmentsRoom[departement] = new Dictionary<int, List<string>>();
                        departmentsRoom[departement][1] = new List<string>();
                    }
                    if (!departmentsRoom[departement].ContainsKey(20))
                    {
                        //var numberOfPatients = departmentsRoom[departement].Sum(x => x.Value.Count);
                        var currentRoom = departmentsRoom[departement].Last().Key;
                        if (departmentsRoom[departement][currentRoom].Count < 3)
                        {
                            departmentsRoom[departement][currentRoom].Add(patient);
                            acceptedPatient = true;
                        }
                        else
                        {
                            currentRoom += 1;
                            departmentsRoom[departement][currentRoom] = new List<string>();
                            departmentsRoom[departement][currentRoom].Add(patient);
                            acceptedPatient = true;
                        }
                    }
                    else
                    {
                        if (departmentsRoom[departement][20].Count < 3)
                        {
                            departmentsRoom[departement][20].Add(patient);
                            acceptedPatient = true;
                        }
                        else
                        {
                            acceptedPatient = false;
                        }
                    }
                    if (acceptedPatient)
                    {
                        if (!doctorPations.ContainsKey(doctor))
                        {
                            doctorPations[doctor] = new List<string>();
                        }
                        doctorPations[doctor].Add(patient);
                    }
                }
                acceptedPatient = false;
                unickPationt = false;

                line = Console.ReadLine();
            }
            var printCommand = Console.ReadLine().Trim();

            while (printCommand != "End")
            {
                var tokens = printCommand.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                if (tokens.Count == 1)
                {
                    if (departmentsRoom.ContainsKey(tokens[0]))
                    {
                        var department = tokens[0];
                        PrintAllPatients(departmentsRoom, department);
                    }
                }
                else
                {
                    int room;
                    if (int.TryParse(tokens[1], out room))
                    {
                        var department = tokens[0];
                        if (departmentsRoom.ContainsKey(tokens[0]) && departmentsRoom[department].ContainsKey(room))
                        {
                            PrintRoom(departmentsRoom, department, room);
                        }
                    }
                    else
                    {
                        if (doctorPations.ContainsKey(printCommand))
                        {
                            var doctor = printCommand;
                            PrintDoctorsPatients(doctorPations, doctor);
                        }

                    }
                   
                }

                printCommand = Console.ReadLine();
            }
        }

        private static void PrintRoom(Dictionary<string, Dictionary<int, List<string>>> departmentsRoom, string department, int room)
        {
            foreach (var patient in departmentsRoom[department][room].OrderBy(x => x))
            {
                Console.WriteLine(patient);
            }
        }

        private static void PrintDoctorsPatients(Dictionary<string, List<string>> doctorPations, string doctor)
        {
            foreach (var doctorName in doctorPations[doctor].OrderBy(x => x))
            {
                Console.WriteLine(doctorName);
            }
        }

        private static void PrintAllPatients(Dictionary<string, Dictionary<int, List<string>>> departmentsRoom, string department)
        {
            foreach (var room in departmentsRoom[department])
            {
                foreach (var patient in room.Value)
                {
                    Console.WriteLine(patient);
                }
            }
        }
    }
}
