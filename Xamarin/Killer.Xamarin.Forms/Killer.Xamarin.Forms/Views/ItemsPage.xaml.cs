using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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

		Tuple<int, string> _suspeito;
		Tuple<int, string> _arma;
		Tuple<int, string> _local;

		public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();

			TestemunhaDoCrime = RandomCrimeGenerator.TestemunharAssassinato();
		}

        async void OnArmaSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var _arma = args.SelectedItem as Tuple<int, string>;
            if (_arma == null)
                return;


			await Task.FromResult(0);
        }

		async void OnSuspeitoSelected(object sender, SelectedItemChangedEventArgs args)
		{
			var _suspeito = args.SelectedItem as Tuple<int, string>;
			if (_suspeito == null)
				return;

			await Task.FromResult(0);
		}


		async void OnLocalSelected(object sender, SelectedItemChangedEventArgs args)
		{
			var _local = args.SelectedItem as Tuple<int, string>;
			if (_local == null)
				return;

			await Task.FromResult(0);
		}

		void NovoJogo_Clicked(object sender, EventArgs e)
        {
			TestemunhaDoCrime = RandomCrimeGenerator.TestemunharAssassinato();
		}

		void Palpitar_Clicked(object sender, EventArgs e)
		{
			if (_suspeito == null || _local  == null|| _arma == null)
			{
				viewModel.Resultado = "Escolha corretamente as opções";
				return;
			}

			Armas arma = (Armas)_arma.Item1;
			Locais local = (Locais)_local.Item1;
			Suspeitos suspeito = (Suspeitos)_suspeito.Item1;

			Assassinato palpite = new Assassinato(arma, local, suspeito);

			var resposta = TestemunhaDoCrime.RespondeChute(palpite);
			switch (resposta)
			{
				case 0:
					viewModel.Resultado = "Fim do Jogo, você acertou!!!";
					break;
				case 1:
					viewModel.Resultado = "Assassino Incorreto";
					break;
				case 2:
					viewModel.Resultado = "Local do Crime Incorreto";
					break;
				case 3:
					viewModel.Resultado = "Arma do Crime Incorreta";
					break;
				default:
					viewModel.Resultado = "Escolha o suspeito, o local e a arma do crime";
					break;
			}
		}

		protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.LoadItemsCommand.Execute(null);
        }
    }
}