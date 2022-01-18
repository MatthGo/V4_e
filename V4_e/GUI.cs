using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace V4_e
{
    public partial class GUI : Form
    {

        //Use Gui.gui and its functions, if you want to alter GUI items in another task.
        public static GUI gui = null;

        //if process is cancelled by User set cancelCurrentProcess == true to send cancellation instruction to task 
        private bool _cancelCurrentProcess = false;
        //if process is running set startLock == true to avoid another process is started
        private bool _lockStart = false;
        
        public GUI()
        {
            InitializeComponent();
            gui = this;
            filePathBox.Text = @"C:\Users\MG\iCloudDrive\Documents\00 Privat\Code\test.txt";
        }
        
        private void openFolderButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Filter = "All files (*.*)|*.*|txt files (*.txt)|*.txt";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        filePathBox.Text = openFileDialog.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                reportError(ex.Message);
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (filePathBox.Text == String.Empty)
            {
                MessageBox.Show("There is no file specified!", "V4_e");
                return;
            }

            if (!File.Exists(filePathBox.Text))
            {
                System.Windows.Forms.MessageBox.Show("The File does not exist!", "V4_e");
                return;
            }

            if (_lockStart)
            {
                MessageBox.Show("Work in progress. Please Cancel first.", "V4_e");
                return;
            }

            setProgressBarValue(0);
            setOutput(null);
            _cancelCurrentProcess = false;
            lockStart();
            setprogressDefinition("Parsing...");
            _ = computeOutput();
        }

        private void cancellationButton_Click(object sender, EventArgs e)
        {
            _cancelCurrentProcess = true;
            setProgressBarValue(0);
            unlockStart();
        }

        private void exitButton_Click(object sender, EventArgs e){ Application.Exit(); }

        private async Task computeOutput() {
            setOutput(await Task.Run(() => ComputeOutput.getOutput(path: filePathBox.Text, cancelCurrentProcess: ref _cancelCurrentProcess)));
            unlockStart();
        }

        private void lockStart() { _lockStart = true; }

        private void unlockStart() { _lockStart = false; }

        public void setProgressBarValue(int value)
        {
            if (!this.IsHandleCreated || this.IsDisposed) return;

            this.Invoke((MethodInvoker)delegate {
                progressBar.Value = value;
            });
        }

        public void setProgressBarMax(int value)
        {
            if (!this.IsHandleCreated || this.IsDisposed) return;

            this.Invoke((MethodInvoker)delegate {
                progressBar.Maximum = value;
            });
        }

        public void setprogressDefinition(string value)
        {
            if (!this.IsHandleCreated || this.IsDisposed) return;

            this.Invoke((MethodInvoker)delegate {
                progressDefinition.Text = value;
            });
        }

        public void setOutput(string[] value)
        {
            if (!this.IsHandleCreated || this.IsDisposed) return;

            this.Invoke((MethodInvoker)delegate {
                outputForm.Lines = value;
            });
        }

        public void reportError(string error)
        {
            if (!this.IsHandleCreated || this.IsDisposed) return;

            this.Invoke((MethodInvoker)delegate {
                MessageBox.Show($"Error occurred. Was:\n{error}", "ERROR");
                Console.WriteLine(error);
            });
        }
        
    }
}
