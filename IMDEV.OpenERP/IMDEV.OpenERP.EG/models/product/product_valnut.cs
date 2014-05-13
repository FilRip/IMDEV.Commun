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
        public double copper
        {
            get { return (double)listProperties.value("copper", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("copper", value); }
        }

        public double iodine
        {
            get { return (double)listProperties.value("iodine", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("iodine", value); }
        }

        public double selenium
        {
            get { return (double)listProperties.value("selenium", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("selenium", value); }
        }

        public string autre_nutriment
        {
            get { return (string)listProperties.value("autre_nutriment", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("autre_nutriment", value); }
        }

        public double vitamin_b12
        {
            get { return (double)listProperties.value("vitamin_b12", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("vitamin_b12", value); }
        }

        public bool a_verifier
        {
            get { return (bool)listProperties.value("a_verifier", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("a_verifier", value); }
        }

        public bool incomplet
        {
            get { return (bool)listProperties.value("incomplet", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("incomplet", value); }
        }

        public double zinc
        {
            get { return (double)listProperties.value("zinc", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("zinc", value); }
        }

        public double vitamin_e
        {
            get { return (double)listProperties.value("vitamin_e", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("vitamin_e", value); }
        }

        public double chromium
        {
            get { return (double)listProperties.value("chromium", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("chromium", value); }
        }

        public double vitamin_b6
        {
            get { return (double)listProperties.value("vitamin_b6", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("vitamin_b6", value); }
        }

        public double niacin
        {
            get { return (double)listProperties.value("niacin", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("niacin", value); }
        }

        public string add_source
        {
            get { return (string)listProperties.value("add_source", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("add_source", value); }
        }

        public double pantothenic_acid
        {
            get { return (double)listProperties.value("pantothenic_acid", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("pantothenic_acid", value); }
        }

        public double sodium
        {
            get { return (double)listProperties.value("sodium", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("sodium", value); }
        }

        public double vitamin_c
        {
            get { return (double)listProperties.value("vitamin_c", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("vitamin_c", value); }
        }

        public double vitamin_a
        {
            get { return (double)listProperties.value("vitamin_a", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("vitamin_a", value); }
        }

        public double qte_an
        {
            get { return (double)listProperties.value("qte_an", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("qte_an", value); }
        }

        public double thiamin
        {
            get { return (double)listProperties.value("thiamin", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("thiamin", value); }
        }

        public double vitamin_d
        {
            get { return (double)listProperties.value("vitamin_d", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("vitamin_d", value); }
        }

        public double proteines
        {
            get { return (double)listProperties.value("proteines", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("proteines", value); }
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

        public double iron
        {
            get { return (double)listProperties.value("iron", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("iron", value); }
        }

        public double folic_acid
        {
            get { return (double)listProperties.value("folic_acid", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("folic_acid", value); }
        }

        public double chloride
        {
            get { return (double)listProperties.value("chloride", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("chloride", value); }
        }

        public System.DateTime? last_update
        {
            get { return (System.DateTime?)listProperties.value("last_update", aField.FIELD_TYPE.DATE); }
            set { listProperties.setValue("last_update", value); }
        }

        public double fibres_alimentaires
        {
            get { return (double)listProperties.value("fibres_alimentaires", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("fibres_alimentaires", value); }
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

        public double starch
        {
            get { return (double)listProperties.value("starch", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("starch", value); }
        }

        public double polyols
        {
            get { return (double)listProperties.value("polyols", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("polyols", value); }
        }

        public double potassium
        {
            get { return (double)listProperties.value("potassium", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("potassium", value); }
        }

        public double cholesterol
        {
            get { return (double)listProperties.value("cholesterol", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("cholesterol", value); }
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

        public string add_comment
        {
            get { return (string)listProperties.value("add_comment", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("add_comment", value); }
        }

        public double biotin
        {
            get { return (double)listProperties.value("biotin", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("biotin", value); }
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

        public double organic_acids
        {
            get { return (double)listProperties.value("organic_acids", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("organic_acids", value); }
        }

        public double phosphorus
        {
            get { return (double)listProperties.value("phosphorus", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("phosphorus", value); }
        }

        public double vitamin_k
        {
            get { return (double)listProperties.value("vitamin_k", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("vitamin_k", value); }
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

        public double molybdenum
        {
            get { return (double)listProperties.value("molybdenum", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("molybdenum", value); }
        }

        public double fluoride
        {
            get { return (double)listProperties.value("fluoride", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("fluoride", value); }
        }

        public int energy_kj
        {
            get { return (int)listProperties.value("energy_kj", aField.FIELD_TYPE.INTEGER); }
        }

        public double manganese
        {
            get { return (double)listProperties.value("manganese", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("manganese", value); }
        }

        public double calcium
        {
            get { return (double)listProperties.value("calcium", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("calcium", value); }
        }

        public double riboflavin
        {
            get { return (double)listProperties.value("riboflavin", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("riboflavin", value); }
        }

        public double magnesium
        {
            get { return (double)listProperties.value("magnesium", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("magnesium", value); }
        }

        public double satures
        {
            get { return (double)listProperties.value("satures", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("satures", value); }
        }

        public string commentaire
        {
            get { return (string)listProperties.value("commentaire", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("commentaire", value); }
        }

        public double omega6
        {
            get { return (double)listProperties.value("omega6", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("omega6", value); }
        }

        public double salt
        {
            get { return (double)listProperties.value("salt", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("salt", value); }
        }

        public double sucres
        {
            get { return (double)listProperties.value("sucres", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("sucres", value); }
        }

        public double omega3
        {
            get { return (double)listProperties.value("omega3", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("omega3", value); }
        }

        public int energy_kcal
        {
            get { return (int)listProperties.value("energy_kcal", aField.FIELD_TYPE.INTEGER); }
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
