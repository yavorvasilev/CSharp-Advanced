namespace _12LegendaryFarming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LegendaryFarming
    {
        public static void Main()
        {
            var materials = new Dictionary<string, int>();
            var keyMaterials = new Dictionary<string, int>() {
                { "shards", 0 },
                { "fragments", 0 },
                { "motes", 0 }
            };

            var flagShadowmourne = false;
            var flagValanyr = false;
            var flagDragonwrath = false;

            var input = Console.ReadLine();

            while (!string.IsNullOrEmpty(input))
            {
                var quantityAndMaterial = input.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0, j = 1; i < quantityAndMaterial.Length; i += 2, j += 2)
                {
                    var quantity = int.Parse(quantityAndMaterial[i]);
                    var material = quantityAndMaterial[j].ToLower();

                    if (material == "shards")
                    {
                        keyMaterials[material] += quantity;
                        if (keyMaterials["shards"] >= 250)
                        {
                            flagShadowmourne = true;
                            keyMaterials["shards"] -= 250;
                            break;
                        }
                    }
                    else if (material == "fragments")
                    {
                        keyMaterials[material] += quantity;
                        if (keyMaterials["fragments"] >= 250)
                        {
                            flagValanyr = true;
                            keyMaterials["fragments"] -= 250;
                            break;
                        }
                    }
                    else if (material == "motes")
                    {
                        keyMaterials[material] += quantity;
                        if (keyMaterials["motes"] >= 250)
                        {
                            flagDragonwrath = true;
                            keyMaterials["motes"] -= 250;
                            break;
                        }
                    }
                    else
                    {
                        if (!materials.ContainsKey(material))
                        {
                            materials[material] = quantity;
                        }
                        else
                        {
                            materials[material] += quantity;
                        }
                    }
                }
                input = Console.ReadLine();
            }

            if (flagShadowmourne == true)
            {
                Console.WriteLine("Shadowmourne obtained!");
            }
            else if (flagValanyr == true)
            {
                Console.WriteLine("Valanyr obtained!");
            }
            else if(flagDragonwrath == true)
            {
                Console.WriteLine("Dragonwrath obtained!");
            }

            foreach (var keyMaterial in keyMaterials.OrderByDescending(x => x.Value).ThenBy(y => y.Key))
            {
                Console.WriteLine($"{keyMaterial.Key}: {keyMaterial.Value}");
            }
            foreach (var material in materials.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{material.Key}: {material.Value}");
            }
        }
    }
}
