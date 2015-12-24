using System;
using System.Windows.Forms;

namespace ImageView
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                MessageBox.Show("Image Path missing");
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmImageView(args[0]));
        }
    }
}
