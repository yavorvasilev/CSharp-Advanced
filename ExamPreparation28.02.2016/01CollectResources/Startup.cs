namespace _01CollectResources
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            //var sumOfResources = 0;
            var resourceField = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var numberOfCollectionPath = int.Parse(Console.ReadLine());
            var maxResources = 0;

            for (int i = 0; i < numberOfCollectionPath; i++)
            {
                var startAndStep = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var start = int.Parse(startAndStep.First());
                var step = int.Parse(startAndStep.Last());
                int resources = CollectResources(resourceField, start, step);

                if (resources > maxResources)
                {
                    maxResources = resources;
                }
            }

            Console.WriteLine(maxResources);


        }

        private static int CollectResources(string[] resourceField, int start, int step)
        {
            string[] coppyField = new string[resourceField.Length];
            Array.Copy(resourceField, coppyField, resourceField.Length);

            var resource = coppyField[start];
            int countResource = ExtractResource(resource);
            var index = start;

            if (countResource != 0)
            {
                coppyField[index] = "collected";
            }
            
            while (resource != "collected")
            {
                index += step;

                if (index >= coppyField.Length)
                {
                    index %= coppyField.Length;
                    resource = coppyField[index];
                    countResource += ExtractResource(resource);
                }
                else
                {
                    resource = coppyField[index];
                    countResource += ExtractResource(resource);
                }
                if (ExtractResource(resource) != 0)
                {
                    coppyField[index] = "collected";
                }
            }


            return countResource;
        }

        private static int ExtractResource(string resource)
        {
            var resourceTokens = resource.Split('_');
            var resourceName = resourceTokens.First();

            switch (resourceName)
            {
                case "stone":
                case "gold":
                case "wood":
                case "food":
                    if (resourceTokens.Length == 2)
                    {
                        return int.Parse(resourceTokens.Last());
                    }
                    return 1;
                default:
                    return 0;
            }
        }
    }
}
