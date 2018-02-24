using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using Killer.Xamarin.Forms.Views;
using Killer.Services;

namespace Killer.Xamarin.Forms.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {

		public ObservableCollection<Tuple<int, string>> Suspeitos { get; set; }
		public ObservableCollection<Tuple<int, string>> Armas { get; set; }
		public ObservableCollection<Tuple<int, string>> Locais { get; set; }
		public Command LoadItemsCommand { get; set; }

		public string Resultado { get; set; }

        public ItemsViewModel()
        {
            Title = "Jogo";


			Suspeitos = new ObservableCollection<Tuple<int, string>>();
			Armas = new ObservableCollection<Tuple<int, string>>();
			Locais = new ObservableCollection<Tuple<int, string>>();

			LoadItemsCommand = new Command( () =>  ExecuteLoadItemsCommand());


        }

        void ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
				Suspeitos.Clear();
				Armas.Clear();
				Locais.Clear();


                foreach (var item in (new SuspeitoService()).GetSuspeitos())
                {
					Suspeitos.Add(new Tuple<int, string>(item.Key, item.Value));
                }

				foreach (var item in (new ArmaService()).GetArmas())
				{
					Armas.Add(new Tuple<int, string>(item.Key, item.Value));
				}

				foreach (var item in (new LocalService()).GetLocais())
				{
					Locais.Add(new Tuple<int, string>(item.Key, item.Value));
				}
			}
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}