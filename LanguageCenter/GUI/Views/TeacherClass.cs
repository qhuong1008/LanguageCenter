using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LanguageCenter.GUI.childForms
{
    public partial class TeacherClass : Form
    {
        public TeacherClass()
        {
            InitializeComponent();
        }

        public string Name { get; set; }

        private void TeacherClass_Load(object sender, EventArgs e)
        {
            teacherClass_Gridview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            teacherClass_Gridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            teacherClass_Gridview.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DisplayteacherClassList(Name);
        }
        public void DisplayteacherClassList(string name)
        {

            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("GetClassBYTeacherName", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@teachername", SqlDbType.NVarChar, 100).Value = name;
            DataTable dt = new DataTable();
            da.Fill(dt);
            teacherClass_Gridview.DataSource = dt;
            teacherClass_Gridview.Columns[0].Width = 30;
            teacherClass_Gridview.Columns[1].Width = 60;
            teacherClass_Gridview.Columns[4].Width = 60;
            teacherClass_Gridview.Columns[5].Width = 60;
            teacherClass_Gridview.Columns[6].Width = 60;
            teacherClass_Gridview.Columns[7].Width = 70;
            teacherClass_Gridview.Columns[8].Width = 70;
            teacherClass_Gridview.Columns[9].Width = 70;
            teacherClass_Gridview.Columns[10].Width = 60;
        }
    }
}
