using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjektTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
            
        }
        private void OnButtonClicked(object sender, EventArgs e)
        {
            Game game = new Game();
            game.start();
        }
    }
}
