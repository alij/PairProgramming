using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SSGeek.Web.Models
{
    public class AlienTravelerModel
    {
        [Display(Name = "Planet")]
        public string DestinationPlanet { get; set; }

        [Display(Name = "Transportation")]
        public string ModeOfTransportation { get; set; }

        [Display(Name = "Number")]
        public double AgeOfTraveler { get; set; }

        public double GetTravelTime()
        {
            Dictionary<string, double> Distance = new Dictionary<string, double>()
            {
            //Distance from earth in miles
                {"Mercury", 56974146},
                {"Venus",   25724767},
                {"Mars",    48678219},
                {"Jupiter", 390674710 },
                {"Saturn",  792248270},
                {"Uranus",  1692662530},
                {"Neptune", 2703959960},
                {"Pluto",   4600700000}
            };

            Dictionary<string, double> Mode = new Dictionary<string, double>()
            {
            //mph for each travel mode
                {"Walking", 3.0},
                {"Car", 100.0},
                {"Bullet Train", 200.0},
                {"Boeing 747", 570.0 },
                {"Concorde",  1350.0}

            };

            double result;
            double totalHours;

            switch (DestinationPlanet)
            {
                case "Mercury":
                    totalHours = Distance[DestinationPlanet] / Mode[ModeOfTransportation];
                    result = totalHours / 8760;
                    break;
                case "Venus":
                    totalHours = Distance[DestinationPlanet] / Mode[ModeOfTransportation];
                    result = totalHours / 8760;
                    break;
                case "Mars":
                    totalHours = Distance[DestinationPlanet] / Mode[ModeOfTransportation];
                    result = totalHours / 8760;
                    break;
                case "Jupiter":
                    totalHours = Distance[DestinationPlanet] / Mode[ModeOfTransportation];
                    result = totalHours / 8760;
                    break;
                case "Saturn":
                    totalHours = Distance[DestinationPlanet] / Mode[ModeOfTransportation];
                    result = totalHours / 8760;
                    break;
                case "Uranus":
                    totalHours = Distance[DestinationPlanet] / Mode[ModeOfTransportation];
                    result = totalHours / 8760;
                    break;
                case "Neptune":
                    totalHours = Distance[DestinationPlanet] / Mode[ModeOfTransportation];
                    result = totalHours / 8760;
                    break;
                case "Pluto":
                    totalHours = Distance[DestinationPlanet] / Mode[ModeOfTransportation];
                    result = totalHours / 8760;
                    break;
                default:
                    result = 0;
                    break;
            }

            AgeOfTraveler += result;
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
        public static List<SelectListItem> Mode = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Walking"},
            new SelectListItem() { Text = "Car"},
            new SelectListItem() { Text = "Bullet Train"},
            new SelectListItem() { Text = "Boeing 747"},
            new SelectListItem() { Text = "Concorde"},
        };

        public string GetPlanetImage
        {
            get
            {
                string path = "";

                switch (DestinationPlanet)
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
}   }   }