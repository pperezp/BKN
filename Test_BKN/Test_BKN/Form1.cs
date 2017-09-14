using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_BKN {
    public partial class Form1 : Form {

        public delegate void delUpdateUILabel(String text);

        private String frase = "BKN respondeme por favor";
        private String respuesta;
        private Boolean inicio;
        private Boolean pregunta;


        public Form1() {
            InitializeComponent();
            inicio = false;
            respuesta = "";
            pregunta = true;
            label1.Text = frase;
        }

        private char getLetra(int indice) {
            return frase[indice];
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == '.') {
                inicio = !inicio;
                procesar(e);
            } else if (inicio) {
                procesar(e);

                respuesta += e.KeyChar;
            }
        }

        private void procesar(KeyPressEventArgs e) {
            comando.Text += getLetra(comando.Text.Length);
            e.Handled = true;// el consume() de java
            comando.SelectionStart = comando.Text.Length;
        }

        private void comando_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                if (pregunta) {// enter en la pregunta
                    pregunta = false;
                    enviarMensaje("Dime hijo mio.", false);
                } else {// enter en la respuesta
                    pregunta = true;
                    enviarMensaje(respuesta, true);
                }
                comando.Text = "";
                comando.Focus();
            }
        }

        private void enviarMensaje(String mensaje, Boolean resp) {
            lbl.Text = "";
            this.Invoke((MethodInvoker)async delegate {
                for (int i = 0; i < 3; i++) {
                    lbl.Text += " . ";
                    await Task.Delay(1000);
                }
                lbl.Text += "\n";
                if (resp) {
                    String buscando = "Buscando en la nasa...";
                    foreach (char letra in buscando) {
                        lbl.Text += letra;
                        await Task.Delay(50);
                    }
                    lbl.Text += "\n";
                    for (int i = 0; i < 3; i++) {
                        lbl.Text += " . ";
                        await Task.Delay(1000);
                    }
                }

                lbl.Text += "\n";
                foreach (char letra in mensaje) {
                    lbl.Text += letra;
                    await Task.Delay(200);
                }
            });
        }

        private void button1_Click(object sender, EventArgs e) {
            new TestHilo().Show();
        }
    }
}
