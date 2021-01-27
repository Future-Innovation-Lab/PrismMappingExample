using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace PrismMapsExample.Views
{
    public partial class MapsView : ContentPage
    {
        public MapsView()
        {
            InitializeComponent();

            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(-33.933329, 18.6333308), Distance.FromMiles(10)));
        }
    }
}
