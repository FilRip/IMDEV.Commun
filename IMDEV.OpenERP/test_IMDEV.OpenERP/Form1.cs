using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace test_IMDEV.OpenERP
{
    public partial class Form1 : Form
    {
        private IMDEV.OpenERP.Clients.clientOpenERP _monClient;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _monClient = new IMDEV.OpenERP.Clients.clientOpenERP("172.31.0.2", 8069);
            // Connexion directe
            //bool retour;
            //retour=_monClient.connection("xx_test_pt", "admin", "admin");
            //richTextBox1.AppendText(retour.ToString());
            // Connexion asynchrone
            _monClient.connectionAsync("s16", "admin", "admin", comeBackConnection);
        }

        private void comeBackConnection(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            richTextBox1.AppendText(e.Result.ToString()+"\r\n");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IMDEV.OpenERP.EG.models.product.product_product monProduit;
            /*List<object> listeProduit;
            listeProduit = _monClient.search(new IMDEV.OpenERP.models.query.aQuery("name", "test imdev"), "product.product",true);
            richTextBox1.AppendText(((IMDEV.OpenERP.EG.models.product.product_product)(listeProduit[0])).name+"\r\n");
            richTextBox1.AppendText(((IMDEV.OpenERP.EG.models.product.product_product)(listeProduit[1])).name);*/
            monProduit = (IMDEV.OpenERP.EG.models.product.product_product)_monClient.read(new IMDEV.OpenERP.models.query.aQuery(6527), typeof(IMDEV.OpenERP.EG.models.product.product_product))[0];
            monProduit.authorized_country_ids.addLink(1);
            richTextBox1.AppendText(monProduit.save(_monClient).ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            List<IMDEV.OpenERP.models.@base.aField> listeChamps;
            bool idPresent = false;
            _monClient.retourneProprieteConnexion().reportXmlRpcError = true;
            listeChamps = _monClient.getFieldsList(textBox1.Text);
            if (listeChamps != null)
            {
                richTextBox1.AppendText("using IMDEV.OpenERP.models.@base;\r\n");
                richTextBox1.AppendText("using IMDEV.OpenERP.models.fields.relations;\r\n");
                richTextBox1.AppendText("\r\n");
                richTextBox1.AppendText("public class " + textBox1.Text.Replace(".", "_")+":anOpenERPObject\r\n");
                richTextBox1.AppendText("{\r\n");
                foreach (IMDEV.OpenERP.models.@base.aField champs in listeChamps)
                {
                    if (champs.Name.ToLower() == "id") idPresent = true;
                    ecrireUnePropriete(champs);
                    richTextBox1.AppendText("\r\n");
                }
                if (!idPresent)
                {
                    IMDEV.OpenERP.models.@base.aField champsId = new IMDEV.OpenERP.models.@base.aField();
                    champsId.Name = "id";
                    champsId.Type = IMDEV.OpenERP.models.@base.aField.FIELD_TYPE.INTEGER;
                    ecrireUnePropriete(champsId);
                }
                richTextBox1.AppendText("public override string resource_name() {\r\n");
                richTextBox1.AppendText("return " + (char)34 + textBox1.Text + (char)34 + ";");
                richTextBox1.AppendText("}\r\n");
                richTextBox1.AppendText("}\r\n");
            }
        }

        private void ecrireUnePropriete(IMDEV.OpenERP.models.@base.aField champs)
        {
            string typeChampsCS = typeCS(champs.Type);

            if ((champs.Type == IMDEV.OpenERP.models.@base.aField.FIELD_TYPE.MANY2MANY) || (champs.Type == IMDEV.OpenERP.models.@base.aField.FIELD_TYPE.MANY2ONE) || (champs.Type == IMDEV.OpenERP.models.@base.aField.FIELD_TYPE.ONE2MANY) || (champs.Type == IMDEV.OpenERP.models.@base.aField.FIELD_TYPE.ONE2ONE))
            {
                richTextBox1.AppendText("private " + typeChampsCS + " _f_" + champs.Name + " = new " + typeChampsCS + "(); //" + champs.Relation +"\r\n");
                richTextBox1.AppendText("public " + typeChampsCS + " " + champs.Name + " {\r\n");
                richTextBox1.AppendText("get { return _f_" + champs.Name + "; }\r\n");
                richTextBox1.AppendText("}\r\n");
            }
            else if (champs.Type == IMDEV.OpenERP.models.@base.aField.FIELD_TYPE.SELECTION)
            {
                string cle;
                richTextBox1.AppendText("public enum ENUM_" + champs.Name.ToUpper() + " {\r\n");
                richTextBox1.AppendText("NULL\r\n");
                string key;
                foreach (object keypair in champs.Selection.Keys)
                {
                    key = keypair.ToString();
                    if (key == "")
                    {
                        richTextBox1.AppendText(",_EMPTY_\r\n");
                    }
                    else
                    {
                        cle = key.Replace("+", "_PLUS_").Replace("-", "_LESS_").Replace("!", "_EXCLAMATION_").Replace("/", "_").Replace(" ", "_SPACE_").Replace("?", "_INTERROGATION_").Replace("\\", "_");
                        richTextBox1.AppendText(",@"+cle+"\r\n");
                    }
                }
                richTextBox1.AppendText("}\r\n");
                string constructRealCode = "private string[] _frv_" + champs.Name + " = new string[] {" + (char)34 + "NULL" + (char)34 + ",";
                foreach (object keypair in champs.Selection.Keys)
                {
                    key = keypair.ToString();
                    constructRealCode += (char)34 + key + (char)34 + ",";
                }
                constructRealCode = constructRealCode.Substring(0, constructRealCode.Length - 1) + "};\r\n";
                richTextBox1.AppendText(constructRealCode);

                string constructLibelle = "private string[] _fl_" + champs.Name + " = new string[] {" + (char)34 + "NULL" + (char)34 + ",";
                foreach (object keypair in champs.Selection.Keys)
                    constructLibelle += (char)34 + champs.Selection[keypair].ToString() + (char)34 + ",";
                constructLibelle = constructLibelle.Substring(0, constructLibelle.Length - 1) + "};\r\n";
                richTextBox1.AppendText(constructLibelle);
                richTextBox1.AppendText("private ENUM_" + champs.Name.ToUpper() + " _fv_" + champs.Name + ";\r\n");
                richTextBox1.AppendText("public ENUM_" + champs.Name.ToUpper() + " " + champs.Name + " {\r\n");
                richTextBox1.AppendText("get { return _fv_" + champs.Name + "; }\r\n");
                richTextBox1.AppendText("set { _fv_" + champs.Name + " = value; }\r\n");
                richTextBox1.AppendText("}\r\n");
                richTextBox1.AppendText("public string LIBELLE_" + champs.Name + " {\r\n");
                richTextBox1.AppendText("get { return _fl_" + champs.Name + "[(int)_fv_" + champs.Name + "]; }\r\n");
                richTextBox1.AppendText("}\r\n");
                richTextBox1.AppendText("public string CODE_" + champs.Name + " {\r\n");
                richTextBox1.AppendText("get { return _frv_" + champs.Name + "[(int)_fv_" + champs.Name + "]; }\r\n");
                richTextBox1.AppendText("}\r\n");
            }
            else
            {
                richTextBox1.AppendText("public " + typeChampsCS + " " + champs.Name + " {\r\n");
                richTextBox1.AppendText("get { return ("+typeChampsCS+")listProperties.value(" + (char)34 + champs.Name + (char)34 + ",aField.FIELD_TYPE." + champs.Type + "); }\r\n");
                if (!champs.ReadOnly)
                {
                    richTextBox1.AppendText("set { listProperties.setValue(" + (char)34 + champs.Name + (char)34 + ",value); }\r\n");
                }
                richTextBox1.AppendText("}\r\n");
                if (champs.Translate)
                {
                    richTextBox1.AppendText("private IMDEV.OpenERP.models.fields.texteMultilangue _" + champs.Name + "_multilangue;\r\n");
                    richTextBox1.AppendText("public IMDEV.OpenERP.models.fields.texteMultilangue " + champs.Name + "_multilangue { \r\n");
                    richTextBox1.AppendText("get\r\n");
                    richTextBox1.AppendText("{\r\n");
                    richTextBox1.AppendText("if (_"+champs.Name+"_multilangue==null) _"+champs.Name+"_multilangue=new IMDEV.OpenERP.models.fields.texteMultilangue(this," + (char)34+champs.Name + (char)34 + ");\r\n");
                    richTextBox1.AppendText("return _" + champs.Name + "_multilangue;\r\n");
                    richTextBox1.AppendText("} \r\n");
                    richTextBox1.AppendText("}\r\n");
                }
            }
        }

        private string typeCS(IMDEV.OpenERP.models.@base.aField.FIELD_TYPE tf)
        {
            switch (tf)
            {
                case IMDEV.OpenERP.models.@base.aField.FIELD_TYPE.BINARY:
                    return "byte[]";
                case IMDEV.OpenERP.models.@base.aField.FIELD_TYPE.BOOLEAN:
                    return "bool";
                case IMDEV.OpenERP.models.@base.aField.FIELD_TYPE.CHAR:
                case IMDEV.OpenERP.models.@base.aField.FIELD_TYPE.TEXT:
                    return "string";
                case IMDEV.OpenERP.models.@base.aField.FIELD_TYPE.DATE:
                case IMDEV.OpenERP.models.@base.aField.FIELD_TYPE.DATETIME:
                    return "System.DateTime?";
                case IMDEV.OpenERP.models.@base.aField.FIELD_TYPE.FLOAT:
                    return "double";
                case IMDEV.OpenERP.models.@base.aField.FIELD_TYPE.INTEGER:
                    return "int";
                case IMDEV.OpenERP.models.@base.aField.FIELD_TYPE.MANY2MANY:
                    return "manyToMany";
                case IMDEV.OpenERP.models.@base.aField.FIELD_TYPE.MANY2ONE:
                    return "manyToOne";
                case IMDEV.OpenERP.models.@base.aField.FIELD_TYPE.ONE2MANY:
                    return "oneToMany";
                case IMDEV.OpenERP.models.@base.aField.FIELD_TYPE.SELECTION:
                    return "[Enum]";
                default:
                    return "System.Collections.ArrayList";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            IMDEV.OpenERP.models.query.aQuery req;
            req = new IMDEV.OpenERP.models.query.aQuery();
            req.addIlike("name", "test");
            req.addAND();
            req.addIlike("name", "MP");
            req.addOR();
            req.addIlike("name", "IM");
            List<object> retour;
            retour = _monClient.search(req, typeof(IMDEV.OpenERP.EG.models.product.product_product), true);
            if (retour != null)
            {
                foreach (IMDEV.OpenERP.EG.models.product.product_product produit in retour)
                {
                    richTextBox1.AppendText(produit.name + "\r\n");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            IMDEV.OpenERP.models.query.aQuery req;
            req = new IMDEV.OpenERP.models.query.aQuery();
            req.addIlike("name", "test");
            req.addOR();
            req.addIlike("name", "MP");
            req.addAND();
            req.addIlike("name", "IM");
            List<object> retour;
            retour = _monClient.search(req, typeof(IMDEV.OpenERP.EG.models.product.product_product), true);
            if (retour != null)
            {
                foreach (IMDEV.OpenERP.EG.models.product.product_product produit in retour)
                {
                    richTextBox1.AppendText(produit.name + "\r\n");
                }
            }
        }

        private void lblReadCli_Click(object sender, EventArgs e)
        {
            IMDEV.OpenERP.EG.models.res.res_partner cli;
            cli = IMDEV.OpenERP.EG.datatables.listPartner.aPartner(3031, _monClient);
            if (cli == null)
                richTextBox1.AppendText("No client\r\n");
            else
                richTextBox1.AppendText("Client : " + cli.name + "\r\n");
            IMDEV.OpenERP.EG.models.product.product_product p1, p2;
            IMDEV.OpenERP.models.@base.listProperties context = new IMDEV.OpenERP.models.@base.listProperties();
            context.add("company_id", 1);
            p1 = IMDEV.OpenERP.EG.datatables.listProduct.aProduct("G_CRCHAEXTUNL10", _monClient, context);
            context = new IMDEV.OpenERP.models.@base.listProperties();
            context.add("company_id", 2);
            p2 = IMDEV.OpenERP.EG.datatables.listProduct.aProduct("G_CRCHAEXTUNL10", _monClient, context);
            richTextBox1.AppendText("p1 : " + p1.property_account_income.id + "\r\n");
            richTextBox1.AppendText("p2 : " + p2.property_account_income.id + "\r\n");
        }
    }
}
