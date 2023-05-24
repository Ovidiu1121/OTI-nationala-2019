using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using testteste.model;
using testteste.repository;

namespace testteste.forms
{
    public partial class FrmMain : Form
    {
        private DataGridView dataGridView1;
        private TabControl tabControl;
        private Label lbltitlu1;
        private Label lbltitlu2;
        private Label lbldata;
        private PictureBox pictureBox1;
        private Button btncauta;
        private TextBox txtnumeprenume;
        private Label lblnumeprenume;
        private UtilizatorRepository controlUtilizatori;
        private DataGridViewButtonColumn btnAfiseaza;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        public Timer timer;
        private DataGridView dataGridView2;
        private TabControl tabControl2;
        private TabPage tb1;
        private TabPage tb2;
        private TabPage tb3;
        private TabPage tb4;
        public Utilizator cititor;
        private DtoCartiImprumutateRepository controlDtoCartiImprumutate;

        public FrmMain()
        {
            InitializeComponent();

            this.Size = new System.Drawing.Size(1109, 661);

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();

            this.pictureBox1=new PictureBox();
            this.Controls.Add(this.pictureBox1);
            this.pictureBox1.Location = new System.Drawing.Point(37, 31);
            this.pictureBox1.Size = new System.Drawing.Size(166, 141);
            this.pictureBox1.Image=Image.FromFile(Application.StartupPath+@"\Imagini\utilizatori\5.jpg");
            this.pictureBox1.SizeMode=PictureBoxSizeMode.StretchImage;

            this.lbltitlu1 = new Label();
            this.Controls.Add(this.lbltitlu1);
            this.lbltitlu1.Location = new System.Drawing.Point(228, 46);
            this.lbltitlu1.Size = new System.Drawing.Size(74, 16);
            this.lbltitlu1.Text = "Bibliotecar:";

            this.lbltitlu2 = new Label();
            this.Controls.Add(this.lbltitlu2);
            this.lbltitlu2.Location = new System.Drawing.Point(308, 46);
            this.lbltitlu2.Size = new System.Drawing.Size(78, 16);
            this.lbltitlu2.Text = "Sava Tudor";

            this.lbldata = new Label();
            this.Controls.Add(this.lbldata);
            this.lbldata.Location = new System.Drawing.Point(866, 46);
            this.lbldata.Size = new System.Drawing.Size(200, 30);
            this.lbldata.Font=new Font("Arial", 14, FontStyle.Regular);

            this.tabControl=new TabControl();
            this.Controls.Add(this.tabControl);
            this.tabControl.Location = new System.Drawing.Point(12, 178);
            this.tabControl.Size = new System.Drawing.Size(1067, 424);

            TabPage tabPage1 = new TabPage("Inregistrare utilizator");
            this.tabPage1=tabPage1;
            TabPage tabPage2 = new TabPage("Afisare cititor");
            this.tabPage2=tabPage2;
            TabPage tabPage3 = new TabPage("Cititor");
            this.tabPage3 =tabPage3;

            this.tabControl.Controls.AddRange(new TabPage[] {tabPage1, tabPage2, tabPage3});

            this.dataGridView1 = new DataGridView();
            tabPage2.Controls.Add(this.dataGridView1);
            this.dataGridView1.Location = new System.Drawing.Point(6, 6);
            this.dataGridView1.Size = new System.Drawing.Size(627, 383);
            populateAfisareCititori();
            this.dataGridView1.CellClick+=new DataGridViewCellEventHandler(afiseaza_CellClick);

            this.btnAfiseaza=new DataGridViewButtonColumn();
            this.dataGridView1.Columns.Add(this.btnAfiseaza);
            this.btnAfiseaza.HeaderText="Afiseaza";
            this.btnAfiseaza.Text="Afiseaza";
            this.btnAfiseaza.Name="Afiseaza";
            this.btnAfiseaza.UseColumnTextForButtonValue=true;

            this.tabControl2=new TabControl();
            tabPage3.Controls.Add(this.tabControl2);
            this.tabControl2.Location = new System.Drawing.Point(3, 13);
            this.tabControl2.Size = new System.Drawing.Size(1053, 379);
            
            TabPage tb1=new TabPage("Carti imprumutate");
            this.tb1=tb1;
            TabPage tb2 = new TabPage("Carti rezervate");
            this.tb1 =tb2;
            TabPage tb3 = new TabPage("Imprumuta carte");
            this.tb3 =tb3;
            TabPage tb4 = new TabPage("Propunere lectura");
            this.tb4 =tb4;

            this.tabControl2.TabPages.AddRange(new TabPage[] { tb1, tb2, tb3, tb4 });

            this.dataGridView2 = new DataGridView();
            tb1.Controls.Add(this.dataGridView2);
            this.dataGridView2.Location = new System.Drawing.Point(3,3);
            this.dataGridView2.Size = new System.Drawing.Size(1053, 392);



        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.lbldata.Text = DateTime.Now.ToString();
        }

        public void populateAfisareCititori()
        {

            DataTable dt = new DataTable();

            dt.Columns.Add("ID cititor", typeof(int));
            dt.Columns.Add("Nume-prenume", typeof(string));
            dt.Columns.Add("Email", typeof(string));

            this.controlUtilizatori=new UtilizatorRepository();

            List<Utilizator> list = this.controlUtilizatori.getLista();
            

            foreach(Utilizator u in list)
            {
                List<int> id = this.controlUtilizatori.getIdByNume(u.Nume_prenume.ToString());
                dt.Rows.Add(id[0], u.Nume_prenume, u.Email);
            }
            this.dataGridView1.DataSource = dt;
        }

        public void afiseaza_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0 || e.ColumnIndex != this.dataGridView1.Columns["Afiseaza"].Index) return;

            string nume = this.dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            List<Utilizator> lista=this.controlUtilizatori.getUtilizatorByNume(nume);
            this.cititor=lista[0];

            this.tabControl.SelectedTab = tabPage3;

        }

        public void populateCititor()
        {

            DataTable dt=new DataTable();

            dt.Columns.Add("ID imprumut", typeof(int));
            dt.Columns.Add("ID carte", typeof(int));
            dt.Columns.Add("Titlu", typeof(string));
            dt.Columns.Add("Autor", typeof(string));
            dt.Columns.Add("Data imprumut", typeof(DateTime));
            dt.Columns.Add("Data expirare imprumut", typeof(DateTime));

            List<int> id = this.controlUtilizatori.getIdByNume(cititor.Nume_prenume.ToString());
            this.controlDtoCartiImprumutate=new DtoCartiImprumutateRepository();

            List<DtoCartiImprumutate>lista=this.controlDtoCartiImprumutate.getList(id[0]);



        }









        private void FrmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
