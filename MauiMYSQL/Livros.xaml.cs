
using MauiMYSQL.Models;

namespace MauiMYSQL;

public partial class Livros : ContentPage
{

    Conecta banco = new Conecta();
    MauiMYSQL.Models.Livros livros = new MauiMYSQL.Models.Livros();


    public Livros()
    {
        InitializeComponent();
        if (banco.Conexao())
        {
            lblStatus.Text = "Banco conectado com sucesso";
            if (livros.Livros_Consulta())
            {
                lstLivros.ItemsSource = livros.listaLivros;
            }
        }
        else
        {
            lblStatus.Text = banco.conexao_status;
        }
    }

    private void btnAdicionar(object sender, EventArgs e)
    {
        if(string.IsNullOrEmpty(txtLivros.Text))
        {
            DisplayAlert("Atenção", "Preencha o título do livro", "OK");
            return;
        }

        livros.Livros_Add(txtLivros.Text, txtAutor.Text, txtAno_lancamento.Text);

        if (livros.Livros_Consulta()) {
            lstLivros.ItemsSource = null;
            lstLivros.ItemsSource = livros.listaLivros;           
        }


    }
}