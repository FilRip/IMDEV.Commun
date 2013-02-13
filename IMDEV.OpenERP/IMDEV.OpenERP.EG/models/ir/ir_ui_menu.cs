using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMDEV.OpenERP.models.@base;
using IMDEV.OpenERP.models.fields.relations;

namespace IMDEV.OpenERP.EG.models.ir
{
    public class ir_ui_menu : anOpenERPObject
    {
        public byte[] web_icon_data
        {
            get { return (byte[])listProperties.value("web_icon_data", aField.FIELD_TYPE.BINARY); }
        }

        private manyToMany _f_groups_id = new manyToMany(); //res.groups
        public manyToMany groups_id
        {
            get { return _f_groups_id; }
        }

        public string name
        {
            get { return (string)listProperties.value("name", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("name", value); }
        }
        private IMDEV.OpenERP.models.fields.texteMultilangue _name_multilangue;
        public IMDEV.OpenERP.models.fields.texteMultilangue name_multilangue
        {
            get
            {
                if (_name_multilangue == null) _name_multilangue = new IMDEV.OpenERP.models.fields.texteMultilangue(this, "name");
                return _name_multilangue;
            }
        }

        public string web_icon
        {
            get { return (string)listProperties.value("web_icon", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("web_icon", value); }
        }

        public int sequence
        {
            get { return (int)listProperties.value("sequence", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("sequence", value); }
        }

        public string web_icon_hover
        {
            get { return (string)listProperties.value("web_icon_hover", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("web_icon_hover", value); }
        }

        private manyToOne _f_parent_id = new manyToOne(); //ir.ui.menu
        public manyToOne parent_id
        {
            get { return _f_parent_id; }
        }

        public string complete_name
        {
            get { return (string)listProperties.value("complete_name", aField.FIELD_TYPE.CHAR); }
        }

        public System.Collections.ArrayList action
        {
            get { return (System.Collections.ArrayList)listProperties.value("action", aField.FIELD_TYPE.REFERENCE); }
            set { listProperties.setValue("action", value); }
        }

        public enum ENUM_ICON
        {
            NULL
            ,
            @STOCK_MISSING_IMAGE
                ,
            @STOCK_GOTO_LAST
                ,
            @terp_LESS_gtk_LESS_media_LESS_pause
                ,
            @STOCK_GO_BACK
                ,
            @terp_LESS_emblem_LESS_important
                ,
            @terp_LESS_account
                ,
            @terp_LESS_go_LESS_month
                ,
            @terp_LESS_sale
                ,
            @STOCK_PASTE
                ,
            @STOCK_ZOOM_100
                ,
            @STOCK_SAVE
                ,
            @terp_LESS_gtk_LESS_go_LESS_back_LESS_rtl
                ,
            @terp_LESS_mail_LESS_message_LESS_new
                ,
            @terp_LESS_stage
                ,
            @terp_LESS_purchase
                ,
            @terp_LESS_rating_LESS_rated
                ,
            @terp_LESS_graph
                ,
            @STOCK_CDROM
                ,
            @terp_LESS_hr
                ,
            @STOCK_PROPERTIES
                ,
            @STOCK_MEDIA_PREVIOUS
                ,
            @STOCK_SAVE_AS
                ,
            @terp_LESS_product
                ,
            @STOCK_MEDIA_RECORD
                ,
            @STOCK_DIALOG_WARNING
                ,
            @STOCK_REFRESH
                ,
            @STOCK_DIALOG_ERROR
                ,
            @terp_LESS_idea
                ,
            @STOCK_GO_FORWARD
                ,
            @STOCK_DIRECTORY
                ,
            @STOCK_EXECUTE
                ,
            @STOCK_UNDERLINE
                ,
            @terp_LESS_report
                ,
            @STOCK_MEDIA_STOP
                ,
            @STOCK_EDIT
                ,
            @terp_LESS_gtk_LESS_go_LESS_back_LESS_ltr
                ,
            @terp_LESS_accessories_LESS_archiver
                ,
            @STOCK_HARDDISK
                ,
            @terp_LESS_stock_effects_LESS_object_LESS_colorize
                ,
            @STOCK_ZOOM_IN
                ,
            @STOCK_QUIT
                ,
            @STOCK_CUT
                ,
            @terp_LESS_mail_LESS_replied
                ,
            @terp_LESS_check
                ,
            @STOCK_CLEAR
                ,
            @STOCK_SPELL_CHECK
                ,
            @STOCK_REVERT_TO_SAVED
                ,
            @STOCK_SORT_DESCENDING
                ,
            @STOCK_JUSTIFY_FILL
                ,
            @terp_LESS_dolar
                ,
            @STOCK_GO_DOWN
                ,
            @STOCK_REDO
                ,
            @STOCK_JUSTIFY_LEFT
                ,
            @terp_LESS_folder_LESS_green
                ,
            @STOCK_JUSTIFY_RIGHT
                ,
            @terp_LESS_gdu_LESS_smart_LESS_failing
                ,
            @STOCK_PRINT_PREVIEW
                ,
            @STOCK_STOP
                ,
            @STOCK_ABOUT
                ,
            @terp_LESS_accessories_LESS_archiver_LESS_minus
                ,
            @STOCK_CANCEL
                ,
            @terp_LESS_folder_LESS_blue
                ,
            @terp_LESS_stock_symbol_LESS_selection
                ,
            @terp_LESS_tools
                ,
            @terp_LESS_face_LESS_plain
                ,
            @terp_LESS_folder_LESS_orange
                ,
            @terp_LESS_document_LESS_new
                ,
            @STOCK_DND_MULTIPLE
                ,
            @STOCK_GO_UP
                ,
            @terp_LESS_locked
                ,
            @terp_LESS_stock
                ,
            @STOCK_OK
                ,
            @STOCK_SELECT_COLOR
                ,
            @STOCK_MEDIA_PLAY
                ,
            @terp_LESS_call_LESS_start
                ,
            @STOCK_GOTO_BOTTOM
                ,
            @STOCK_INDENT
                ,
            @STOCK_MEDIA_NEXT
                ,
            @STOCK_SELECT_FONT
                ,
            @STOCK_DND
                ,
            @STOCK_REMOVE
                ,
            @terp_LESS_go_LESS_home
                ,
            @terp_LESS_go_LESS_week
                ,
            @STOCK_NEW
                ,
            @terp_LESS_go_LESS_year
                ,
            @STOCK_STRIKETHROUGH
                ,
            @STOCK_MEDIA_FORWARD
                ,
            @STOCK_CONNECT
                ,
            @terp_LESS_go_LESS_today
                ,
            @STOCK_SORT_ASCENDING
                ,
            @STOCK_FIND
                ,
            @STOCK_UNDO
                ,
            @STOCK_JUSTIFY_CENTER
                ,
            @STOCK_COLOR_PICKER
                ,
            @STOCK_GOTO_FIRST
                ,
            @STOCK_OPEN
                ,
            @terp_LESS_stock_format_LESS_default
                ,
            @terp_LESS_dialog_LESS_close
                ,
            @STOCK_ZOOM_OUT
                ,
            @terp_LESS_gtk_LESS_select_LESS_all
                ,
            @terp_LESS_crm
                ,
            @terp_LESS_gtk_LESS_stop
                ,
            @terp_LESS_stock_format_LESS_scientific
                ,
            @terp_LESS_personal
                ,
            @terp_LESS_gtk_LESS_jump_LESS_to_LESS_rtl
                ,
            @STOCK_FLOPPY
                ,
            @STOCK_DELETE
                ,
            @terp_LESS_camera_test
                ,
            @STOCK_APPLY
                ,
            @terp_LESS_accessories_LESS_archiver_PLUS_
                ,
            @STOCK_UNINDENT
                ,
            @STOCK_PREFERENCES
                ,
            @terp_LESS_dolar_ok_EXCLAMATION_
                ,
            @STOCK_MEDIA_PAUSE
                ,
            @STOCK_CLOSE
                ,
            @terp_LESS_mrp
                ,
            @terp_LESS_calendar
                ,
            @STOCK_GOTO_TOP
                ,
            @terp_LESS_project
                ,
            @STOCK_HELP
                ,
            @STOCK_HOME
                ,
            @terp_LESS_folder_LESS_yellow
                ,
            @STOCK_FILE
                ,
            @STOCK_DISCONNECT
                ,
            @STOCK_ADD
                ,
            @STOCK_CONVERT
                ,
            @STOCK_YES
                ,
            @STOCK_PRINT
                ,
            @STOCK_COPY
                ,
            @terp_LESS_mail_delete
                ,
            @STOCK_FIND_AND_REPLACE
                ,
            @STOCK_DIALOG_QUESTION
                ,
            @STOCK_JUMP_TO
                ,
            @terp_LESS_gtk_LESS_jump_LESS_to_LESS_ltr
                ,
            @STOCK_ZOOM_FIT
                ,
            @STOCK_INDEX
                ,
            @STOCK_ITALIC
                ,
            @terp_LESS_stock_align_left_24
                ,
            @STOCK_BOLD
                ,
            @terp_LESS_gnome_LESS_cpu_LESS_frequency_LESS_applet_PLUS_
                ,
            @STOCK_MEDIA_REWIND
                ,
            @STOCK_DIALOG_INFO
                ,
            @terp_LESS_mail_LESS_forward
                ,
            @STOCK_UNDELETE
                ,
            @terp_LESS_mail_LESS_
                ,
            @terp_LESS_administration
                ,
            @terp_LESS_personal_LESS_
                ,
            @STOCK_NO
                ,
            @terp_LESS_personal_PLUS_
                ,
            @terp_LESS_partner
                ,
            @STOCK_NETWORK
                , @STOCK_DIALOG_AUTHENTICATION
        }
        private string[] _frv_icon = new string[] { "NULL", "STOCK_MISSING_IMAGE", "STOCK_GOTO_LAST", "terp-gtk-media-pause", "STOCK_GO_BACK", "terp-emblem-important", "terp-account", "terp-go-month", "terp-sale", "STOCK_PASTE", "STOCK_ZOOM_100", "STOCK_SAVE", "terp-gtk-go-back-rtl", "terp-mail-message-new", "terp-stage", "terp-purchase", "terp-rating-rated", "terp-graph", "STOCK_CDROM", "terp-hr", "STOCK_PROPERTIES", "STOCK_MEDIA_PREVIOUS", "STOCK_SAVE_AS", "terp-product", "STOCK_MEDIA_RECORD", "STOCK_DIALOG_WARNING", "STOCK_REFRESH", "STOCK_DIALOG_ERROR", "terp-idea", "STOCK_GO_FORWARD", "STOCK_DIRECTORY", "STOCK_EXECUTE", "STOCK_UNDERLINE", "terp-report", "STOCK_MEDIA_STOP", "STOCK_EDIT", "terp-gtk-go-back-ltr", "terp-accessories-archiver", "STOCK_HARDDISK", "terp-stock_effects-object-colorize", "STOCK_ZOOM_IN", "STOCK_QUIT", "STOCK_CUT", "terp-mail-replied", "terp-check", "STOCK_CLEAR", "STOCK_SPELL_CHECK", "STOCK_REVERT_TO_SAVED", "STOCK_SORT_DESCENDING", "STOCK_JUSTIFY_FILL", "terp-dolar", "STOCK_GO_DOWN", "STOCK_REDO", "STOCK_JUSTIFY_LEFT", "terp-folder-green", "STOCK_JUSTIFY_RIGHT", "terp-gdu-smart-failing", "STOCK_PRINT_PREVIEW", "STOCK_STOP", "STOCK_ABOUT", "terp-accessories-archiver-minus", "STOCK_CANCEL", "terp-folder-blue", "terp-stock_symbol-selection", "terp-tools", "terp-face-plain", "terp-folder-orange", "terp-document-new", "STOCK_DND_MULTIPLE", "STOCK_GO_UP", "terp-locked", "terp-stock", "STOCK_OK", "STOCK_SELECT_COLOR", "STOCK_MEDIA_PLAY", "terp-call-start", "STOCK_GOTO_BOTTOM", "STOCK_INDENT", "STOCK_MEDIA_NEXT", "STOCK_SELECT_FONT", "STOCK_DND", "STOCK_REMOVE", "terp-go-home", "terp-go-week", "STOCK_NEW", "terp-go-year", "STOCK_STRIKETHROUGH", "STOCK_MEDIA_FORWARD", "STOCK_CONNECT", "terp-go-today", "STOCK_SORT_ASCENDING", "STOCK_FIND", "STOCK_UNDO", "STOCK_JUSTIFY_CENTER", "STOCK_COLOR_PICKER", "STOCK_GOTO_FIRST", "STOCK_OPEN", "terp-stock_format-default", "terp-dialog-close", "STOCK_ZOOM_OUT", "terp-gtk-select-all", "terp-crm", "terp-gtk-stop", "terp-stock_format-scientific", "terp-personal", "terp-gtk-jump-to-rtl", "STOCK_FLOPPY", "STOCK_DELETE", "terp-camera_test", "STOCK_APPLY", "terp-accessories-archiver+", "STOCK_UNINDENT", "STOCK_PREFERENCES", "terp-dolar_ok!", "STOCK_MEDIA_PAUSE", "STOCK_CLOSE", "terp-mrp", "terp-calendar", "STOCK_GOTO_TOP", "terp-project", "STOCK_HELP", "STOCK_HOME", "terp-folder-yellow", "STOCK_FILE", "STOCK_DISCONNECT", "STOCK_ADD", "STOCK_CONVERT", "STOCK_YES", "STOCK_PRINT", "STOCK_COPY", "terp-mail_delete", "STOCK_FIND_AND_REPLACE", "STOCK_DIALOG_QUESTION", "STOCK_JUMP_TO", "terp-gtk-jump-to-ltr", "STOCK_ZOOM_FIT", "STOCK_INDEX", "STOCK_ITALIC", "terp-stock_align_left_24", "STOCK_BOLD", "terp-gnome-cpu-frequency-applet+", "STOCK_MEDIA_REWIND", "STOCK_DIALOG_INFO", "terp-mail-forward", "STOCK_UNDELETE", "terp-mail-", "terp-administration", "terp-personal-", "STOCK_NO", "terp-personal+", "terp-partner", "STOCK_NETWORK", "STOCK_DIALOG_AUTHENTICATION" };
        private string[] _fl_icon = new string[] { "NULL", "STOCK_MISSING_IMAGE", "STOCK_GOTO_LAST", "terp-gtk-media-pause", "STOCK_GO_BACK", "terp-emblem-important", "terp-account", "terp-go-month", "terp-sale", "STOCK_PASTE", "STOCK_ZOOM_100", "STOCK_SAVE", "terp-gtk-go-back-rtl", "terp-mail-message-new", "terp-stage", "terp-purchase", "terp-rating-rated", "terp-graph", "STOCK_CDROM", "terp-hr", "STOCK_PROPERTIES", "STOCK_MEDIA_PREVIOUS", "STOCK_SAVE_AS", "terp-product", "STOCK_MEDIA_RECORD", "STOCK_DIALOG_WARNING", "STOCK_REFRESH", "STOCK_DIALOG_ERROR", "terp-idea", "STOCK_GO_FORWARD", "STOCK_DIRECTORY", "STOCK_EXECUTE", "STOCK_UNDERLINE", "terp-report", "STOCK_MEDIA_STOP", "STOCK_EDIT", "terp-gtk-go-back-ltr", "terp-accessories-archiver", "STOCK_HARDDISK", "terp-stock_effects-object-colorize", "STOCK_ZOOM_IN", "STOCK_QUIT", "STOCK_CUT", "terp-mail-replied", "terp-check", "STOCK_CLEAR", "STOCK_SPELL_CHECK", "STOCK_REVERT_TO_SAVED", "STOCK_SORT_DESCENDING", "STOCK_JUSTIFY_FILL", "terp-dolar", "STOCK_GO_DOWN", "STOCK_REDO", "STOCK_JUSTIFY_LEFT", "terp-folder-green", "STOCK_JUSTIFY_RIGHT", "terp-gdu-smart-failing", "STOCK_PRINT_PREVIEW", "STOCK_STOP", "STOCK_ABOUT", "terp-accessories-archiver-minus", "STOCK_CANCEL", "terp-folder-blue", "terp-stock_symbol-selection", "terp-tools", "terp-face-plain", "terp-folder-orange", "terp-document-new", "STOCK_DND_MULTIPLE", "STOCK_GO_UP", "terp-locked", "terp-stock", "STOCK_OK", "STOCK_SELECT_COLOR", "STOCK_MEDIA_PLAY", "terp-call-start", "STOCK_GOTO_BOTTOM", "STOCK_INDENT", "STOCK_MEDIA_NEXT", "STOCK_SELECT_FONT", "STOCK_DND", "STOCK_REMOVE", "terp-go-home", "terp-go-week", "STOCK_NEW", "terp-go-year", "STOCK_STRIKETHROUGH", "STOCK_MEDIA_FORWARD", "STOCK_CONNECT", "terp-go-today", "STOCK_SORT_ASCENDING", "STOCK_FIND", "STOCK_UNDO", "STOCK_JUSTIFY_CENTER", "STOCK_COLOR_PICKER", "STOCK_GOTO_FIRST", "STOCK_OPEN", "terp-stock_format-default", "terp-dialog-close", "STOCK_ZOOM_OUT", "terp-gtk-select-all", "terp-crm", "terp-gtk-stop", "terp-stock_format-scientific", "terp-personal", "terp-gtk-jump-to-rtl", "STOCK_FLOPPY", "STOCK_DELETE", "terp-camera_test", "STOCK_APPLY", "terp-accessories-archiver+", "STOCK_UNINDENT", "STOCK_PREFERENCES", "terp-dolar_ok!", "STOCK_MEDIA_PAUSE", "STOCK_CLOSE", "terp-mrp", "terp-calendar", "STOCK_GOTO_TOP", "terp-project", "STOCK_HELP", "STOCK_HOME", "terp-folder-yellow", "STOCK_FILE", "STOCK_DISCONNECT", "STOCK_ADD", "STOCK_CONVERT", "STOCK_YES", "STOCK_PRINT", "STOCK_COPY", "terp-mail_delete", "STOCK_FIND_AND_REPLACE", "STOCK_DIALOG_QUESTION", "STOCK_JUMP_TO", "terp-gtk-jump-to-ltr", "STOCK_ZOOM_FIT", "STOCK_INDEX", "STOCK_ITALIC", "terp-stock_align_left_24", "STOCK_BOLD", "terp-gnome-cpu-frequency-applet+", "STOCK_MEDIA_REWIND", "STOCK_DIALOG_INFO", "terp-mail-forward", "STOCK_UNDELETE", "terp-mail-", "terp-administration", "terp-personal-", "STOCK_NO", "terp-personal+", "terp-partner", "STOCK_NETWORK", "STOCK_DIALOG_AUTHENTICATION" };
        private ENUM_ICON _fv_icon;
        public ENUM_ICON icon
        {
            get { return _fv_icon; }
            set { _fv_icon = value; }
        }
        public string LIBELLE_icon
        {
            get { return _fl_icon[(int)_fv_icon]; }
        }

        private oneToMany _f_child_id = new oneToMany(); //ir.ui.menu
        public oneToMany child_id
        {
            get { return _f_child_id; }
        }

        public byte[] web_icon_hover_data
        {
            get { return (byte[])listProperties.value("web_icon_hover_data", aField.FIELD_TYPE.BINARY); }
        }

        public string icon_pict
        {
            get { return (string)listProperties.value("icon_pict", aField.FIELD_TYPE.CHAR); }
        }

        public int id
        {
            get { return (int)listProperties.value("id", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("id", value); }
        }
        public override string resource_name()
        {
            return "ir.ui.menu";
        }
    }
}
