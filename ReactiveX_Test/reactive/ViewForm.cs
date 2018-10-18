using ReactiveX_Test.tecnospeed;
using System;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading;
using System.Windows.Forms;

namespace ReactiveX_Test.reactive
{
    public partial class ViewForm : Form
    {
        NFCe400 nfce400;

        string text_box_2_text;

        public ViewForm()
        {
            this.nfce400 = new NFCe400();

            InitializeComponent();
        }

        delegate void StringArgReturningVoidDelegate(string text);

        private void updateTextBox2Text(string text)
        {
            if(this.textBox2.InvokeRequired)
            {
                StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(updateTextBox2Text);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.textBox2.Text = text;
            }
        }

        private void setTextBox2Text()
        {
            this.updateTextBox2Text(text_box_2_text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string chave_consulta = this.textBox1.Text;

            this.nfce400.consultarNFCe(chave_consulta)
                .SubscribeOn(Scheduler.Default)
                .Subscribe(
                    (string it) => {
                        text_box_2_text = it;
                        var new_thread = new Thread(new ThreadStart(this.setTextBox2Text));
                        new_thread.Start();
                    },
                    (Exception ex) => {
                        text_box_2_text = ex.Message;
                        var new_thread = new Thread(new ThreadStart(this.setTextBox2Text));
                        new_thread.Start();
                    }
                );
        }
    }
}
