﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerCidadao4.Entities
{
    public class Sensor
    {
        public int id { get; set; }
        public double currentHeight { get; set; }
        public double fillRatio { get; set; }
        public string name { get; set; }
        public string street { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public double dimensionX { get; set; }
        public double dimensionY { get; set; }
        public double dimensionZ { get; set; }
        public int gasState { get; set; }
        public int lastManteinance { get; set; }
        public int lastUpdated { get; set; }
        public int volumeState { get; set; }



        private DateTime _FromUnixTime(long unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTime);
        }

        public Manhole CreateManhole()
        {
            Manhole manhole = new Manhole()
            {
                Id = id,
                Name = name,
                Street = street,
                CurrentHeight = currentHeight,
                Latitude = latitude,
                Longitude = longitude,
                Dimensions = new Dimension()
                {
                    X = dimensionX,
                    Y = dimensionY,
                    Z = dimensionZ
                },
                GasState = (EImportanceState)gasState,
                LastUpdated = _FromUnixTime(lastUpdated),
                LastManteinance = _FromUnixTime(lastManteinance)
            };

            return manhole;
        }
    }
}
