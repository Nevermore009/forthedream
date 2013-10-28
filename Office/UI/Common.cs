using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace UI
{
    class Common
    {
        public static void BindCombobox(ComboBox cmb, DataTable dt, string textField, string valueField, params string[] firstItem)
        {
            if (firstItem != null && firstItem.Length > 0)
            {
                try
                {
                    DataRow row = dt.NewRow();
                    row[textField] = firstItem[0];
                    dt.Rows.InsertAt(row, 0);
                }
                catch
                { throw; }
            }
            cmb.DataSource = dt;
            cmb.ValueMember = valueField;
            cmb.DisplayMember = textField;
        }
        public static void BindTreeView(DataTable dt, TreeNodeCollection tnc, string pid_val, ParentAndChild[] pandc, int level)
        {
            DataView dv = new DataView(dt);
            TreeNode tn;
            if (!string.IsNullOrEmpty(pandc[level].Pid))
            {
                dv.RowFilter = string.Format(pandc[level].Pid + "='{0}'", pid_val);
            }

            dv = new DataView(dv.ToTable(true, pandc[level].ID, pandc[level].Name));

            foreach (DataRowView drv in dv)
            {
                if (string.IsNullOrEmpty(drv[pandc[level].ID].ToString()))
                    continue;
                tn = new TreeNode();
                tn.Name = drv[pandc[level].ID].ToString();
                tn.Text = drv[pandc[level].Name].ToString();
                tnc.Add(tn);
                if (level + 1 < pandc.Length)
                    BindTreeView(dt, tn.Nodes, tn.Name, pandc, level + 1);
            }
        }

    }
}
