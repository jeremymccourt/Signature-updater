using System;
using System.IO;
using System.Windows.Forms;

/* 
 This is a development program to address the need to get a new LogRhythm signature to all the logrhythm users. 
 This was created to make it easier than editing an HTML file directly for non-power users. 
 Jeremy McCourt
 Enterprise Systems Operations Manager / Global IT
 jeremy.mccourt@logrhythm.com
 2017-07-08


     This is a in-progress toolset, and may be developed into more. 
     Currently this just takes a .raw file (which is actually just an HTML file, that has {FIRSTNAME}, {LASTNAME} etc, written into the html file so that it can easily be replaced. 
     In the future it would be good to have a choice of different signatures, and figure out which one is current, as have a configuration file that can be edited on deployment, instead of having
     to recompile. 

     FYI, this is my hello world project for C#. 
     I also need to add try / catch / throw for exception handling. 

     This is intended to be paired with an MSI to add the files in the correct location, - Also a good reason for a config file. 
     the MSI will add a link to the start menu, and after some debate on how to deploy, I have written this to be installed in Program files, so LANDESK can deploy as a user with Admin rights. 
     Also, this can be signed by going to usbo1build05  jenkins / msi_sign 
    
 */

namespace WindowsFormsApplication1
{
    public partial class Sigupdate : Form
    {
        public Sigupdate()
        {
            InitializeComponent();
        }
       

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        public void Form1_Load(object sender, EventArgs e)
        {
            

            

           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox_presig.Text = "";
            textBox_FN.Text = "";
           // textBox_LN.Text = "";
            textBox_JT.Text = "";
            textBox_WP.Text = "";
            textBox_MP.Text = "";
            textBox_postsig.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {



            string fileName = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\LR Utilities\\LR Signature Editor\\logrhythm-company-signature-201706.raw";
            /*if (!File.Exists(fileName))
            {
               //fileName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Microsoft\\Signatures\\logrhythm-company-signature-201706.raw";

            }
            */

            string fileNameOut = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Microsoft\\Signatures\\logrhythm-signature-201706.htm";
            string fileNameOut_PATH = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Microsoft\\Signatures";
            //Read HTML from file
            if (!Directory.Exists(fileNameOut_PATH))
            { 
                Directory.CreateDirectory(fileNameOut_PATH);
            }

            //
            var content = File.ReadAllText(fileName);
            //Replace all values in the HTML
            content = content.Replace("{PRESIG}", textBox_presig.Text);
            content = content.Replace("{FULL_NAME}", textBox_FN.Text);
            //content = content.Replace("{LAST_NAME}", textBox_LN.Text); // Changed first_name, and last_name to full_name
            content = content.Replace("{JOB_TITLE}", textBox_JT.Text);
            if (textBox_WP.Text.Length > 5 )
            { textBox_WP.Text += " (W)"; }
            content = content.Replace("{WORK_PHONE}", textBox_WP.Text);
            if (textBox_MP.Text.Length > 5)
            { textBox_MP.Text += " (M)"; }
            content = content.Replace("{MOBILE_PHONE}", textBox_MP.Text);

            content = content.Replace("{POSTSIG}", textBox_postsig.Text);

            //Write new HTML string to file
            File.WriteAllText(fileNameOut, content);

            //Show it in the default application for handling .html files
            // Process.Start(fileNameOut);
            textBox_status.Text = "COMPLETED, please wait while program closes.";
            textBox_status.Update();
            System.Threading.Thread.Sleep(3000);
            Close();
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
