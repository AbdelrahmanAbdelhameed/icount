using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace I_Count
{
    public partial class LogsReport : Form
    {
        AccountingEntities context = new AccountingEntities();


        public LogsReport()
        {
            InitializeComponent();
        }
        /////////////////////////////////////////////////////
        //// وهنا بجيب الاسماء
        private void LoadNames()
        {
            var Names = context.TblUsers.Select(a => a).ToList();

            this.CBUsers.DisplayMember = "UserName";
            this.CBUsers.ValueMember = "UserID";
            this.CBUsers.DataSource = Names;
            this.CBUsers.SelectedItem = null;

        }

        // //////////////////////////////////////////
        private void LogsReport_Load(object sender, EventArgs e)
        {
            var Logs = context.TblLogs.Select(a => a).ToList().OrderByDescending(a=>a.LogID);

            foreach (var item in Logs)
            {
                this.GVShowLogs.Rows.Add(item.TblUser.Name , item.Discription , item.DateOfLog);
            }
            LoadNames();

        }

        private void CBUsers_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.GVShowLogs.Rows.Clear();
            int UID = int.Parse(this.CBUsers.SelectedValue.ToString());
            var Logs = context.TblLogs.Where(a=>a.UserID == UID).Select(a => a).ToList().OrderByDescending(a => a.LogID);

            foreach (var item in Logs)
            {
                this.GVShowLogs.Rows.Add(item.TblUser.Name, item.Discription, item.DateOfLog);
            }

        }
    }
}
