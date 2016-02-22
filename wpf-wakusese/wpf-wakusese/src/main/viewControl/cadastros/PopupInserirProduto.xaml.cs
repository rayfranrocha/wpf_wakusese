using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using wpf_wakusese.src.main._utils;
using wpf_wakusese.src.main.model.bo;
using wpf_wakusese.src.main.model.ce;

namespace wpf_wakusese.src.main.viewControl.cadastros
{
    /// <summary>
    /// Interaction logic for PopupInserirProduto.xaml
    /// </summary>
    public partial class PopupInserirProduto : MetroWindow
    {
        
        BO_Categoria boCategoria = new BO_Categoria();
        IconUtil util = new IconUtil();

        string arquivoSelecionado = "";
        String caminho;

        public static DependencyProperty categoriasProperty = DependencyProperty.Register("categorias", typeof(ObservableCollection<Categoria>), typeof(PopupInserirProduto));

        public ObservableCollection<Categoria> categorias
        {
            get { return (ObservableCollection<Categoria>)GetValue(categoriasProperty); }
            set { SetValue(categoriasProperty, value); }
        }

        TelaPrincipal frmTelaPrincipal;
        public PopupInserirProduto(TelaPrincipal telaPrincipalInfo)
        {
            InitializeComponent();
            frmTelaPrincipal = telaPrincipalInfo;
            categorias = new ObservableCollection<Categoria>();
            categorias = util.ConverterL2OC(boCategoria.ObterListaCategoriadaEmpresa(frmTelaPrincipal.empLogada));
        
        }

        private void btnProcurar_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = "c:\\";
            dlg.Filter = "Image files (*.jpg)|*.jpg|All Files (*.*)|*.*";
            dlg.RestoreDirectory = true;
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                arquivoSelecionado = dlg.FileName;
                //caminho = arquivoSelecionado;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(arquivoSelecionado);
                bitmap.EndInit();

                ImageViewer1.Source = bitmap;
                caminho = arquivoSelecionado;
            }
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {

            Double valor;

            txtPreco.Text = txtPreco.Text.Replace(".", ",");

            if (String.IsNullOrEmpty(txtNome.Text) || String.IsNullOrEmpty(txtPreco.Text))
            {
                System.Windows.Forms.MessageBox.Show("Preencha todos os campos!");
            }
            else
            {
                try
                {
                    valor = Convert.ToDouble(txtPreco.Text);
                    BO_Produto boProduto = new BO_Produto();

                    // insere dados no banco  *** Gerar um codigoValePresente

                    MemoryStream stream = new MemoryStream();
                    Produto item = new Produto();

                    item.nome = txtNome.Text;

                    if (ImageViewer1.Source != null)
                    {
                        item.img1 = getJPGFromImageControl(ImageViewer1.Source as BitmapImage);
                    }

                    item.preco = Convert.ToDecimal(txtPreco.Text);
                    item.avaliacaoMedia = 5;
                    item.descricao = txtDescricao.Text;

                    foreach (var item1 in categorias)
                    {
                        if (item1.isSelecionado == true)
                        {
                            item.categoria = item1;
                        }
                        else
                        {

                        }
                    }
                    boProduto.InserirOuAlterar(item);
                    boProduto.SaveChanges();

                    System.Windows.Forms.MessageBox.Show("Operação Realizada com Sucesso!");
                    this.Close();

                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Valor inválido!");
                    txtPreco.Focusable = true;

                }
                finally
                {

                }

            }

        }

        public byte[] getJPGFromImageControl(BitmapImage imageC)
        {
            MemoryStream memStream = new MemoryStream();
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(imageC));
            encoder.Save(memStream);
            return memStream.ToArray();
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


    }
}
