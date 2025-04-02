﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace files
{
    public class Cars
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Power { get; set; }
        public int Weight { get; set; }
        public double PowerToWeight
        {
            get
            {
                return (double)Power / Weight;
            }
        }
        public Cars(string line)
        {
            string[] temp = line.Split(';');
            Manufacturer = temp[0];
            Model = temp[1];
            Power = int.Parse(temp[2]);
            Weight = int.Parse(temp[3]);
        }
        public Cars(string manufacturer, string model, int power, int weight)
        {
            Manufacturer = manufacturer;
            Model = model;
            Power = power;
            Weight = weight;
        }
    }
}
