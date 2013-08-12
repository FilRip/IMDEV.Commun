using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMDEV.OpenERP.models.@base;
using IMDEV.OpenERP.models.fields.relations;

namespace IMDEV.OpenERP.EG.models.product
{
    public class product_valnut : anOpenERPObject
    {
        public double qte_an
        {
            get { return (double)listProperties.value("qte_an", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("qte_an", value); }
        }

        public string autre_nutriment
        {
            get { return (string)listProperties.value("autre_nutriment", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("autre_nutriment", value); }
        }

        public bool incomplet
        {
            get { return (bool)listProperties.value("incomplet", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("incomplet", value); }
        }

        public double sucres
        {
            get { return (double)listProperties.value("sucres", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("sucres", value); }
        }

        public double sodium
        {
            get { return (double)listProperties.value("sodium", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("sodium", value); }
        }

        public double proteines
        {
            get { return (double)listProperties.value("proteines", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("proteines", value); }
        }

        public System.DateTime? last_update
        {
            get { return (System.DateTime?)listProperties.value("last_update", aField.FIELD_TYPE.DATE); }
            set { listProperties.setValue("last_update", value); }
        }

        public bool agree_gain
        {
            get { return (bool)listProperties.value("agree_gain", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("agree_gain", value); }
        }

        public string source
        {
            get { return (string)listProperties.value("source", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("source", value); }
        }

        public double mineraux
        {
            get { return (double)listProperties.value("mineraux", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("mineraux", value); }
        }

        public double purete
        {
            get { return (double)listProperties.value("purete", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("purete", value); }
        }

        public double polyinsatures
        {
            get { return (double)listProperties.value("polyinsatures", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("polyinsatures", value); }
        }

        public double glucides
        {
            get { return (double)listProperties.value("glucides", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("glucides", value); }
        }

        public double monoinsatures
        {
            get { return (double)listProperties.value("monoinsatures", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("monoinsatures", value); }
        }

        public double lipides
        {
            get { return (double)listProperties.value("lipides", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("lipides", value); }
        }

        public double eau
        {
            get { return (double)listProperties.value("eau", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("eau", value); }
        }

        public double trans
        {
            get { return (double)listProperties.value("trans", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("trans", value); }
        }

        public string name
        {
            get { return (string)listProperties.value("name", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("name", value); }
        }

        public string commentaire
        {
            get { return (string)listProperties.value("commentaire", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("commentaire", value); }
        }

        public double fibres_alimentaires
        {
            get { return (double)listProperties.value("fibres_alimentaires", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("fibres_alimentaires", value); }
        }

        public double satures
        {
            get { return (double)listProperties.value("satures", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("satures", value); }
        }

        public double omega6
        {
            get { return (double)listProperties.value("omega6", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("omega6", value); }
        }

        public bool a_verifier
        {
            get { return (bool)listProperties.value("a_verifier", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("a_verifier", value); }
        }

        public double omega3
        {
            get { return (double)listProperties.value("omega3", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("omega3", value); }
        }

        public int id
        {
            get { return (int)listProperties.value("id", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("id", value); }
        }
        public override string resource_name()
        {
            return "product.valnut";
        }

        public void setDefaultValues()
        {
            proteines = -1;
            glucides = -1;
            sucres = -1;
            fibres_alimentaires = -1;
            sodium = -1;
            mineraux = -1;
            eau = -1;
            qte_an = -1;
            purete = -1;
            agree_gain = false;
            lipides = -1;
            satures = -1;
            monoinsatures = -1;
            polyinsatures = -1;
            omega3 = -1;
            omega6 = -1;
            trans = -1;
            a_verifier = false;
            incomplet = false;
        }
    }
}
