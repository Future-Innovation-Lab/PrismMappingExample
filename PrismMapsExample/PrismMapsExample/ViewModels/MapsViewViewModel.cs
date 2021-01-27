using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PrismMapsExample.Model;
using PrismMapsExample.Services.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace PrismMapsExample.ViewModels
{
    public class MapsViewViewModel : ViewModelBase
    {
        private IMapping _mappingService;

        readonly ObservableCollection<Location> _locations;

        public IEnumerable Locations => _locations;


        private DelegateCommand _addLocationCommand;
        public DelegateCommand AddLocationCommand =>
            _addLocationCommand ?? (_addLocationCommand = new DelegateCommand(ExecuteAddLocation));
        private DelegateCommand _removeLocationCommand;

        public DelegateCommand RemoveLocationCommand =>
            _removeLocationCommand ?? (_removeLocationCommand = new DelegateCommand(ExecuteRemoveLocation));

        private DelegateCommand _clearLocationCommand;
        public DelegateCommand ClearLocationsCommand =>
    _clearLocationCommand ?? (_clearLocationCommand = new DelegateCommand(ExecuteClearLocation));


        private DelegateCommand _updateLocationCommand;
        public DelegateCommand UpdateLocationCommand =>
    _updateLocationCommand ?? (_updateLocationCommand = new DelegateCommand(ExecuteUpdateLocations));

        private DelegateCommand _replaceLocationCommand;
        public DelegateCommand ReplaceLocationCommand =>
        _replaceLocationCommand ?? (_replaceLocationCommand = new DelegateCommand(ExecuteReplaceLocation));


        public MapsViewViewModel(INavigationService navigationService, IMapping mapping) : base (navigationService)
        {
            _locations = new ObservableCollection<Location>()
            {
                new Location("UWC", "Future Innovation Lab", new Position(-33.9333296, 18.6333308)),
                new Location("Microsoft", "Office", new Position(-33.971200, 18.464900)),
                new Location("Nandos", "Cause why not?", new Position(-33.933533,  18.407378))
            };

            _mappingService = mapping;

        }

        private void ExecuteAddLocation()
        {
            _locations.Add(_mappingService.GetNewLocation());
        }

        private void ExecuteUpdateLocations()
        {
            if (!_locations.Any())
            {
                return;
            }

            double lastLatitude = _locations.Last().Position.Latitude;
            foreach (Location location in Locations)
            {
                location.Position = new Position(lastLatitude, location.Position.Longitude);
            }

        }

        private void ExecuteReplaceLocation()
        {
            if (!_locations.Any())
            {
                return;
            }

            _locations[_locations.Count - 1] = _mappingService.GetNewLocation();

        }

        private void ExecuteClearLocation()
        {
            _locations.Clear();
        }

        private void ExecuteRemoveLocation()
        {
            if (_locations.Any())
            {
                _locations.Remove(_locations.First());
            }
        }
    }
}
