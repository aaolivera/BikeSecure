using System;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using WindowsClient.CloudService;
using WindowsClient.Lector;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WindowsClient
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            
            this.InitializeComponent();
        }
        CloudServiceClient _servicio = new CloudServiceClient();
        LectorClient _lector = new LectorClient();
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private async void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                try
                {
                    EscribirLinea("Acerque su tarjeta...", true);
                    //llamo al lector
                    var lectura = await _lector.GetDataAsync();
                    if (true) //si es valida
                    {
                        EscribirLinea(String.Format("Lectura: {0}", lectura), true);
                        var slot = await _servicio.IncommingReadAsync("Lector1", lectura);
                        EscribirLinea(slot == "0"
                                          ? String.Format("Estacionamiento lleno")
                                          : String.Format("Abriendo slot {0}", slot));
                    }
                    await Task.Delay(3000);
                }
                catch
                {
                    
                }
            }
        }

        private void EscribirLinea(string linea, bool limpiar = false)
        {
            if (limpiar) Limpiar();
            Dispatcher.RunAsync(CoreDispatcherPriority.High,() =>
                {
                    LabelPrincipal.Text += linea + "\n";
                });
        }

        private void Limpiar()
        {
            Dispatcher.RunAsync(CoreDispatcherPriority.High, () =>
            {
                LabelPrincipal.Text = "";
            });
        }

    }
}
