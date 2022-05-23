using System;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Windows.Forms;
using IWorker;

namespace Client
{
    public partial class Form1 : Form
    {
        IDBWorker db;
        public Form1()
        {
            InitializeComponent();
            ChannelServices.RegisterChannel(new TcpClientChannel());
            db = (IDBWorker)Activator.GetObject(typeof(IDBWorker), "tcp://localhost:8086/GetData");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.GetAllProducts();
        }
    }
}
