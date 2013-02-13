using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace IMDEV.OpenERP.models.@base
{
    public class aField
    {
        public enum FIELD_TYPE
        {
            NC,
            BOOLEAN,
            INTEGER,
            FLOAT,
            CHAR,
            TEXT,
            DATE,
            DATETIME,
            BINARY,
            SELECTION,
            ONE2ONE,
            MANY2ONE,
            ONE2MANY,
            MANY2MANY,
            RELATED,
            FUNCTION,
            REFERENCE
        }

        private string _name = "";

        private FIELD_TYPE _type = FIELD_TYPE.NC;

        private string _help = "";

        private string _desc = "";

        private bool _selectable;

        private ArrayList _digit = new ArrayList();

        private int _size;

        private bool _readOnly;

        private bool _required;

        private List<Object> _domain = new List<Object>();

        private Hashtable _context = new Hashtable();

        private bool _change_default;

        private string _relation = "";

        private bool _store;

        private string _functionStore = "";

        private bool _translate;

        private Hashtable _selection = new Hashtable();

        private int _select;

        private ArrayList _relatedColumns = new ArrayList();

        private string _thirdTable = "";

        private ArrayList _states = new ArrayList();

        private ArrayList _fnct_search = new ArrayList();

        private ArrayList _fnct_inv_arg = new ArrayList();

        private ArrayList _fnct_method = new ArrayList();

        private ArrayList _fnct_inv = new ArrayList();

        private ArrayList _fnct_obj = new ArrayList();

        private string _function = "";

        private bool _invisible;

        public string Function
        {
            get { return _function; }
            set { _function = value; }
        }

        public bool ReadOnly
        {
            get { return _readOnly; }
            set { _readOnly = value; }
        }

        public bool Change_default
        {
            get { return _change_default; }
            set { _change_default = value; }
        }

        public Hashtable Context
        {
            get { return _context; }
            set { _context = value; }
        }

        public string Desc
        {
            get { return _desc; }
            set { _desc = value; }
        }

        public ArrayList Digit
        {
            get { return _digit; }
            set { _digit = value; }
        }

        public List<object> Domain
        {
            get { return _domain; }
        }

        public ArrayList Fnct_inv
        {
            get { return _fnct_inv; }
            set { _fnct_inv = value; }
        }

        public ArrayList Fnct_inv_arg
        {
            get { return _fnct_inv_arg; }
            set { _fnct_inv_arg = value; }
        }

        public ArrayList Fnct_method
        {
            get { return _fnct_method; }
            set { _fnct_method = value; }
        }

        public ArrayList Fnct_obj
        {
            get { return _fnct_obj; }
            set { _fnct_obj = value; }
        }

        public ArrayList Fnct_search
        {
            get { return _fnct_search; }
            set { _fnct_search = value; }
        }

        public string Help
        {
            get { return _help; }
            set { _help = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public ArrayList RelatedColumns
        {
            get { return _relatedColumns; }
            set { _relatedColumns = value; }
        }

        public string Relation
        {
            get { return _relation; }
            set { _relation = value; }
        }

        public bool Required
        {
            get { return _required; }
            set { _required = value; }
        }

        public bool Selectable
        {
            get { return _selectable; }
            set { _selectable = value; }
        }

        public Hashtable Selection
        {
            get { return _selection; }
            set { _selection = value; }
        }

        public int Size
        {
            get { return _size; }
            set { _size = value; }
        }

        public bool Store
        {
            get { return _store; }
            set { _store = value; }
        }

        public string ThirdTable
        {
            get { return _thirdTable; }
            set { _thirdTable = value; }
        }

        public bool Translate
        {
            get { return _translate; }
            set { _translate = value; }
        }

        public FIELD_TYPE Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public void treatment(string name, CookComputing.XmlRpc.XmlRpcStruct donnees)
        {
            IEnumerator boucle;
            IEnumerator boucle2;
            try
            {
                _name = name;
                boucle = donnees.GetEnumerator();
                while (boucle.MoveNext())
                {
                    switch ((string)((DictionaryEntry)(boucle.Current)).Key)
                    {
                        case "help":
                            _help = (string)((DictionaryEntry)(boucle.Current)).Value;
                            break;
                        case "context":
                            boucle2 = ((CookComputing.XmlRpc.XmlRpcStruct)(((DictionaryEntry)(boucle.Current)).Value)).GetEnumerator();
                            while (boucle2.MoveNext())
                            {
                                _context.Add((string)((DictionaryEntry)(boucle.Current)).Key, ((DictionaryEntry)(boucle.Current)).Value);
                            }
                            break;
                        case "relation":
                            _relation = (string)((DictionaryEntry)(boucle.Current)).Value;
                            break;
                        case "type":
                            switch ((string)((DictionaryEntry)(boucle.Current)).Value)
                            {
                                case "integer":
                                    _type = FIELD_TYPE.INTEGER;
                                    break;
                                case "float":
                                    _type = FIELD_TYPE.FLOAT;
                                    break;
                                case "date":
                                    _type = FIELD_TYPE.DATE;
                                    break;
                                case "datetime":
                                    _type = FIELD_TYPE.DATETIME;
                                    break;
                                case "boolean":
                                    _type = FIELD_TYPE.BOOLEAN;
                                    break;
                                case "char":
                                    _type = FIELD_TYPE.CHAR;
                                    break;
                                case "text":
                                    _type = FIELD_TYPE.TEXT;
                                    break;
                                case "selection":
                                    _type = FIELD_TYPE.SELECTION;
                                    break;
                                case "binary":
                                    _type = FIELD_TYPE.BINARY;
                                    break;
                                case "many2one":
                                    _type = FIELD_TYPE.MANY2ONE;
                                    break;
                                case "many2many":
                                    _type = FIELD_TYPE.MANY2MANY;
                                    break;
                                case "one2one":
                                    _type = FIELD_TYPE.ONE2ONE;
                                    break;
                                case "one2many":
                                    _type = FIELD_TYPE.ONE2MANY;
                                    break;
                                case "reference":
                                    _type = FIELD_TYPE.REFERENCE;
                                    break;
                                default:
                                    throw new Exception("Type de champs OpenERP inconnu");
                            }
                            break;
                        case "string":
                            _desc = (string)((DictionaryEntry)(boucle.Current)).Value;
                            break;
                        case "selectable":
                            _selectable = (bool)((DictionaryEntry)(boucle.Current)).Value;
                            break;
                        case "fnct_inv_arg":
                            treatmentArrayOrString(_fnct_inv_arg, ((DictionaryEntry)(boucle.Current)).Value);
                            break;
                        case "fnct_search":
                            treatmentArrayOrString(_fnct_search, ((DictionaryEntry)(boucle.Current)).Value);
                            break;
                        case "func_method":
                            treatmentArrayOrString(_fnct_method, ((DictionaryEntry)(boucle.Current)).Value);
                            break;
                        case "fnct_inv":
                            treatmentArrayOrString(_fnct_inv, ((DictionaryEntry)(boucle.Current)).Value);
                            break;
                        case "func_obj":
                            treatmentArrayOrString(_fnct_obj, ((DictionaryEntry)(boucle.Current)).Value);
                            break;
                        case "function":
                            _function = (string)((DictionaryEntry)(boucle.Current)).Value;
                            break;
                        case "store":
                            if ((((DictionaryEntry)(boucle.Current)).Value.GetType() != typeof(bool)))
                            {
                                _functionStore = (string)((DictionaryEntry)(boucle.Current)).Value;
                            }
                            else
                            {
                                _store = (bool)((DictionaryEntry)(boucle.Current)).Value;
                            }
                            break;
                        case "digits":
                            boucle2 = ((System.Array)(((DictionaryEntry)(boucle.Current)).Value)).GetEnumerator();
                            while (boucle2.MoveNext())
                            {
                                _digit.Add(boucle2.Current);
                            }
                            break;
                        case "size":
                            _size = (int)((DictionaryEntry)(boucle.Current)).Value;
                            break;
                        case "readonly":
                            if (((DictionaryEntry)(boucle.Current)).Value.GetType() == typeof(int))
                            {
                                if ((int)((DictionaryEntry)(boucle.Current)).Value == 0)
                                    _readOnly = false;
                                else
                                    _readOnly = true;
                            }
                            else
                                _readOnly = (bool)((DictionaryEntry)(boucle.Current)).Value;
                            break;
                        case "required":
                            if (((DictionaryEntry)(boucle.Current)).Value.GetType() == typeof(bool))
                                _required = (bool)((DictionaryEntry)(boucle.Current)).Value;
                            else
                                _required = int.Parse((string)((DictionaryEntry)(boucle.Current)).Value) == 1 ? true : false;
                            break;
                        case "selection":
                            boucle2 = ((System.Array)(((DictionaryEntry)(boucle.Current)).Value)).GetEnumerator();
                            while (boucle2.MoveNext())
                            {
                                _selection.Add(((System.Array)(boucle2.Current)).GetValue(0), ((System.Array)(boucle2.Current)).GetValue(1));
                            }
                            break;
                        case "translate":
                            _translate = (bool)((DictionaryEntry)(boucle.Current)).Value;
                            break;
                        case "change_default":
                            _change_default = (bool)((DictionaryEntry)(boucle.Current)).Value;
                            break;
                        case "select":
                            if (((DictionaryEntry)(boucle.Current)).Value.GetType() == typeof(bool))
                                _select = (bool)((DictionaryEntry)(boucle.Current)).Value ? 1 : 0;
                            else
                                _select = (int)((DictionaryEntry)(boucle.Current)).Value;
                            break;
                        case "related_columns":
                            boucle2 = ((System.Array)(((DictionaryEntry)(boucle.Current)).Value)).GetEnumerator();
                            while (boucle2.MoveNext())
                            {
                                _relatedColumns.Add(boucle2.Current);
                            }
                            break;
                        case "third_table":
                            _thirdTable = (string)((DictionaryEntry)(boucle.Current)).Value;
                            break;
                        case "domain":
                            if (((DictionaryEntry)(boucle.Current)).Value.GetType() == typeof(string))
                                _domain.Add((string)((DictionaryEntry)(boucle.Current)).Value);
                            else
                            {
                                boucle2 = ((System.Array)(((DictionaryEntry)(boucle.Current)).Value)).GetEnumerator();
                                while (boucle2.MoveNext())
                                {
                                    _domain.Add(boucle2.Current);
                                }
                            }
                            break;
                        case "states":
                            boucle2 = ((CookComputing.XmlRpc.XmlRpcStruct)(((DictionaryEntry)(boucle.Current)).Value)).GetEnumerator();
                            while (boucle2.MoveNext())
                            {
                                _states.Add(boucle2.Current);
                            }
                            break;
                        case "invisible":
                            _invisible = (bool)((DictionaryEntry)(boucle.Current)).Value;
                            break;
                        default:
                            throw new Exception("Parametre de champs OpenERP inconnu");
                    }
                }
            }
            catch (Exception ex)
            {
                _type = FIELD_TYPE.NC;
                throw new Systeme.exceptionOpenERP(IMDEV.OpenERP.Systeme.exceptionOpenERP.ERRORS.ERR_READ_FIELD, ex.Message);
            }
        }

        private void treatmentArrayOrString(ArrayList local, object donnees)
        {
            IEnumerator boucle2;
            if (donnees.GetType() != typeof(bool))
            {
                if ((donnees.GetType() == typeof(string)))
                {
                    local.Add(donnees);
                }
                else
                {
                    boucle2 = ((System.Array)(donnees)).GetEnumerator();
                    while (boucle2.MoveNext())
                    {
                        local.Add(boucle2.Current);
                    }
                }
            }
        }
    }
}
