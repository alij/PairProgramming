using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SSGeek.Web.Models
{
    public class AlienWeightModel
    {
        [Display(Name = "Number")]
        public int WeightToConvert { get; set; }

        [Display(Name = "Planet")]
        public string TargetPlanet { get; set; }

        public double GetConvertedWeight()
        {
            Dictionary<string, double> conversionRates = new Dictionary<string, double>()
            {
                {"Mercury", 0.37 },
                {"Venus", 0.90 },
                {"Mars", 0.38 },
                {"Jupiter", 2.65 },
                {"Saturn", 1.13 },
                {"Uranus", 1.09 },
                {"Neptune", 1.43 },
                {"Pluto", 0.04 }
            };

            return WeightToConvert * conversionRates[TargetPlanet];
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
                    case "Mercury": path = "mercury.jpg";
                        break;
                    case "Venus": path = "venus.jpg";
                        break;
                    case "Mars": path = "mars.jpg";
                        break;
                    case "Jupiter": path = "jupiter.jpg";
                        break;
                    case "Saturn": path = "saturn.jpg";
                        break;
                    case "Neptune": path = "neptune.jpg";
                        break;
                    case "Uranus": path = "uranus.jpg";
                        break;
                    case "Pluto": path = "pluto.jpg";
                        break;
                }
                return path;
            }
        }


    }
}