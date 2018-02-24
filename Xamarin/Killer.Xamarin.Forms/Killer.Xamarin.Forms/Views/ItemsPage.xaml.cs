using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Killer.Xamarin.Forms.Models;
using Killer.Xamarin.Forms.Views;
using Killer.Xamarin.Forms.ViewModels;
using Killer.Core.DomainModel;
using Killer.Core;

namespace Killer.Xamarin.Forms.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemsPage : ContentPage
	{
        ItemsViewModel viewModel;
		public static Testemunha TestemunhaDoCrime;

		public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();

			TestemunhaDoCrime = RandomCrimeGenerator.TestemunharAssassinato();
		}

        async void OnArmaSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Armas?;
            if (item == null)
                return;

			await Task.FromResult(0);
        }

		async void OnSuspeitoSelected(object sender, SelectedItemChangedEventArgs args)
		{
			var item = args.SelectedItem as Suspeitos?;
			if (item == null)
				return;

			await Task.FromResult(0);
		}


		async void OnLocalSelected(object sender, SelectedItemChangedEventArgs args)
		{
			var item = args.SelectedItem as Locais?;
			if (item == null)
				return;

			await Task.FromResult(0);
		}

		void NovoJogo_Clicked(object sender, EventArgs e)
        {
			TestemunhaDoCrime = RandomCrimeGenerator.TestemunharAssassinato();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.LoadItemsCommand.Execute(null);
        }
    }
}