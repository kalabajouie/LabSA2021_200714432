using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using Nancy.Json;

namespace LabSA2021_200714432_Practica2_Parte1
{
    public partial class Form1 : Form
    {
        Dictionary<int, string> ListaCarnets = new Dictionary<int, string>();

        public Form1()
        {
            InitializeComponent();
        }


        private void btnToken_Click(object sender, EventArgs e)
        {
            //se crea el string del payload usando el nombre y carnet introducidos
            string payload = "{'nombre':'" + tbNombre.Text + "', 'carnet':'" + tbCarnet.Text + "'}";

            try
            {
                //se genera un string aleatorio codificado en base64 que será el secret generado para el carnet a introducir
                string secreto = secret();

                //en un diccionario se agrega el carnet y se le asocia el secret generado
                ListaCarnets.Add(int.Parse(tbCarnet.Text), secreto);

                IJwtAlgorithm algorithm = new HMACSHA256Algorithm(); // symmetric
                IJsonSerializer serializer = new JsonNetSerializer();
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

                //se genera el token usando el payload, header y secret y se muestra en el textbox
                var token = encoder.Encode(payload, secreto);
                tbToken.Text = token;
                tbSecret.Text = secreto;

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string secret() {
            //genera un string en base 64 de 32 caracteres
            var key = new byte[32];
            RNGCryptoServiceProvider.Create().GetBytes(key);
            var base64Secret = Convert.ToBase64String(key);

            return base64Secret.Substring(0, 32);
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            //este metodo valida el token introducido, extrae el payload del token y obtiene el carnet de el
            //usando este carnet busca el secret asociado y vuelve a generar un nuevo token, compara el token introducido con el token nuevo
            //si coinciden el token es valido, de lo contrario no
            if (tbTokenValidar.Text != "") { 

                int punto1 = tbTokenValidar.Text.IndexOf('.', 0);
                int punto2 = tbTokenValidar.Text.IndexOf('.', punto1+1);
                string payload = tbTokenValidar.Text.Substring(punto1+1, punto2 - punto1-1);
                //MessageBox.Show(payload);
                MessageBox.Show(From64(payload));
                string desenc = From64(payload);

                var serializer = new JavaScriptSerializer();
                var obj = serializer.DeserializeObject(desenc);
            }
        }


        private string From64(string cadena) {
            //convierte un string de base64 a texto legible por humanos
            string convertido;

            int residuo = cadena.Length % 4;
            if (residuo == 0)
            {
                byte[] b = Convert.FromBase64String(cadena);
                convertido = System.Text.Encoding.UTF8.GetString(b);
            }
            else {
                for (int i = 0; i <= 4 - residuo - 1; i++) {
                    cadena = cadena + "=";
                }
                byte[] b = Convert.FromBase64String(cadena);
                convertido = System.Text.Encoding.UTF8.GetString(b);
            }

            return convertido;
        }

    }
}
