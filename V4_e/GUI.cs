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
            progressDefinition.Text = String.Empty;
        }
        
        private void OpenFolderButton_Click(object sender, EventArgs e)
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
                ReportError(ex.Message);
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
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

            SetProgressBarValue(0);
            SetOutput(null);
            _cancelCurrentProcess = false;
            LockStart();
            SetprogressDefinition("Parsing...");
            _ = ComputeOutput();
        }

        private void CancellationButton_Click(object sender, EventArgs e)
        {
            _cancelCurrentProcess = true;
            SetProgressBarValue(0);
            UnlockStart();
        }

        private void ExitButton_Click(object sender, EventArgs e){ Application.Exit(); }

        /// <summary>
        /// Task to generate output and hand it over to output form.
        /// </summary>
        private async Task ComputeOutput() {
            SetOutput(await Task.Run(() => V4_e.ComputeOutput.GetOutput(path: filePathBox.Text, cancelCurrentProcess: ref _cancelCurrentProcess)));
            UnlockStart();
        }

        /// <summary>
        /// Locks the Start-Button
        /// </summary>
        /// 
        private void LockStart() { _lockStart = true; }

        /// <summary>
        /// Unlocks the Start-Button
        /// </summary>
        /// 
        private void UnlockStart() { _lockStart = false; }

        /// <summary>
        /// Sets Progress Bar Position
        /// </summary>
        /// 
        public void SetProgressBarValue(int value)
        {
            if (!this.IsHandleCreated || this.IsDisposed) return;

            this.Invoke((MethodInvoker)delegate {
                progressBar.Value = value;
            });
        }

        /// <summary>
        /// Sets the Max of Progress Bar
        /// </summary>
        /// 
        public void SetProgressBarMax(int value)
        {
            if (!this.IsHandleCreated || this.IsDisposed) return;

            this.Invoke((MethodInvoker)delegate {
                progressBar.Maximum = value;
            });
        }

        /// <summary>
        /// Sets the value for label progressDefinition
        /// </summary>
        public void SetprogressDefinition(string value)
        {
            if (!this.IsHandleCreated || this.IsDisposed) return;

            this.Invoke((MethodInvoker)delegate {
                progressDefinition.Text = value;
            });
        }

        /// <summary>
        /// Sets the value for outputForm
        /// </summary>
        public void SetOutput(string[] value)
        {
            if (!this.IsHandleCreated || this.IsDisposed) return;

            this.Invoke((MethodInvoker)delegate {
                outputForm.Lines = value;
            });
        }

        /// <summary>
        /// Reports if a Exception occurs
        /// </summary>
        /// 
        public void ReportError(string error)
        {
            if (!this.IsHandleCreated || this.IsDisposed) return;

            this.Invoke((MethodInvoker)delegate {
                MessageBox.Show($"Error occurred. Was:\n{error}", "ERROR");
                Console.WriteLine(error);
            });
        }
        
    }
}
