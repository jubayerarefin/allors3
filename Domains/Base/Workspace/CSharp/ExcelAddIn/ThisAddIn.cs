﻿namespace ExcelAddIn
{
    using System.ComponentModel;
    using System.Windows.Forms;

    public partial class ThisAddIn
    {
        public AddInManager AddInManager { get; private set; }

        private async void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            this.AddInManager = new AddInManager(this.Application, this.CustomTaskPanes, Globals.Factory);
            await this.AddInManager.Init();
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
