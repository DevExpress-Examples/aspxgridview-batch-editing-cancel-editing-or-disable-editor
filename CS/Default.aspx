<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v18.2, Version=18.2.2.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function OnBatchStartEdit(s, e) {
            //client processing
            var keyIndex = s.GetColumnByField("ID").index;
            var key = e.rowValues[keyIndex].value;

            var condition = key % 2 == 0;

            if (e.focusedColumn.fieldName == "ClientSideCancel") //cancel example
                if (!condition) e.cancel = true;

            //server preprocessing
            if (typeof s.cp_cellsToDisable[key] != "undefined" && s.cp_cellsToDisable[key] == e.focusedColumn.fieldName)
                e.cancel = true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <dx:ASPxGridView ID="ASPxGridView1" runat="server" KeyFieldName="ID" OnCustomJSProperties="ASPxGridView1_CustomJSProperties">
            <SettingsEditing Mode="Batch"></SettingsEditing>
            <ClientSideEvents BatchEditStartEditing="OnBatchStartEdit" />
        </dx:ASPxGridView>
    </div>
    </form>
</body>
</html>
