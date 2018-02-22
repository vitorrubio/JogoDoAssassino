using Android.App;
using Android.Widget;
using Android.OS;
using Killer.Core;
using Killer.Core.DomainModel;
using System;

namespace Killer.Xamarin
{
    [Activity(Label = "Killer.Xamarin", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        public static Testemunha TestemunhaDoCrime;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            TestemunhaDoCrime = RandomCrimeGenerator.TestemunharAssassinato();

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.myButton);
            button.Text = "Dê um Palpite";

            Button btnNovo = FindViewById<Button>(Resource.Id.btnNovo);
            btnNovo.Text = "Novo Jogo";
            btnNovo.Visibility = Android.Views.ViewStates.Invisible;

            button.Click += delegate
            {
                TextView txtResultado = FindViewById<TextView>(Resource.Id.txtResultado);
                txtResultado.Text = "";


                EditText txtArma = FindViewById<EditText>(Resource.Id.textView1);
                EditText txtLocal = FindViewById<EditText>(Resource.Id.textView2);
                EditText txtSuspeito = FindViewById<EditText>(Resource.Id.textView3);


                if(string.IsNullOrWhiteSpace(txtArma.Text) || string.IsNullOrWhiteSpace(txtLocal.Text) || string.IsNullOrWhiteSpace(txtSuspeito.Text))
                {
                    txtResultado.Text = "Escolha corretamente as opções";
                    return;
                }

                Armas arma = (Armas)Convert.ToInt32(txtArma.Text);
                Locais local = (Locais)Convert.ToInt32(txtLocal.Text);
                Suspeitos suspeito = (Suspeitos)Convert.ToInt32(txtSuspeito.Text);

                Assassinato palpite = new Assassinato(arma, local, suspeito);

                var resposta = TestemunhaDoCrime.RespondeChute(palpite);
                switch (resposta)
                {
                    case 0:
                        txtResultado.Text = "Fim do Jogo, você acertou!!!";
                        btnNovo.Visibility = Android.Views.ViewStates.Visible;
                        break;
                    case 1:
                        txtResultado.Text = "Assassino Incorreto";
                        break;
                    case 2:
                        txtResultado.Text = "Local do Crime Incorreto";
                        break;
                    case 3:
                        txtResultado.Text = "Arma do Crime Incorreta";
                        break;
                    default:
                        txtResultado.Text = "Escolha o suspeito, o local e a arma do crime";
                        break;


                }
            };

            btnNovo.Click += delegate
            {
                btnNovo.Visibility = Android.Views.ViewStates.Invisible;
                TestemunhaDoCrime = RandomCrimeGenerator.TestemunharAssassinato();
            };
        }
    }
}

