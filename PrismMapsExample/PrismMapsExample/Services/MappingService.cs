using PrismMapsExample.Model;
using PrismMapsExample.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace PrismMapsExample.Services
{
    public class MappingService : IMapping
    {
        int _pinCreatedCount = 0;


        public Location GetNewLocation()
        {
            _pinCreatedCount++;
            return new Location(
                $"Pin {_pinCreatedCount}",
                $"Desc {_pinCreatedCount}",
                RandomPosition.Next(new Position(-33.933329, 18.6333308), 4, 10));
        }
    }
}
