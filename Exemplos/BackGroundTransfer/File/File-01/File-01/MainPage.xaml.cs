using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;

namespace File_01
{
    //
    // Baseado em
    // http://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh758325.aspx
    // http://msdn.microsoft.com/pt-br/library/windows/apps/xaml/hh700361.aspx
    // https://code.msdn.microsoft.com/windowsapps/File-access-sample-d723e597
    // http://tizianocacioppolini.blogspot.com.br/2014/01/windows-phone-8-folders-and-files.html#.VHxOfjHN-So
    //
    public sealed partial class MainPage : Page
    {
        StorageFolder StorageFolder = null;
        const string strArquivo = "Exemplo.txt";

        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }

        async void EscreveArquivo()
        {
            StorageFile StrorageArquivo = await StorageFolder.CreateFileAsync(strArquivo, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(StrorageArquivo, "Teste Teste Teste");            
        }

        private void btnWriteFile_Click(object sender, RoutedEventArgs e)
        {
            StorageFolder = ApplicationData.Current.LocalFolder;
            EscreveArquivo();
            txtMsgLog.Text = "Arquivo Gravado com Sucesso";
        }

        private void btnLimpa_Click(object sender, RoutedEventArgs e)
        {
            txtMsgLog.Text = "Sem Mensagem";
            txtResultado.Text = "Sem Resultado";
        }

        async void LeArquivo()
        {
            try
            {
                StorageFolder StorageDir = Windows.Storage.ApplicationData.Current.LocalFolder;
                StorageFile StorageArquivo = await StorageDir.GetFileAsync(strArquivo);
                string text = await Windows.Storage.FileIO.ReadTextAsync(StorageArquivo);
                txtMsgLog.Text = "Arquivo Lido com Sucesso";
                txtResultado.Text = text;
            }
            catch
            {
                txtMsgLog.Text = "Arquivo Não Existe";
                txtResultado.Text = "Arquivo Não Pode Ser Lido";
            }
        }

        private void btnReadFile_Click(object sender, RoutedEventArgs e)
        {
            LeArquivo();
        }

        async void ApagaArquivo()
        {
            try
            {
                var Arquivo = await ApplicationData.Current.LocalFolder.GetFileAsync(strArquivo);
                await Arquivo.DeleteAsync(StorageDeleteOption.PermanentDelete);

                txtMsgLog.Text = "Arquivo Deletado";
                txtResultado.Text = "Arquivo Deletado com Sucesso";
            }
            catch
            {
                txtMsgLog.Text = "Arquivo Não Pode Ser Deletado";
                txtResultado.Text = "Arquivo Não Existe";
            }
        }

        private void btnDeleteFile_Click(object sender, RoutedEventArgs e)
        {
            ApagaArquivo();
        }

        async void ModificaNomeArquivo ()
        {
            try
            {
                var Arquivo = await ApplicationData.Current.LocalFolder.GetFileAsync(strArquivo);
                await Arquivo.RenameAsync("Modificado.txt");

                txtMsgLog.Text = "Arquivo Renomeado";
                txtResultado.Text = "Arquivo Renomado com Sucesso";
            }
            catch
            {
                txtMsgLog.Text = "Arquivo Não Pode Ser Renomeado";
                txtResultado.Text = "Arquivo Não Existe";
            }
        }

        private void btnRenameFile_Click(object sender, RoutedEventArgs e)
        {
            ModificaNomeArquivo();
        }

        async void DiretorioArquivo()
        {
            String strFiles = null;
            String strAux = null;

            var files = await ApplicationData.Current.LocalFolder.GetFilesAsync();
            foreach (var file in files)
            {
                strAux = null;
                strAux = file.Name + "\n";
                strFiles += strAux;
            }
            txtMsgLog.Text = strFiles;
            txtResultado.Text = "Lista de Arquivos Acessado com Sucesso";
        }

        private void btnDir_Click(object sender, RoutedEventArgs e)
        {
            DiretorioArquivo();
        }
        
        async void CopiaArquivo()
        {
            var Arquivo = await ApplicationData.Current.LocalFolder.GetFileAsync(strArquivo);
            var Diretorio = Windows.Storage.ApplicationData.Current.LocalFolder;
            //var folder = await ApplicationData.Current.LocalFolder.GetFolderAsync("myFolder");
            await Arquivo.CopyAsync(Diretorio, "MeuArquivo.txt");

            txtMsgLog.Text = "Arquivo Copiado com Sucesso"; 
            txtResultado.Text = "Arquivo Copiado com Sucesso"; 
        }

        private void btnCopy_Click(object sender, RoutedEventArgs e)
        {
            CopiaArquivo();
        }
    }
}
