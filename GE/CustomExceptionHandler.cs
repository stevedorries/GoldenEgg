using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ge
{
    internal class CustomExceptionHandler
    {

        //Handle the exception event
        public void OnThreadException(object sender, ThreadExceptionEventArgs t)
        {

            DialogResult result = DialogResult.Cancel;
            try
            {
                result = this.ShowThreadExceptionDialog(t.Exception);
            }
            catch
            {
                try
                {
                    MessageBox.Show("Fatal Error",
                                    "Fatal Error",
                                    MessageBoxButtons.AbortRetryIgnore,
                                    MessageBoxIcon.Stop);
                }
                finally
                {
                    Application.Exit();
                }
            }

            if (result == DialogResult.Abort)
                Application.Exit();

        }

        //The simple dialog that is displayed when this class catches and exception
        private DialogResult ShowThreadExceptionDialog(Exception e)
        {
            string errorMsg = "An error occurred please contact the adminstrator with" +
                              " the following information:\n\n";
            errorMsg += e.Message + "\n\nStack Trace:\n" + e.StackTrace;
            return MessageBox.Show(errorMsg,
                                    "Application Error",
                                    MessageBoxButtons.AbortRetryIgnore,
                                    MessageBoxIcon.Stop);
        }
    }
}
