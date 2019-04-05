using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SSGeek.Web.Models
{
    public class AlienAgeModel
    {
        [Display(Name = "Number")]
        public double AgeToConvert { get; set; }

        [Display(Name = "Planet")]
        public string TargetPlanet { get; set; }

        public double GetConvertedAge()
        {
            Dictionary<string, double> conversionRates = new Dictionary<string, double>()
            {
                {"Mercury", 87.96 },
                {"Venus", 224.68 },
                {"Mars", 686.98 },
                {"Jupiter", 11.862 },
                {"Saturn", 29.456 },
                {"Uranus", 84.07 },
                {"Neptune", 164.81 },
                {"Pluto", 247.7 }
            };

            double totalDays = AgeToConvert * 365.26;
            double result;

            switch (TargetPlanet)
            {
                case "Mercury":
                    result = totalDays / conversionRates["Mercury"];
                    break;
                case "Venus":
                    result = totalDays / conversionRates["Venus"];
                    break;
                case "Mars":
                    result = totalDays / conversionRates["Mars"];
                    break;
                case "Jupiter":
                    result = AgeToConvert / conversionRates["Jupiter"];
                    break;
                case "Saturn":
                    result = AgeToConvert / conversionRates["Saturn"];
                    break;
                case "Uranus":
                    result = AgeToConvert / conversionRates["Uranus"];
                    break;
                case "Neptune":
                    result = AgeToConvert / conversionRates["Neptune"];
                    break;
                case "Pluto":
                    result = AgeToConvert / conversionRates["Pluto"];
                    break;
                default:
                    result = 0;
                    break;
            }

            return result;
        }

        public static List<SelectListItem> Planets = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Mercury" },
            new SelectListItem() { Text = "Venus" },
            new SelectListItem() { Text = "Mars" },
            new SelectListItem() { Text = "Jupiter" },
            new SelectListItem() { Text = "Saturn" },
            new SelectListItem() { Text = "Uranus" },
            new SelectListItem() { Text = "Neptune" },
            new SelectListItem() { Text = "Pluto" }
        };

        public string GetPlanetImage
        {
            get
            {
                string path = "";

                switch (TargetPlanet)
                {
                    case "Mercury":
                        path = "mercury.jpg";
                        break;
                    case "Venus":
                        path = "venus.jpg";
                        break;
                    case "Mars":
                        path = "mars.jpg";
                        break;
                    case "Jupiter":
                        path = "jupiter.jpg";
                        break;
                    case "Saturn":
                        path = "saturn.jpg";
                        break;
                    case "Neptune":
                        path = "neptune.jpg";
                        break;
                    case "Uranus":
                        path = "uranus.jpg";
                        break;
                    case "Pluto":
                        path = "pluto.jpg";
                        break;
                }
                return path;
            }
        }
    }
}
