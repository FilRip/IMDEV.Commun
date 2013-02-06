using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMDEV.OpenERP.models.@base;
using IMDEV.OpenERP.models.fields.relations;

namespace IMDEV.OpenERP.EG.models.res
{
    public class res_users : anOpenERPObject
    {
        private manyToMany _f_groups_id = new manyToMany(); //res.groups
        public manyToMany groups_id
        {
            get { return _f_groups_id; }
        }

        private manyToOne _f_address_id = new manyToOne(); //res.partner.address
        public manyToOne address_id
        {
            get { return _f_address_id; }
        }

        public double com_rate
        {
            get { return (double)listProperties.value("com_rate", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("com_rate", value); }
        }

        public System.DateTime? date
        {
            get { return (System.DateTime?)listProperties.value("date", aField.FIELD_TYPE.DATETIME); }
        }

        public enum ENUM_AVAILABILITY
        {
            NULL
            ,
            @free
                , @busy
        }
        private string[] _frv_availability = new string[] { "NULL", "free", "busy" };
        private string[] _fl_availability = new string[] { "NULL", "Free", "Busy" };
        private ENUM_AVAILABILITY _fv_availability;
        public ENUM_AVAILABILITY availability
        {
            get { return _fv_availability; }
            set { _fv_availability = value; }
        }
        public string LIBELLE_availability
        {
            get { return _fl_availability[(int)_fv_availability]; }
        }

        public string new_password
        {
            get { return (string)listProperties.value("new_password", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("new_password", value); }
        }

        private manyToOne _f_company_id = new manyToOne(); //res.company
        public manyToOne company_id
        {
            get { return _f_company_id; }
        }

        private manyToOne _f_context_normal_printer_id = new manyToOne(); //printers.list
        public manyToOne context_normal_printer_id
        {
            get { return _f_context_normal_printer_id; }
        }

        public string email
        {
            get { return (string)listProperties.value("email", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("email", value); }
        }

        private manyToOne _f_action_id = new manyToOne(); //ir.actions.actions
        public manyToOne action_id
        {
            get { return _f_action_id; }
        }

        public enum ENUM_CONTEXT_TZ
        {
            NULL
            ,
            @Navajo
                ,
            @America_Santo_Domingo
                ,
            @Portugal
                ,
            @Asia_Shanghai
                ,
            @America_Anguilla
                ,
            @Africa_Malabo
                ,
            @Asia_Bishkek
                ,
            @Africa_Luanda
                ,
            @Africa_Nairobi
                ,
            @HST
                ,
            @Etc_GMT_LESS_14
                ,
            @Canada_Pacific
                ,
            @America_Indiana_Winamac
                ,
            @MST
                ,
            @Etc_GMT_PLUS_11
                ,
            @Asia_Tokyo
                ,
            @Atlantic_Jan_Mayen
                ,
            @America_Port_LESS_au_LESS_Prince
                ,
            @Egypt
                ,
            @Etc_GMT_LESS_0
                ,
            @EST
                ,
            @Asia_Anadyr
                ,
            @Etc_GMT_LESS_7
                ,
            @Europe_Dublin
                ,
            @Etc_GMT_LESS_4
                ,
            @America_Dawson
                ,
            @Asia_Tel_Aviv
                ,
            @Asia_Irkutsk
                ,
            @W_LESS_SU
                ,
            @Africa_Tripoli
                ,
            @America_Winnipeg
                ,
            @GB
                ,
            @Brazil_DeNoronha
                ,
            @Africa_Bamako
                ,
            @America_Argentina_Rio_Gallegos
                ,
            @America_La_Paz
                ,
            @Europe_Paris
                ,
            @America_North_Dakota_Center
                ,
            @America_Kentucky_Louisville
                ,
            @Europe_Kiev
                ,
            @Pacific_Kiritimati
                ,
            @America_Danmarkshavn
                ,
            @Australia_ACT
                ,
            @Europe_Guernsey
                ,
            @Pacific_Efate
                ,
            @Europe_Budapest
                ,
            @America_Curacao
                ,
            @Mexico_General
                ,
            @Pacific_Niue
                ,
            @America_Montserrat
                ,
            @Asia_Gaza
                ,
            @Pacific_Norfolk
                ,
            @America_Jujuy
                ,
            @Africa_Windhoek
                ,
            @America_Argentina_Buenos_Aires
                ,
            @Asia_Aqtobe
                ,
            @America_Rainy_River
                ,
            @Etc_Greenwich
                ,
            @America_Managua
                ,
            @Canada_East_LESS_Saskatchewan
                ,
            @America_Boa_Vista
                ,
            @Asia_Dili
                ,
            @Pacific_Noumea
                ,
            @Pacific_Galapagos
                ,
            @Asia_Colombo
                ,
            @Pacific_Kwajalein
                ,
            @GMT
                ,
            @Atlantic_Madeira
                ,
            @UTC
                ,
            @Pacific_Kosrae
                ,
            @Africa_Douala
                ,
            @Atlantic_St_Helena
                ,
            @Asia_Urumqi
                ,
            @Mexico_BajaNorte
                ,
            @America_St_Barthelemy
                ,
            @Africa_Lubumbashi
                ,
            @Asia_Bahrain
                ,
            @Atlantic_Stanley
                ,
            @America_Argentina_San_Luis
                ,
            @US_Samoa
                ,
            @America_St_Kitts
                ,
            @America_Chihuahua
                ,
            @Asia_Oral
                ,
            @America_Matamoros
                ,
            @America_Coral_Harbour
                ,
            @Etc_GMT
                ,
            @Etc_GMT_PLUS_6
                ,
            @Etc_GMT_PLUS_7
                ,
            @Australia_Victoria
                ,
            @Etc_GMT_PLUS_4
                ,
            @Etc_GMT_PLUS_5
                ,
            @Australia_NSW
                ,
            @Etc_GMT_PLUS_8
                ,
            @Pacific_Wake
                ,
            @Asia_Baku
                ,
            @Africa_Algiers
                ,
            @Asia_Dubai
                ,
            @Asia_Katmandu
                ,
            @America_Goose_Bay
                ,
            @GMT0
                ,
            @Africa_Abidjan
                ,
            @Africa_Bujumbura
                ,
            @America_Atikokan
                ,
            @Asia_Yekaterinburg
                ,
            @America_Panama
                ,
            @Europe_Warsaw
                ,
            @America_Nome
                ,
            @Mexico_BajaSur
                ,
            @Etc_GMT_LESS_11
                ,
            @America_Guatemala
                ,
            @America_Rio_Branco
                ,
            @Europe_San_Marino
                ,
            @Europe_Bucharest
                ,
            @Asia_Calcutta
                ,
            @NZ_LESS_CHAT
                ,
            @America_St_Johns
                ,
            @Asia_Pontianak
                ,
            @Jamaica
                ,
            @Africa_Ouagadougou
                ,
            @Asia_Thimbu
                ,
            @Atlantic_Canary
                ,
            @Europe_Madrid
                ,
            @America_Costa_Rica
                ,
            @Indian_Comoro
                ,
            @Europe_Malta
                ,
            @Turkey
                ,
            @UCT
                ,
            @Africa_Porto_LESS_Novo
                ,
            @Asia_Ashkhabad
                ,
            @Etc_Zulu
                ,
            @Asia_Jerusalem
                ,
            @America_Mazatlan
                ,
            @Asia_Macau
                ,
            @Europe_Luxembourg
                ,
            @Pacific_Fiji
                ,
            @America_Ojinaga
                ,
            @America_Chicago
                ,
            @US_Alaska
                ,
            @Asia_Harbin
                ,
            @Asia_Ashgabat
                ,
            @Asia_Aden
                ,
            @Europe_Samara
                ,
            @Africa_Kigali
                ,
            @Asia_Vladivostok
                ,
            @Asia_Dacca
                ,
            @America_Cayenne
                ,
            @Asia_Choibalsan
                ,
            @Asia_Aqtau
                ,
            @America_Tortola
                ,
            @America_Argentina_La_Rioja
                ,
            @Asia_Kuching
                ,
            @Chile_Continental
                ,
            @Pacific_Marquesas
                ,
            @Europe_Berlin
                ,
            @Asia_Chongqing
                ,
            @Iran
                ,
            @Indian_Christmas
                ,
            @Hongkong
                ,
            @US_Pacific_LESS_New
                ,
            @Europe_Rome
                ,
            @PRC
                ,
            @Asia_Manila
                ,
            @Asia_Thimphu
                ,
            @America_Buenos_Aires
                ,
            @Africa_Nouakchott
                ,
            @America_Glace_Bay
                ,
            @America_Shiprock
                ,
            @Canada_Atlantic
                ,
            @Europe_Bratislava
                ,
            @Europe_Riga
                ,
            @Australia_Currie
                ,
            @America_Menominee
                ,
            @America_Bahia
                ,
            @Australia_Sydney
                ,
            @Asia_Omsk
                ,
            @Australia_Lord_Howe
                ,
            @Asia_Ulan_Bator
                ,
            @GB_LESS_Eire
                ,
            @US_Central
                ,
            @America_Santa_Isabel
                ,
            @Africa_Johannesburg
                ,
            @Canada_Eastern
                ,
            @America_Eirunepe
                ,
            @Europe_Oslo
                ,
            @Zulu
                ,
            @America_Port_of_Spain
                ,
            @Asia_Jayapura
                ,
            @Asia_Kuala_Lumpur
                ,
            @America_Inuvik
                ,
            @Etc_GMT_LESS_6
                ,
            @Pacific_Enderbury
                ,
            @Asia_Kuwait
                ,
            @America_Moncton
                ,
            @Europe_Vatican
                ,
            @WET
                ,
            @America_Whitehorse
                ,
            @Africa_Ndjamena
                ,
            @Indian_Reunion
                ,
            @Asia_Vientiane
                ,
            @Asia_Dhaka
                ,
            @CET
                ,
            @Africa_Tunis
                ,
            @America_Phoenix
                ,
            @Europe_Belfast
                ,
            @America_Guyana
                ,
            @America_Regina
                ,
            @Africa_Monrovia
                ,
            @Indian_Maldives
                ,
            @Etc_GMT_LESS_10
                ,
            @America_Knox_IN
                ,
            @Europe_Chisinau
                ,
            @America_Indiana_Tell_City
                ,
            @America_Grand_Turk
                ,
            @Antarctica_DumontDUrville
                ,
            @America_Aruba
                ,
            @Europe_Sofia
                ,
            @America_Guadeloupe
                ,
            @America_Havana
                ,
            @Asia_Makassar
                ,
            @Etc_GMT_LESS_3
                ,
            @Asia_Kamchatka
                ,
            @Etc_GMT_LESS_1
                ,
            @America_Belem
                ,
            @America_Los_Angeles
                ,
            @Africa_Lusaka
                ,
            @Etc_GMT_LESS_5
                ,
            @Africa_Lome
                ,
            @Etc_GMT_LESS_8
                ,
            @Etc_GMT_LESS_9
                ,
            @Asia_Samarkand
                ,
            @Australia_Tasmania
                ,
            @Africa_Asmera
                ,
            @Africa_Ceuta
                ,
            @Europe_Vienna
                ,
            @Africa_Kinshasa
                ,
            @Africa_El_Aaiun
                ,
            @PST8PDT
                ,
            @America_Antigua
                ,
            @America_Indiana_Petersburg
                ,
            @Asia_Pyongyang
                ,
            @US_Eastern
                ,
            @America_Porto_Acre
                ,
            @America_Puerto_Rico
                ,
            @CST6CDT
                ,
            @Pacific_Funafuti
                ,
            @Etc_GMT0
                ,
            @America_North_Dakota_New_Salem
                ,
            @Asia_Macao
                ,
            @Europe_Tallinn
                ,
            @America_Yakutat
                ,
            @Asia_Baghdad
                ,
            @Africa_Brazzaville
                ,
            @Africa_Khartoum
                ,
            @Iceland
                ,
            @America_St_Vincent
                ,
            @America_Cancun
                ,
            @Europe_Ljubljana
                ,
            @Pacific_Chatham
                ,
            @Europe_Simferopol
                ,
            @Australia_Broken_Hill
                ,
            @Europe_Minsk
                ,
            @Asia_Qyzylorda
                ,
            @Atlantic_Faeroe
                ,
            @Australia_Yancowinna
                ,
            @America_Rankin_Inlet
                ,
            @Asia_Rangoon
                ,
            @Africa_Asmara
                ,
            @Africa_Kampala
                ,
            @Europe_Istanbul
                ,
            @Europe_Uzhgorod
                ,
            @Africa_Accra
                ,
            @America_Yellowknife
                ,
            @America_Adak
                ,
            @Africa_Lagos
                ,
            @America_Argentina_Mendoza
                ,
            @America_Montevideo
                ,
            @Africa_Mogadishu
                ,
            @America_Sao_Paulo
                ,
            @America_El_Salvador
                ,
            @America_Belize
                ,
            @Canada_Central
                ,
            @America_Thunder_Bay
                ,
            @Europe_Prague
                ,
            @America_Ensenada
                ,
            @America_Argentina_Cordoba
                ,
            @Asia_Ho_Chi_Minh
                ,
            @Pacific_Johnston
                ,
            @Africa_Maputo
                ,
            @Europe_Kaliningrad
                ,
            @Africa_Djibouti
                ,
            @Brazil_Acre
                ,
            @Asia_Krasnoyarsk
                ,
            @Greenwich
                ,
            @America_Campo_Grande
                ,
            @Asia_Riyadh
                ,
            @Asia_Magadan
                ,
            @Australia_South
                ,
            @America_Virgin
                ,
            @Pacific_Guadalcanal
                ,
            @Antarctica_Palmer
                ,
            @MET
                ,
            @Europe_Skopje
                ,
            @America_Jamaica
                ,
            @EET
                ,
            @America_Cuiaba
                ,
            @EST5EDT
                ,
            @Singapore
                ,
            @America_Noronha
                ,
            @Cuba
                ,
            @Pacific_Palau
                ,
            @America_Detroit
                ,
            @Antarctica_Casey
                ,
            @America_Argentina_Jujuy
                ,
            @Antarctica_Rothera
                ,
            @Europe_Vaduz
                ,
            @America_Nassau
                ,
            @America_Santiago
                ,
            @Asia_Phnom_Penh
                ,
            @Europe_Zaporozhye
                ,
            @Asia_Muscat
                ,
            @Asia_Almaty
                ,
            @Europe_Mariehamn
                ,
            @America_Argentina_ComodRivadavia
                ,
            @America_Toronto
                ,
            @America_Juneau
                ,
            @Asia_Kabul
                ,
            @US_Arizona
                ,
            @NZ
                ,
            @America_Indiana_Vincennes
                ,
            @Africa_Gaborone
                ,
            @Africa_Cairo
                ,
            @US_Indiana_LESS_Starke
                ,
            @Asia_Taipei
                ,
            @Pacific_Rarotonga
                ,
            @America_Indiana_Knox
                ,
            @Europe_Sarajevo
                ,
            @Atlantic_Faroe
                ,
            @Asia_Kashgar
                ,
            @ROK
                ,
            @Australia_Canberra
                ,
            @Australia_Perth
                ,
            @America_Dawson_Creek
                ,
            @Brazil_West
                ,
            @Europe_Belgrade
                ,
            @Africa_Niamey
                ,
            @Europe_Amsterdam
                ,
            @Europe_Tirane
                ,
            @Europe_Zurich
                ,
            @Asia_Yakutsk
                ,
            @Africa_Dakar
                ,
            @Indian_Mayotte
                ,
            @America_Guayaquil
                ,
            @Etc_GMT_PLUS_10
                ,
            @Asia_Novosibirsk
                ,
            @MST7MDT
                ,
            @Australia_Brisbane
                ,
            @Pacific_Guam
                ,
            @Africa_Libreville
                ,
            @Indian_Kerguelen
                ,
            @Pacific_Pitcairn
                ,
            @America_Anchorage
                ,
            @Africa_Freetown
                ,
            @Etc_GMT_PLUS_2
                ,
            @Etc_GMT_PLUS_3
                ,
            @Etc_GMT_PLUS_0
                ,
            @Etc_GMT_PLUS_1
                ,
            @America_Resolute
                ,
            @America_Barbados
                ,
            @America_Recife
                ,
            @Asia_Saigon
                ,
            @America_Boise
                ,
            @Etc_GMT_PLUS_9
                ,
            @Asia_Qatar
                ,
            @America_Argentina_Catamarca
                ,
            @America_Mexico_City
                ,
            @Canada_Newfoundland
                ,
            @America_Scoresbysund
                ,
            @Europe_Brussels
                ,
            @Europe_Vilnius
                ,
            @America_Paramaribo
                ,
            @Asia_Bangkok
                ,
            @Indian_Antananarivo
                ,
            @Chile_EasterIsland
                ,
            @Africa_Casablanca
                ,
            @Australia_Adelaide
                ,
            @Canada_Yukon
                ,
            @America_Indianapolis
                ,
            @Antarctica_Syowa
                ,
            @Africa_Addis_Ababa
                ,
            @Pacific_Samoa
                ,
            @America_Cordoba
                ,
            @US_Pacific
                ,
            @Asia_Jakarta
                ,
            @America_Tegucigalpa
                ,
            @Etc_GMT_LESS_2
                ,
            @America_Argentina_Ushuaia
                ,
            @America_Indiana_Vevay
                ,
            @Asia_Tashkent
                ,
            @Eire
                ,
            @Poland
                ,
            @Australia_Queensland
                ,
            @ROC
                ,
            @America_Monterrey
                ,
            @Pacific_Nauru
                ,
            @GMT_LESS_0
                ,
            @Atlantic_Azores
                ,
            @Europe_Copenhagen
                ,
            @Pacific_Pago_Pago
                ,
            @Asia_Chungking
                ,
            @Africa_Blantyre
                ,
            @America_Denver
                ,
            @Pacific_Auckland
                ,
            @America_Bogota
                ,
            @America_Pangnirtung
                ,
            @Asia_Novokuznetsk
                ,
            @Europe_Moscow
                ,
            @Asia_Kolkata
                ,
            @Europe_London
                ,
            @Universal
                ,
            @Pacific_Tarawa
                ,
            @Africa_Bangui
                ,
            @Indian_Mahe
                ,
            @America_Indiana_Marengo
                ,
            @America_Nipigon
                ,
            @America_Fort_Wayne
                ,
            @US_East_LESS_Indiana
                ,
            @America_Dominica
                ,
            @Pacific_Yap
                ,
            @Canada_Saskatchewan
                ,
            @America_Asuncion
                ,
            @Pacific_Honolulu
                ,
            @Europe_Isle_of_Man
                ,
            @Australia_Melbourne
                ,
            @Africa_Mbabane
                ,
            @America_Atka
                ,
            @Indian_Cocos
                ,
            @Europe_Stockholm
                ,
            @America_Cayman
                ,
            @America_Lima
                ,
            @America_Halifax
                ,
            @Asia_Yerevan
                ,
            @Antarctica_Mawson
                ,
            @Europe_Lisbon
                ,
            @Antarctica_Davis
                ,
            @Arctic_Longyearbyen
                ,
            @Etc_GMT_PLUS_12
                ,
            @America_Edmonton
                ,
            @Europe_Tiraspol
                ,
            @Africa_Harare
                ,
            @America_Blanc_LESS_Sablon
                ,
            @America_St_Thomas
                ,
            @Pacific_Fakaofo
                ,
            @Australia_Lindeman
                ,
            @Japan
                ,
            @America_Godthab
                ,
            @Pacific_Gambier
                ,
            @Asia_Karachi
                ,
            @Etc_GMT_LESS_12
                ,
            @Africa_Sao_Tome
                ,
            @Asia_Dushanbe
                ,
            @Europe_Andorra
                ,
            @US_Hawaii
                ,
            @Asia_Hong_Kong
                ,
            @Indian_Mauritius
                ,
            @America_Argentina_San_Juan
                ,
            @US_Mountain
                ,
            @Pacific_Easter
                ,
            @Kwajalein
                ,
            @Africa_Banjul
                ,
            @Asia_Tehran
                ,
            @Australia_West
                ,
            @America_St_Lucia
                ,
            @Pacific_Truk
                ,
            @Asia_Seoul
                ,
            @Australia_LHI
                ,
            @Europe_Volgograd
                ,
            @America_Iqaluit
                ,
            @Atlantic_Reykjavik
                ,
            @Antarctica_McMurdo
                ,
            @Pacific_Tongatapu
                ,
            @America_Manaus
                ,
            @US_Aleutian
                ,
            @Pacific_Saipan
                ,
            @America_Martinique
                ,
            @Atlantic_Cape_Verde
                ,
            @America_Cambridge_Bay
                ,
            @Australia_Darwin
                ,
            @America_Merida
                ,
            @America_Rosario
                ,
            @Asia_Nicosia
                ,
            @Asia_Kathmandu
                ,
            @America_Louisville
                ,
            @America_Caracas
                ,
            @Africa_Timbuktu
                ,
            @Pacific_Midway
                ,
            @Pacific_Majuro
                ,
            @America_Araguaina
                ,
            @Etc_UCT
                ,
            @America_Kentucky_Monticello
                ,
            @Atlantic_Bermuda
                ,
            @Asia_Tbilisi
                ,
            @Asia_Beirut
                ,
            @Asia_Ulaanbaatar
                ,
            @Africa_Dar_es_Salaam
                ,
            @America_Tijuana
                ,
            @US_Michigan
                ,
            @America_Maceio
                ,
            @Europe_Zagreb
                ,
            @Pacific_Wallis
                ,
            @Pacific_Tahiti
                ,
            @Indian_Chagos
                ,
            @Asia_Ujung_Pandang
                ,
            @America_Marigot
                ,
            @Asia_Hovd
                ,
            @Africa_Maseru
                ,
            @Australia_North
                ,
            @America_Argentina_Tucuman
                ,
            @Brazil_East
                ,
            @Africa_Conakry
                ,
            @Asia_Singapore
                ,
            @Pacific_Port_Moresby
                ,
            @Europe_Monaco
                ,
            @Antarctica_Vostok
                ,
            @America_Hermosillo
                ,
            @Asia_Sakhalin
                ,
            @Asia_Brunei
                ,
            @Canada_Mountain
                ,
            @America_Vancouver
                ,
            @America_Mendoza
                ,
            @Asia_Istanbul
                ,
            @Asia_Damascus
                ,
            @Europe_Podgorica
                ,
            @Europe_Helsinki
                ,
            @Etc_GMT_LESS_13
                ,
            @Europe_Nicosia
                ,
            @Etc_Universal
                ,
            @America_Argentina_Salta
                ,
            @America_Thule
                ,
            @Israel
                ,
            @Europe_Jersey
                ,
            @GMT_PLUS_0
                ,
            @America_Grenada
                ,
            @Asia_Amman
                ,
            @Europe_Athens
                ,
            @Etc_UTC
                ,
            @America_Miquelon
                ,
            @America_New_York
                ,
            @America_Catamarca
                ,
            @Europe_Gibraltar
                ,
            @America_Santarem
                ,
            @Australia_Eucla
                ,
            @Libya
                ,
            @Atlantic_South_Georgia
                ,
            @Australia_Hobart
                ,
            @Pacific_Apia
                ,
            @America_Fortaleza
                ,
            @Antarctica_South_Pole
                ,
            @America_Montreal
                ,
            @America_Indiana_Indianapolis
                ,
            @Pacific_Ponape
                ,
            @America_Porto_Velho
                ,
            @America_Swift_Current
                , @Africa_Bissau
        }
        private string[] _frv_context_tz = new string[] { "NULL", "Navajo", "America/Santo_Domingo", "Portugal", "Asia/Shanghai", "America/Anguilla", "Africa/Malabo", "Asia/Bishkek", "Africa/Luanda", "Africa/Nairobi", "HST", "Etc/GMT-14", "Canada/Pacific", "America/Indiana/Winamac", "MST", "Etc/GMT+11", "Asia/Tokyo", "Atlantic/Jan_Mayen", "America/Port-au-Prince", "Egypt", "Etc/GMT-0", "EST", "Asia/Anadyr", "Etc/GMT-7", "Europe/Dublin", "Etc/GMT-4", "America/Dawson", "Asia/Tel_Aviv", "Asia/Irkutsk", "W-SU", "Africa/Tripoli", "America/Winnipeg", "GB", "Brazil/DeNoronha", "Africa/Bamako", "America/Argentina/Rio_Gallegos", "America/La_Paz", "Europe/Paris", "America/North_Dakota/Center", "America/Kentucky/Louisville", "Europe/Kiev", "Pacific/Kiritimati", "America/Danmarkshavn", "Australia/ACT", "Europe/Guernsey", "Pacific/Efate", "Europe/Budapest", "America/Curacao", "Mexico/General", "Pacific/Niue", "America/Montserrat", "Asia/Gaza", "Pacific/Norfolk", "America/Jujuy", "Africa/Windhoek", "America/Argentina/Buenos_Aires", "Asia/Aqtobe", "America/Rainy_River", "Etc/Greenwich", "America/Managua", "Canada/East-Saskatchewan", "America/Boa_Vista", "Asia/Dili", "Pacific/Noumea", "Pacific/Galapagos", "Asia/Colombo", "Pacific/Kwajalein", "GMT", "Atlantic/Madeira", "UTC", "Pacific/Kosrae", "Africa/Douala", "Atlantic/St_Helena", "Asia/Urumqi", "Mexico/BajaNorte", "America/St_Barthelemy", "Africa/Lubumbashi", "Asia/Bahrain", "Atlantic/Stanley", "America/Argentina/San_Luis", "US/Samoa", "America/St_Kitts", "America/Chihuahua", "Asia/Oral", "America/Matamoros", "America/Coral_Harbour", "Etc/GMT", "Etc/GMT+6", "Etc/GMT+7", "Australia/Victoria", "Etc/GMT+4", "Etc/GMT+5", "Australia/NSW", "Etc/GMT+8", "Pacific/Wake", "Asia/Baku", "Africa/Algiers", "Asia/Dubai", "Asia/Katmandu", "America/Goose_Bay", "GMT0", "Africa/Abidjan", "Africa/Bujumbura", "America/Atikokan", "Asia/Yekaterinburg", "America/Panama", "Europe/Warsaw", "America/Nome", "Mexico/BajaSur", "Etc/GMT-11", "America/Guatemala", "America/Rio_Branco", "Europe/San_Marino", "Europe/Bucharest", "Asia/Calcutta", "NZ-CHAT", "America/St_Johns", "Asia/Pontianak", "Jamaica", "Africa/Ouagadougou", "Asia/Thimbu", "Atlantic/Canary", "Europe/Madrid", "America/Costa_Rica", "Indian/Comoro", "Europe/Malta", "Turkey", "UCT", "Africa/Porto-Novo", "Asia/Ashkhabad", "Etc/Zulu", "Asia/Jerusalem", "America/Mazatlan", "Asia/Macau", "Europe/Luxembourg", "Pacific/Fiji", "America/Ojinaga", "America/Chicago", "US/Alaska", "Asia/Harbin", "Asia/Ashgabat", "Asia/Aden", "Europe/Samara", "Africa/Kigali", "Asia/Vladivostok", "Asia/Dacca", "America/Cayenne", "Asia/Choibalsan", "Asia/Aqtau", "America/Tortola", "America/Argentina/La_Rioja", "Asia/Kuching", "Chile/Continental", "Pacific/Marquesas", "Europe/Berlin", "Asia/Chongqing", "Iran", "Indian/Christmas", "Hongkong", "US/Pacific-New", "Europe/Rome", "PRC", "Asia/Manila", "Asia/Thimphu", "America/Buenos_Aires", "Africa/Nouakchott", "America/Glace_Bay", "America/Shiprock", "Canada/Atlantic", "Europe/Bratislava", "Europe/Riga", "Australia/Currie", "America/Menominee", "America/Bahia", "Australia/Sydney", "Asia/Omsk", "Australia/Lord_Howe", "Asia/Ulan_Bator", "GB-Eire", "US/Central", "America/Santa_Isabel", "Africa/Johannesburg", "Canada/Eastern", "America/Eirunepe", "Europe/Oslo", "Zulu", "America/Port_of_Spain", "Asia/Jayapura", "Asia/Kuala_Lumpur", "America/Inuvik", "Etc/GMT-6", "Pacific/Enderbury", "Asia/Kuwait", "America/Moncton", "Europe/Vatican", "WET", "America/Whitehorse", "Africa/Ndjamena", "Indian/Reunion", "Asia/Vientiane", "Asia/Dhaka", "CET", "Africa/Tunis", "America/Phoenix", "Europe/Belfast", "America/Guyana", "America/Regina", "Africa/Monrovia", "Indian/Maldives", "Etc/GMT-10", "America/Knox_IN", "Europe/Chisinau", "America/Indiana/Tell_City", "America/Grand_Turk", "Antarctica/DumontDUrville", "America/Aruba", "Europe/Sofia", "America/Guadeloupe", "America/Havana", "Asia/Makassar", "Etc/GMT-3", "Asia/Kamchatka", "Etc/GMT-1", "America/Belem", "America/Los_Angeles", "Africa/Lusaka", "Etc/GMT-5", "Africa/Lome", "Etc/GMT-8", "Etc/GMT-9", "Asia/Samarkand", "Australia/Tasmania", "Africa/Asmera", "Africa/Ceuta", "Europe/Vienna", "Africa/Kinshasa", "Africa/El_Aaiun", "PST8PDT", "America/Antigua", "America/Indiana/Petersburg", "Asia/Pyongyang", "US/Eastern", "America/Porto_Acre", "America/Puerto_Rico", "CST6CDT", "Pacific/Funafuti", "Etc/GMT0", "America/North_Dakota/New_Salem", "Asia/Macao", "Europe/Tallinn", "America/Yakutat", "Asia/Baghdad", "Africa/Brazzaville", "Africa/Khartoum", "Iceland", "America/St_Vincent", "America/Cancun", "Europe/Ljubljana", "Pacific/Chatham", "Europe/Simferopol", "Australia/Broken_Hill", "Europe/Minsk", "Asia/Qyzylorda", "Atlantic/Faeroe", "Australia/Yancowinna", "America/Rankin_Inlet", "Asia/Rangoon", "Africa/Asmara", "Africa/Kampala", "Europe/Istanbul", "Europe/Uzhgorod", "Africa/Accra", "America/Yellowknife", "America/Adak", "Africa/Lagos", "America/Argentina/Mendoza", "America/Montevideo", "Africa/Mogadishu", "America/Sao_Paulo", "America/El_Salvador", "America/Belize", "Canada/Central", "America/Thunder_Bay", "Europe/Prague", "America/Ensenada", "America/Argentina/Cordoba", "Asia/Ho_Chi_Minh", "Pacific/Johnston", "Africa/Maputo", "Europe/Kaliningrad", "Africa/Djibouti", "Brazil/Acre", "Asia/Krasnoyarsk", "Greenwich", "America/Campo_Grande", "Asia/Riyadh", "Asia/Magadan", "Australia/South", "America/Virgin", "Pacific/Guadalcanal", "Antarctica/Palmer", "MET", "Europe/Skopje", "America/Jamaica", "EET", "America/Cuiaba", "EST5EDT", "Singapore", "America/Noronha", "Cuba", "Pacific/Palau", "America/Detroit", "Antarctica/Casey", "America/Argentina/Jujuy", "Antarctica/Rothera", "Europe/Vaduz", "America/Nassau", "America/Santiago", "Asia/Phnom_Penh", "Europe/Zaporozhye", "Asia/Muscat", "Asia/Almaty", "Europe/Mariehamn", "America/Argentina/ComodRivadavia", "America/Toronto", "America/Juneau", "Asia/Kabul", "US/Arizona", "NZ", "America/Indiana/Vincennes", "Africa/Gaborone", "Africa/Cairo", "US/Indiana-Starke", "Asia/Taipei", "Pacific/Rarotonga", "America/Indiana/Knox", "Europe/Sarajevo", "Atlantic/Faroe", "Asia/Kashgar", "ROK", "Australia/Canberra", "Australia/Perth", "America/Dawson_Creek", "Brazil/West", "Europe/Belgrade", "Africa/Niamey", "Europe/Amsterdam", "Europe/Tirane", "Europe/Zurich", "Asia/Yakutsk", "Africa/Dakar", "Indian/Mayotte", "America/Guayaquil", "Etc/GMT+10", "Asia/Novosibirsk", "MST7MDT", "Australia/Brisbane", "Pacific/Guam", "Africa/Libreville", "Indian/Kerguelen", "Pacific/Pitcairn", "America/Anchorage", "Africa/Freetown", "Etc/GMT+2", "Etc/GMT+3", "Etc/GMT+0", "Etc/GMT+1", "America/Resolute", "America/Barbados", "America/Recife", "Asia/Saigon", "America/Boise", "Etc/GMT+9", "Asia/Qatar", "America/Argentina/Catamarca", "America/Mexico_City", "Canada/Newfoundland", "America/Scoresbysund", "Europe/Brussels", "Europe/Vilnius", "America/Paramaribo", "Asia/Bangkok", "Indian/Antananarivo", "Chile/EasterIsland", "Africa/Casablanca", "Australia/Adelaide", "Canada/Yukon", "America/Indianapolis", "Antarctica/Syowa", "Africa/Addis_Ababa", "Pacific/Samoa", "America/Cordoba", "US/Pacific", "Asia/Jakarta", "America/Tegucigalpa", "Etc/GMT-2", "America/Argentina/Ushuaia", "America/Indiana/Vevay", "Asia/Tashkent", "Eire", "Poland", "Australia/Queensland", "ROC", "America/Monterrey", "Pacific/Nauru", "GMT-0", "Atlantic/Azores", "Europe/Copenhagen", "Pacific/Pago_Pago", "Asia/Chungking", "Africa/Blantyre", "America/Denver", "Pacific/Auckland", "America/Bogota", "America/Pangnirtung", "Asia/Novokuznetsk", "Europe/Moscow", "Asia/Kolkata", "Europe/London", "Universal", "Pacific/Tarawa", "Africa/Bangui", "Indian/Mahe", "America/Indiana/Marengo", "America/Nipigon", "America/Fort_Wayne", "US/East-Indiana", "America/Dominica", "Pacific/Yap", "Canada/Saskatchewan", "America/Asuncion", "Pacific/Honolulu", "Europe/Isle_of_Man", "Australia/Melbourne", "Africa/Mbabane", "America/Atka", "Indian/Cocos", "Europe/Stockholm", "America/Cayman", "America/Lima", "America/Halifax", "Asia/Yerevan", "Antarctica/Mawson", "Europe/Lisbon", "Antarctica/Davis", "Arctic/Longyearbyen", "Etc/GMT+12", "America/Edmonton", "Europe/Tiraspol", "Africa/Harare", "America/Blanc-Sablon", "America/St_Thomas", "Pacific/Fakaofo", "Australia/Lindeman", "Japan", "America/Godthab", "Pacific/Gambier", "Asia/Karachi", "Etc/GMT-12", "Africa/Sao_Tome", "Asia/Dushanbe", "Europe/Andorra", "US/Hawaii", "Asia/Hong_Kong", "Indian/Mauritius", "America/Argentina/San_Juan", "US/Mountain", "Pacific/Easter", "Kwajalein", "Africa/Banjul", "Asia/Tehran", "Australia/West", "America/St_Lucia", "Pacific/Truk", "Asia/Seoul", "Australia/LHI", "Europe/Volgograd", "America/Iqaluit", "Atlantic/Reykjavik", "Antarctica/McMurdo", "Pacific/Tongatapu", "America/Manaus", "US/Aleutian", "Pacific/Saipan", "America/Martinique", "Atlantic/Cape_Verde", "America/Cambridge_Bay", "Australia/Darwin", "America/Merida", "America/Rosario", "Asia/Nicosia", "Asia/Kathmandu", "America/Louisville", "America/Caracas", "Africa/Timbuktu", "Pacific/Midway", "Pacific/Majuro", "America/Araguaina", "Etc/UCT", "America/Kentucky/Monticello", "Atlantic/Bermuda", "Asia/Tbilisi", "Asia/Beirut", "Asia/Ulaanbaatar", "Africa/Dar_es_Salaam", "America/Tijuana", "US/Michigan", "America/Maceio", "Europe/Zagreb", "Pacific/Wallis", "Pacific/Tahiti", "Indian/Chagos", "Asia/Ujung_Pandang", "America/Marigot", "Asia/Hovd", "Africa/Maseru", "Australia/North", "America/Argentina/Tucuman", "Brazil/East", "Africa/Conakry", "Asia/Singapore", "Pacific/Port_Moresby", "Europe/Monaco", "Antarctica/Vostok", "America/Hermosillo", "Asia/Sakhalin", "Asia/Brunei", "Canada/Mountain", "America/Vancouver", "America/Mendoza", "Asia/Istanbul", "Asia/Damascus", "Europe/Podgorica", "Europe/Helsinki", "Etc/GMT-13", "Europe/Nicosia", "Etc/Universal", "America/Argentina/Salta", "America/Thule", "Israel", "Europe/Jersey", "GMT+0", "America/Grenada", "Asia/Amman", "Europe/Athens", "Etc/UTC", "America/Miquelon", "America/New_York", "America/Catamarca", "Europe/Gibraltar", "America/Santarem", "Australia/Eucla", "Libya", "Atlantic/South_Georgia", "Australia/Hobart", "Pacific/Apia", "America/Fortaleza", "Antarctica/South_Pole", "America/Montreal", "America/Indiana/Indianapolis", "Pacific/Ponape", "America/Porto_Velho", "America/Swift_Current", "Africa/Bissau" };
        private string[] _fl_context_tz = new string[] { "NULL", "Navajo", "America/Santo_Domingo", "Portugal", "Asia/Shanghai", "America/Anguilla", "Africa/Malabo", "Asia/Bishkek", "Africa/Luanda", "Africa/Nairobi", "HST", "Etc/GMT-14", "Canada/Pacific", "America/Indiana/Winamac", "MST", "Etc/GMT+11", "Asia/Tokyo", "Atlantic/Jan_Mayen", "America/Port-au-Prince", "Egypt", "Etc/GMT-0", "EST", "Asia/Anadyr", "Etc/GMT-7", "Europe/Dublin", "Etc/GMT-4", "America/Dawson", "Asia/Tel_Aviv", "Asia/Irkutsk", "W-SU", "Africa/Tripoli", "America/Winnipeg", "GB", "Brazil/DeNoronha", "Africa/Bamako", "America/Argentina/Rio_Gallegos", "America/La_Paz", "Europe/Paris", "America/North_Dakota/Center", "America/Kentucky/Louisville", "Europe/Kiev", "Pacific/Kiritimati", "America/Danmarkshavn", "Australia/ACT", "Europe/Guernsey", "Pacific/Efate", "Europe/Budapest", "America/Curacao", "Mexico/General", "Pacific/Niue", "America/Montserrat", "Asia/Gaza", "Pacific/Norfolk", "America/Jujuy", "Africa/Windhoek", "America/Argentina/Buenos_Aires", "Asia/Aqtobe", "America/Rainy_River", "Etc/Greenwich", "America/Managua", "Canada/East-Saskatchewan", "America/Boa_Vista", "Asia/Dili", "Pacific/Noumea", "Pacific/Galapagos", "Asia/Colombo", "Pacific/Kwajalein", "GMT", "Atlantic/Madeira", "UTC", "Pacific/Kosrae", "Africa/Douala", "Atlantic/St_Helena", "Asia/Urumqi", "Mexico/BajaNorte", "America/St_Barthelemy", "Africa/Lubumbashi", "Asia/Bahrain", "Atlantic/Stanley", "America/Argentina/San_Luis", "US/Samoa", "America/St_Kitts", "America/Chihuahua", "Asia/Oral", "America/Matamoros", "America/Coral_Harbour", "Etc/GMT", "Etc/GMT+6", "Etc/GMT+7", "Australia/Victoria", "Etc/GMT+4", "Etc/GMT+5", "Australia/NSW", "Etc/GMT+8", "Pacific/Wake", "Asia/Baku", "Africa/Algiers", "Asia/Dubai", "Asia/Katmandu", "America/Goose_Bay", "GMT0", "Africa/Abidjan", "Africa/Bujumbura", "America/Atikokan", "Asia/Yekaterinburg", "America/Panama", "Europe/Warsaw", "America/Nome", "Mexico/BajaSur", "Etc/GMT-11", "America/Guatemala", "America/Rio_Branco", "Europe/San_Marino", "Europe/Bucharest", "Asia/Calcutta", "NZ-CHAT", "America/St_Johns", "Asia/Pontianak", "Jamaica", "Africa/Ouagadougou", "Asia/Thimbu", "Atlantic/Canary", "Europe/Madrid", "America/Costa_Rica", "Indian/Comoro", "Europe/Malta", "Turkey", "UCT", "Africa/Porto-Novo", "Asia/Ashkhabad", "Etc/Zulu", "Asia/Jerusalem", "America/Mazatlan", "Asia/Macau", "Europe/Luxembourg", "Pacific/Fiji", "America/Ojinaga", "America/Chicago", "US/Alaska", "Asia/Harbin", "Asia/Ashgabat", "Asia/Aden", "Europe/Samara", "Africa/Kigali", "Asia/Vladivostok", "Asia/Dacca", "America/Cayenne", "Asia/Choibalsan", "Asia/Aqtau", "America/Tortola", "America/Argentina/La_Rioja", "Asia/Kuching", "Chile/Continental", "Pacific/Marquesas", "Europe/Berlin", "Asia/Chongqing", "Iran", "Indian/Christmas", "Hongkong", "US/Pacific-New", "Europe/Rome", "PRC", "Asia/Manila", "Asia/Thimphu", "America/Buenos_Aires", "Africa/Nouakchott", "America/Glace_Bay", "America/Shiprock", "Canada/Atlantic", "Europe/Bratislava", "Europe/Riga", "Australia/Currie", "America/Menominee", "America/Bahia", "Australia/Sydney", "Asia/Omsk", "Australia/Lord_Howe", "Asia/Ulan_Bator", "GB-Eire", "US/Central", "America/Santa_Isabel", "Africa/Johannesburg", "Canada/Eastern", "America/Eirunepe", "Europe/Oslo", "Zulu", "America/Port_of_Spain", "Asia/Jayapura", "Asia/Kuala_Lumpur", "America/Inuvik", "Etc/GMT-6", "Pacific/Enderbury", "Asia/Kuwait", "America/Moncton", "Europe/Vatican", "WET", "America/Whitehorse", "Africa/Ndjamena", "Indian/Reunion", "Asia/Vientiane", "Asia/Dhaka", "CET", "Africa/Tunis", "America/Phoenix", "Europe/Belfast", "America/Guyana", "America/Regina", "Africa/Monrovia", "Indian/Maldives", "Etc/GMT-10", "America/Knox_IN", "Europe/Chisinau", "America/Indiana/Tell_City", "America/Grand_Turk", "Antarctica/DumontDUrville", "America/Aruba", "Europe/Sofia", "America/Guadeloupe", "America/Havana", "Asia/Makassar", "Etc/GMT-3", "Asia/Kamchatka", "Etc/GMT-1", "America/Belem", "America/Los_Angeles", "Africa/Lusaka", "Etc/GMT-5", "Africa/Lome", "Etc/GMT-8", "Etc/GMT-9", "Asia/Samarkand", "Australia/Tasmania", "Africa/Asmera", "Africa/Ceuta", "Europe/Vienna", "Africa/Kinshasa", "Africa/El_Aaiun", "PST8PDT", "America/Antigua", "America/Indiana/Petersburg", "Asia/Pyongyang", "US/Eastern", "America/Porto_Acre", "America/Puerto_Rico", "CST6CDT", "Pacific/Funafuti", "Etc/GMT0", "America/North_Dakota/New_Salem", "Asia/Macao", "Europe/Tallinn", "America/Yakutat", "Asia/Baghdad", "Africa/Brazzaville", "Africa/Khartoum", "Iceland", "America/St_Vincent", "America/Cancun", "Europe/Ljubljana", "Pacific/Chatham", "Europe/Simferopol", "Australia/Broken_Hill", "Europe/Minsk", "Asia/Qyzylorda", "Atlantic/Faeroe", "Australia/Yancowinna", "America/Rankin_Inlet", "Asia/Rangoon", "Africa/Asmara", "Africa/Kampala", "Europe/Istanbul", "Europe/Uzhgorod", "Africa/Accra", "America/Yellowknife", "America/Adak", "Africa/Lagos", "America/Argentina/Mendoza", "America/Montevideo", "Africa/Mogadishu", "America/Sao_Paulo", "America/El_Salvador", "America/Belize", "Canada/Central", "America/Thunder_Bay", "Europe/Prague", "America/Ensenada", "America/Argentina/Cordoba", "Asia/Ho_Chi_Minh", "Pacific/Johnston", "Africa/Maputo", "Europe/Kaliningrad", "Africa/Djibouti", "Brazil/Acre", "Asia/Krasnoyarsk", "Greenwich", "America/Campo_Grande", "Asia/Riyadh", "Asia/Magadan", "Australia/South", "America/Virgin", "Pacific/Guadalcanal", "Antarctica/Palmer", "MET", "Europe/Skopje", "America/Jamaica", "EET", "America/Cuiaba", "EST5EDT", "Singapore", "America/Noronha", "Cuba", "Pacific/Palau", "America/Detroit", "Antarctica/Casey", "America/Argentina/Jujuy", "Antarctica/Rothera", "Europe/Vaduz", "America/Nassau", "America/Santiago", "Asia/Phnom_Penh", "Europe/Zaporozhye", "Asia/Muscat", "Asia/Almaty", "Europe/Mariehamn", "America/Argentina/ComodRivadavia", "America/Toronto", "America/Juneau", "Asia/Kabul", "US/Arizona", "NZ", "America/Indiana/Vincennes", "Africa/Gaborone", "Africa/Cairo", "US/Indiana-Starke", "Asia/Taipei", "Pacific/Rarotonga", "America/Indiana/Knox", "Europe/Sarajevo", "Atlantic/Faroe", "Asia/Kashgar", "ROK", "Australia/Canberra", "Australia/Perth", "America/Dawson_Creek", "Brazil/West", "Europe/Belgrade", "Africa/Niamey", "Europe/Amsterdam", "Europe/Tirane", "Europe/Zurich", "Asia/Yakutsk", "Africa/Dakar", "Indian/Mayotte", "America/Guayaquil", "Etc/GMT+10", "Asia/Novosibirsk", "MST7MDT", "Australia/Brisbane", "Pacific/Guam", "Africa/Libreville", "Indian/Kerguelen", "Pacific/Pitcairn", "America/Anchorage", "Africa/Freetown", "Etc/GMT+2", "Etc/GMT+3", "Etc/GMT+0", "Etc/GMT+1", "America/Resolute", "America/Barbados", "America/Recife", "Asia/Saigon", "America/Boise", "Etc/GMT+9", "Asia/Qatar", "America/Argentina/Catamarca", "America/Mexico_City", "Canada/Newfoundland", "America/Scoresbysund", "Europe/Brussels", "Europe/Vilnius", "America/Paramaribo", "Asia/Bangkok", "Indian/Antananarivo", "Chile/EasterIsland", "Africa/Casablanca", "Australia/Adelaide", "Canada/Yukon", "America/Indianapolis", "Antarctica/Syowa", "Africa/Addis_Ababa", "Pacific/Samoa", "America/Cordoba", "US/Pacific", "Asia/Jakarta", "America/Tegucigalpa", "Etc/GMT-2", "America/Argentina/Ushuaia", "America/Indiana/Vevay", "Asia/Tashkent", "Eire", "Poland", "Australia/Queensland", "ROC", "America/Monterrey", "Pacific/Nauru", "GMT-0", "Atlantic/Azores", "Europe/Copenhagen", "Pacific/Pago_Pago", "Asia/Chungking", "Africa/Blantyre", "America/Denver", "Pacific/Auckland", "America/Bogota", "America/Pangnirtung", "Asia/Novokuznetsk", "Europe/Moscow", "Asia/Kolkata", "Europe/London", "Universal", "Pacific/Tarawa", "Africa/Bangui", "Indian/Mahe", "America/Indiana/Marengo", "America/Nipigon", "America/Fort_Wayne", "US/East-Indiana", "America/Dominica", "Pacific/Yap", "Canada/Saskatchewan", "America/Asuncion", "Pacific/Honolulu", "Europe/Isle_of_Man", "Australia/Melbourne", "Africa/Mbabane", "America/Atka", "Indian/Cocos", "Europe/Stockholm", "America/Cayman", "America/Lima", "America/Halifax", "Asia/Yerevan", "Antarctica/Mawson", "Europe/Lisbon", "Antarctica/Davis", "Arctic/Longyearbyen", "Etc/GMT+12", "America/Edmonton", "Europe/Tiraspol", "Africa/Harare", "America/Blanc-Sablon", "America/St_Thomas", "Pacific/Fakaofo", "Australia/Lindeman", "Japan", "America/Godthab", "Pacific/Gambier", "Asia/Karachi", "Etc/GMT-12", "Africa/Sao_Tome", "Asia/Dushanbe", "Europe/Andorra", "US/Hawaii", "Asia/Hong_Kong", "Indian/Mauritius", "America/Argentina/San_Juan", "US/Mountain", "Pacific/Easter", "Kwajalein", "Africa/Banjul", "Asia/Tehran", "Australia/West", "America/St_Lucia", "Pacific/Truk", "Asia/Seoul", "Australia/LHI", "Europe/Volgograd", "America/Iqaluit", "Atlantic/Reykjavik", "Antarctica/McMurdo", "Pacific/Tongatapu", "America/Manaus", "US/Aleutian", "Pacific/Saipan", "America/Martinique", "Atlantic/Cape_Verde", "America/Cambridge_Bay", "Australia/Darwin", "America/Merida", "America/Rosario", "Asia/Nicosia", "Asia/Kathmandu", "America/Louisville", "America/Caracas", "Africa/Timbuktu", "Pacific/Midway", "Pacific/Majuro", "America/Araguaina", "Etc/UCT", "America/Kentucky/Monticello", "Atlantic/Bermuda", "Asia/Tbilisi", "Asia/Beirut", "Asia/Ulaanbaatar", "Africa/Dar_es_Salaam", "America/Tijuana", "US/Michigan", "America/Maceio", "Europe/Zagreb", "Pacific/Wallis", "Pacific/Tahiti", "Indian/Chagos", "Asia/Ujung_Pandang", "America/Marigot", "Asia/Hovd", "Africa/Maseru", "Australia/North", "America/Argentina/Tucuman", "Brazil/East", "Africa/Conakry", "Asia/Singapore", "Pacific/Port_Moresby", "Europe/Monaco", "Antarctica/Vostok", "America/Hermosillo", "Asia/Sakhalin", "Asia/Brunei", "Canada/Mountain", "America/Vancouver", "America/Mendoza", "Asia/Istanbul", "Asia/Damascus", "Europe/Podgorica", "Europe/Helsinki", "Etc/GMT-13", "Europe/Nicosia", "Etc/Universal", "America/Argentina/Salta", "America/Thule", "Israel", "Europe/Jersey", "GMT+0", "America/Grenada", "Asia/Amman", "Europe/Athens", "Etc/UTC", "America/Miquelon", "America/New_York", "America/Catamarca", "Europe/Gibraltar", "America/Santarem", "Australia/Eucla", "Libya", "Atlantic/South_Georgia", "Australia/Hobart", "Pacific/Apia", "America/Fortaleza", "Antarctica/South_Pole", "America/Montreal", "America/Indiana/Indianapolis", "Pacific/Ponape", "America/Porto_Velho", "America/Swift_Current", "Africa/Bissau" };
        private ENUM_CONTEXT_TZ _fv_context_tz;
        public ENUM_CONTEXT_TZ context_tz
        {
            get { return _fv_context_tz; }
            set { _fv_context_tz = value; }
        }
        public string LIBELLE_context_tz
        {
            get { return _fl_context_tz[(int)_fv_context_tz]; }
        }

        private manyToOne _f_context_um_printer_id = new manyToOne(); //printers.list
        public manyToOne context_um_printer_id
        {
            get { return _f_context_um_printer_id; }
        }

        private manyToMany _f_warehouse_ids = new manyToMany(); //stock.warehouse
        public manyToMany warehouse_ids
        {
            get { return _f_warehouse_ids; }
        }

        private manyToMany _f_company_ids = new manyToMany(); //res.company
        public manyToMany company_ids
        {
            get { return _f_company_ids; }
        }

        public bool menu_tips
        {
            get { return (bool)listProperties.value("menu_tips", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("menu_tips", value); }
        }

        private manyToOne _f_menu_id = new manyToOne(); //ir.actions.actions
        public manyToOne menu_id
        {
            get { return _f_menu_id; }
        }

        public string password
        {
            get { return (string)listProperties.value("password", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("password", value); }
        }

        public bool active
        {
            get { return (bool)listProperties.value("active", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("active", value); }
        }

        public bool com_apply_limit
        {
            get { return (bool)listProperties.value("com_apply_limit", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("com_apply_limit", value); }
        }

        public bool has_signature
        {
            get { return (bool)listProperties.value("has_signature", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("has_signature", value); }
        }

        public enum ENUM_CONTEXT_LANG
        {
            NULL
            ,
            @es_ES
                ,
            @it_IT
                ,
            @fr_FR
                ,
            @zh_CN
                ,
            @de_DE
                ,
            @pt_PT
                ,
            @fr
                ,
            @en_US
                , @ar_AR
        }
        private string[] _frv_context_lang = new string[] { "NULL", "es_ES", "it_IT", "fr_FR", "zh_CN", "de_DE", "pt_PT", "fr", "en_US", "ar_AR" };
        private string[] _fl_context_lang = new string[] { "NULL", "Spanish / Español", "Italian / Italiano", "French / Français", "Chinese (CN) / 简体中文", "German / Deutsch", "Portugese / Português", "fr", "English", "Arabic / الْعَرَبيّة" };
        private ENUM_CONTEXT_LANG _fv_context_lang;
        public ENUM_CONTEXT_LANG context_lang
        {
            get { return _fv_context_lang; }
            set { _fv_context_lang = value; }
        }
        public string LIBELLE_context_lang
        {
            get { return _fl_context_lang[(int)_fv_context_lang]; }
        }

        public string name
        {
            get { return (string)listProperties.value("name", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("name", value); }
        }

        private manyToOne _f_context_section_id = new manyToOne(); //crm.case.section
        public manyToOne context_section_id
        {
            get { return _f_context_section_id; }
        }

        public int context_stock2date_end
        {
            get { return (int)listProperties.value("context_stock2date_end", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("context_stock2date_end", value); }
        }

        public double com_limit
        {
            get { return (double)listProperties.value("com_limit", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("com_limit", value); }
        }

        public int context_stock2date_start
        {
            get { return (int)listProperties.value("context_stock2date_start", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("context_stock2date_start", value); }
        }

        public string signature
        {
            get { return (string)listProperties.value("signature", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("signature", value); }
        }

        public string login
        {
            get { return (string)listProperties.value("login", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("login", value); }
        }

        private manyToOne _f_context_department_id = new manyToOne(); //hr.department
        public manyToOne context_department_id
        {
            get { return _f_context_department_id; }
        }

        private manyToOne _f_context_printer_id = new manyToOne(); //printers.list
        public manyToOne context_printer_id
        {
            get { return _f_context_printer_id; }
        }

        public string user_email
        {
            get { return (string)listProperties.value("user_email", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("user_email", value); }
        }

        public enum ENUM_VIEW
        {
            NULL
            ,
            @simple
                , @extended
        }
        private string[] _frv_view = new string[] { "NULL", "simple", "extended" };
        private string[] _fl_view = new string[] { "NULL", "Simplified", "Extended" };
        private ENUM_VIEW _fv_view;
        public ENUM_VIEW view
        {
            get { return _fv_view; }
            set { _fv_view = value; }
        }
        public string LIBELLE_view
        {
            get { return _fl_view[(int)_fv_view]; }
        }

        public int id
        {
            get { return (int)listProperties.value("id", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("id", value); }
        }
        public override string resource_name()
        {
            return "res.users";
        }
    }
}
